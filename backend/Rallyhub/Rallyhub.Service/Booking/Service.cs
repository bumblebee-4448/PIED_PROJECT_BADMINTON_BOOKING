using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;

namespace Rallyhub.Service.Booking;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContext;
    private readonly Wallet.IService _walletService;
    private readonly Transaction.IService _transactionService;
    private readonly Owner.IService _ownerService;
    private readonly Notification.IService _notificationService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext, 
        Wallet.IService walletService, Transaction.IService transactionService, Owner.IService ownerService, Notification.IService notificationService)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
        _walletService = walletService;
        _transactionService = transactionService;
        _ownerService = ownerService;
        _notificationService = notificationService;
    }
    
    public async Task<Response.CreateBookingResponse> CreateBooking(Request.CreateBookingRequest request)
    {
        //thêm campaign
        var customerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Không tìm thấy thông tin của customer");
        }
        var customerId = Guid.Parse(customerIdClaim);

        var availableSlotsSubCourt = new Dictionary<Guid, List<Owner.Response.SlotResponse>>();
        foreach (var item in request.Items)
        {
            var availableSlots = await _ownerService.GetAvailableSlots(new Owner.Request.GetAvailableSlotsRequest()
            {
                SubCourtId = item.SubCourtId,
                Date = request.Date
            });
            
            availableSlotsSubCourt[item.SubCourtId] = availableSlots; 
        }
        
        // var now = DateTime.Now;
        var vnZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnZone);

        foreach (var item in request.Items)
        {
            var availableSlots = availableSlotsSubCourt[item.SubCourtId];
            foreach (var slot in item.Slots)
            {
                var systemSlot = availableSlots.FirstOrDefault(x =>
                    x.StartTime == slot.StartTime
                    && x.EndTime == slot.EndTime);

                if (systemSlot == null)
                {
                    throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} không tồn tại");
                }
            
                if(request.Date.ToDateTime(slot.StartTime) <= now)
                {
                    throw new Exception("Không được đặt sân trong quá khứ");
                };

                if (!systemSlot.IsAvailable)
                {
                    throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị đặt hoặc đã khóa");
                }
            }
        }
        
        var dateTime = new DateTimeOffset(request.Date.ToDateTime(TimeOnly.MinValue), TimeSpan.Zero);
        foreach (var item in request.Items)
        {
            var bookedSlots = await _dbContext.BookingDetails
                .Where(x =>
                    x.SubCourtId == item.SubCourtId &&
                    x.Date.Date == dateTime.Date &&
                    (x.Status == "Pending" || x.Status == "Banked"))
                .ToListAsync();
            foreach (var slot in item.Slots)
            {
                var conflict = bookedSlots.Any(b =>
                    b.StartTime < slot.EndTime &&
                    b.EndTime > slot.StartTime);
                if (conflict)
                {
                    throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị người khác đặt");
                }
            }
        }
        
        decimal totalPrice = 0;
        foreach (var item in request.Items)
        {
            var availableSlots = availableSlotsSubCourt[item.SubCourtId];
            
            totalPrice += item.Slots.Sum(slot =>
                availableSlots.First(x => 
                    x.StartTime == slot.StartTime &&
                    x.EndTime == slot.EndTime).Price);
        }
        //campain| hàm này hình như có vấn đề
        decimal finalPrice =  totalPrice;
        if (request.CampaignId != null)
        {
            var campaign = await _dbContext.Campaigns
                .Include(c => c.Courts)
                .FirstOrDefaultAsync(c =>
                    c.Id == request.CampaignId &&
                    c.Code == request.Code &&
                    c.StartDate <= request.Date.ToDateTime(TimeOnly.MinValue) &&
                    c.EndDate >= request.Date.ToDateTime(TimeOnly.MinValue));
            if (campaign == null)
            {
                throw new Exception("Campaign không tồn tại hoặc đã hết hạn");
            }

            if (campaign.UsedCount >= campaign.UsageLimit)
            {
                throw new Exception("Campaign đã hết lượt sử dụng");
            }

            if (totalPrice < campaign.MinBookingAmount)
            {
                throw new Exception($"Giá trị đơn hàng tối thiểu để dùng campaign là {campaign.MinBookingAmount}");
            }

            if (!campaign.IsGlobal)
            {
                var firstSubCourtId = request.Items.First().SubCourtId;
                var courtId = await _dbContext.SubCourts
                    .Where(x => x.Id == firstSubCourtId)
                    .Select(x => x.CourtId)
                    .FirstOrDefaultAsync();
                var campaignCourtIds = campaign.Courts.Select(x => x.CourtId).ToList();
                if (!campaignCourtIds.Contains(courtId))
                {
                    throw new Exception("Campaign này không áp dụng cho sân bạn đang đặt");
                }
            }

            var discountAmount = totalPrice * (campaign.DiscountPercent / 100m);
            if (discountAmount > campaign.MaxDiscountAmount)
            {
                discountAmount = campaign.MaxDiscountAmount;
            }

            finalPrice = totalPrice - discountAmount;
            if (finalPrice < 0) finalPrice = 0;
            campaign.UsedCount += 1;
            _dbContext.Campaigns.Update(campaign);
        }
        
        var booking = new Repository.Entity.Booking
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            TotalPrice = totalPrice,
            FinalPrice = finalPrice,
            Status = "Pending",
            ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(100),
            CampaignId = request.CampaignId,
        };

        var bookingDetails = new List<BookingDetail>();
        foreach (var item in request.Items)
        {
            var availableSlots = availableSlotsSubCourt[item.SubCourtId];
            bookingDetails.AddRange(item.Slots.Select(slot => new BookingDetail()
            {
                Id = Guid.NewGuid(),
                SubCourtId = item.SubCourtId,
                BookingId = booking.Id,
                Date = dateTime,
                StartTime = slot.StartTime,
                EndTime = slot.EndTime,
                Price = availableSlots.First(x =>
                    x.StartTime == slot.StartTime &&
                    x.EndTime == slot.EndTime).Price,
                Status = "Pending",
            }));
        }
        
        await _dbContext.Bookings.AddAsync(booking);
        await _dbContext.BookingDetails.AddRangeAsync(bookingDetails);
        await _dbContext.SaveChangesAsync();

        string bankName = "MBBank";
        string bankAccount = "VQRQAIUZK3222";
        string description = $"RA-{booking.Id:N}";
        
        string qrCodeUrl = $"https://qr.sepay.vn/img?" +
                           $"acc={bankAccount}&" +
                           $"bank={bankName}&" +
                           $"amount={booking.FinalPrice}&" +
                           $"des={description}&" +
                           $"template=qronly";
        
        var subCourtIds = bookingDetails.Select(x => x.SubCourtId).ToList();
        var subCourtName = await _dbContext.SubCourts
            .Where(x => subCourtIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, x => x.Name);
        return new Response.CreateBookingResponse
        {
            BookingId = booking.Id,
            BankName = bankName,
            BankAccount = bankAccount,
            TotalPrice = booking.FinalPrice,
            ExpiredAt = booking.ExpiresAt,
            Status = booking.Status,
            TotalSlots = bookingDetails.Count(),
            Items = bookingDetails.Select(x => new Response.BookingDetailItem
            {
                SubCourtId = x.SubCourtId,
                SubCourtName = subCourtName[x.SubCourtId],
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price
            }).ToList(),
            QrCodeUrl = qrCodeUrl
        };
    }
    public async Task<Response.CreateBookingResponse> CreateBookingByWallet(Request.CreateBookingRequest request)
    {
        var customerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Không tìm thấy thông tin của customer");
        }
        var customerId = Guid.Parse(customerIdClaim);

        var availableSlotsSubCourt = new Dictionary<Guid, List<Owner.Response.SlotResponse>>();
        foreach (var item in request.Items)
        {
            var availableSlots = await _ownerService.GetAvailableSlots(new Owner.Request.GetAvailableSlotsRequest()
            {
                SubCourtId = item.SubCourtId,
                Date = request.Date
            });
            
            availableSlotsSubCourt[item.SubCourtId] = availableSlots; 
        }
        
        // var now = DateTime.Now;
        var vnZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnZone);

        foreach (var item in request.Items)
        {
            var availableSlots = availableSlotsSubCourt[item.SubCourtId];
            foreach (var slot in item.Slots)
            {
                var systemSlot = availableSlots.FirstOrDefault(x =>
                    x.StartTime == slot.StartTime
                    && x.EndTime == slot.EndTime);

                if (systemSlot == null)
                {
                    throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} không tồn tại");
                }
            
                if(request.Date.ToDateTime(slot.StartTime) <= now)
                {
                    throw new Exception("Không được đặt sân trong quá khứ");
                };

                if (!systemSlot.IsAvailable)
                {
                    throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị đặt hoặc đã khóa");
                }
            }
        }
        
        var dateTime = new DateTimeOffset(request.Date.ToDateTime(TimeOnly.MinValue), TimeSpan.Zero);
        foreach (var item in request.Items)
        {
            var bookedSlots = await _dbContext.BookingDetails
                .Where(x =>
                    x.SubCourtId == item.SubCourtId &&
                    x.Date.Date == dateTime.Date &&
                    (x.Status == "Pending" || x.Status == "Banked"))
                .ToListAsync();
            foreach (var slot in item.Slots)
            {
                var conflict = bookedSlots.Any(b =>
                    b.StartTime < slot.EndTime &&
                    b.EndTime > slot.StartTime);
                if (conflict)
                {
                    throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị người khác đặt");
                }
            }
        }
        
        decimal totalPrice = 0;
        foreach (var item in request.Items)
        {
            var availableSlots = availableSlotsSubCourt[item.SubCourtId];
            
            totalPrice += item.Slots.Sum(slot =>
                availableSlots.First(x => 
                    x.StartTime == slot.StartTime &&
                    x.EndTime == slot.EndTime).Price);
        }
        //campain| hàm này hình như có vấn đề
        decimal finalPrice =  totalPrice;
        if (request.CampaignId != null)
        {
            var campaign = await _dbContext.Campaigns
                .Include(c => c.Courts)
                .FirstOrDefaultAsync(c =>
                    c.Id == request.CampaignId &&
                    c.Code == request.Code &&
                    c.StartDate <= request.Date.ToDateTime(TimeOnly.MinValue) &&
                    c.EndDate >= request.Date.ToDateTime(TimeOnly.MinValue));
            if (campaign == null)
            {
                throw new Exception("Campaign không tồn tại hoặc đã hết hạn");
            }

            if (campaign.UsedCount >= campaign.UsageLimit)
            {
                throw new Exception("Campaign đã hết lượt sử dụng");
            }

            if (totalPrice < campaign.MinBookingAmount)
            {
                throw new Exception($"Giá trị đơn hàng tối thiểu để dùng campaign là {campaign.MinBookingAmount}");
            }

            if (!campaign.IsGlobal)
            {
                var firstSubCourtId = request.Items.First().SubCourtId;
                var courtId = await _dbContext.SubCourts
                    .Where(x => x.Id == firstSubCourtId)
                    .Select(x => x.CourtId)
                    .FirstOrDefaultAsync();
                var campaignCourtIds = campaign.Courts.Select(x => x.CourtId).ToList();
                if (!campaignCourtIds.Contains(courtId))
                {
                    throw new Exception("Campaign này không áp dụng cho sân bạn đang đặt");
                }
            }

            var discountAmount = totalPrice * (campaign.DiscountPercent / 100m);
            if (discountAmount > campaign.MaxDiscountAmount)
            {
                discountAmount = campaign.MaxDiscountAmount;
            }

            finalPrice = totalPrice - discountAmount;
            if (finalPrice < 0) finalPrice = 0;
            campaign.UsedCount += 1;
            _dbContext.Campaigns.Update(campaign);
        }
        
        var booking = new Repository.Entity.Booking
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            TotalPrice = totalPrice,
            FinalPrice = finalPrice,
            Status = "Pending",
            ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(100),
            CampaignId = request.CampaignId,
        };

        var bookingDetails = new List<BookingDetail>();
        foreach (var item in request.Items)
        {
            var availableSlots = availableSlotsSubCourt[item.SubCourtId];
            bookingDetails.AddRange(item.Slots.Select(slot => new BookingDetail()
            {
                Id = Guid.NewGuid(),
                SubCourtId = item.SubCourtId,
                BookingId = booking.Id,
                Date = dateTime,
                StartTime = slot.StartTime,
                EndTime = slot.EndTime,
                Price = availableSlots.First(x =>
                    x.StartTime == slot.StartTime &&
                    x.EndTime == slot.EndTime).Price,
                Status = "Pending",
            }));
        }
        if (!await _walletService.ApartBanlanceFromWallet(customerId, finalPrice, "Payment"))
        {
            throw new Exception("Wallet apart balance failed");
        } 
//transaction
        booking.Status = "Banked";
        foreach (var item in bookingDetails)
        {
            item.Status = "Banked";
        }
        await _dbContext.Bookings.AddAsync(booking);
        await _dbContext.BookingDetails.AddRangeAsync(bookingDetails);

        var bookedSubCourtId = bookingDetails.FirstOrDefault()?.SubCourtId;
        var subCourt = await _dbContext.SubCourts
            .Include(sc => sc.Court)
                .ThenInclude(c => c.Owner)
            .FirstOrDefaultAsync(x => x.Id == bookedSubCourtId);

        if (subCourt?.Court?.Owner != null)
        {
            _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
            {
                UserId = subCourt.Court.Owner.UserId,
                Title = "Thanh toán thành công",
                Content = $"Khách hàng vừa thanh toán {finalPrice:N0}đ bằng số dư Ví RallyHub.",
                Type = Notification.Request.TypeNotification.BookingPaid,
                BookingId = booking.Id
            });
        }

        await _dbContext.SaveChangesAsync();
    
        var subCourtIds = bookingDetails.Select(x => x.SubCourtId).ToList();
        var subCourtName = await _dbContext.SubCourts
            .Where(x => subCourtIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, x => x.Name);
        return new Response.CreateBookingResponse
        {
            BookingId = booking.Id,
            TotalPrice = booking.FinalPrice,
            ExpiredAt = booking.ExpiresAt,
            Status = booking.Status,
            TotalSlots = bookingDetails.Count(),
            Items = bookingDetails.Select(x => new Response.BookingDetailItem
            {
                SubCourtId = x.SubCourtId,
                SubCourtName = subCourtName[x.SubCourtId],
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price
            }).ToList(),
        };
    }
    //owner xem thoong tini chi tiet cua customer du vo bookingDetailsId
    public async Task<Response.GetBookingDetailResponse> GetBookingDetail(Guid bookingDetailsId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
        if (ownerIdClaim == null)
        {
            throw new Exception("Không tìm thấy danh tính của Owner");
        }
        var ownerId = Guid.Parse(ownerIdClaim);
        var user = await _dbContext.Users
            .Include(x => x.Owner)
            .FirstOrDefaultAsync(x => x.Owner!.Id == ownerId);
        if (user == null)
        {
            throw new Exception("Không tìm thấy user trong hệ thống");
        }
        
        var bookingDetails = await _dbContext.BookingDetails
            .Where(x => 
                x.Id == bookingDetailsId && 
                x.Status == "Banked")
            .Select(x => new Response.GetBookingDetailResponse()
            {
                Name = x.Booking.Customer.User.PhoneNumber,
                PhoneNumber =  x.Booking.Customer.User.PhoneNumber,
                Gmail =  x.Booking.Customer.User.Email,
                SubCourtName = x.SubCourt.Name,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                
            })
            .FirstOrDefaultAsync();
            
        if (bookingDetails == null)
        {
            throw new Exception("Không tìm thấy đơn hàng cho slot này");
        }
        return bookingDetails;
    }
    public async Task<Response.BookingRefundResponse> BookingRefund (Guid bookingId)
    {
        var customerIdClaim = _httpContext.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Customer not found");
        }
        var customerId = Guid.Parse(customerIdClaim);
        var user = await _dbContext.Users
            .Include(x => x.Wallet)
            .FirstOrDefaultAsync(x => x.Customer!.Id == customerId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
       
        var booking = await _dbContext.Bookings
            .Include(x => x.BookingDetails)
                .ThenInclude(x => x.SubCourt)
                    .ThenInclude(x => x.Court)
                        .ThenInclude(c => c.Owner)
            .FirstOrDefaultAsync(x => x.Id == bookingId && x.CustomerId == customerId);
        if (booking == null)
        {
            throw new Exception("Booking not found or you do not have permission to refund this booking");
        }
        if (booking.Status == "Pending" || booking.Status == "Refund")
        {
            throw new Exception("Booking already refund");
        }
        if (booking.Status != "Banked")
        {
            throw new Exception($"Cannot refund booking with status {booking.Status}");
        }

        if (booking.BookingDetails == null || !booking.BookingDetails.Any())
        {
            throw new Exception("Booking details not found");
        }

        var earlierSlot = booking.BookingDetails.OrderBy(x => x.StartTime).First();
        var slotStartDateTime = earlierSlot.Date.Date.Add(earlierSlot.StartTime.ToTimeSpan());
        var refundDeadline = slotStartDateTime.AddMinutes(-(double)earlierSlot.SubCourt.Court.TimeRefundBefor!);
        
        if (DateTime.Now > refundDeadline)
        {
            throw new Exception("The refund deadline has passed according to the court's policy");
        }

        decimal balanceBefore = user.Wallet!.Balance;

        if (!await _walletService.AddBanlanceToWallet(user.Id, booking.FinalPrice, "Payment"))
        {
            throw new Exception("Error adding balance to wallet");
        }
        
        var transactionI = new Transaction.Request.CreateTransactionRequest()
        {
            Type = Transaction.Request.TypeList.Refund,
            Amount = booking.FinalPrice,
            BalanceBefore = balanceBefore,
            BalanceAfter = balanceBefore + booking.FinalPrice,
            Status = "Success",
            WalletId =  user.Wallet!.Id,
        };
        if (!await _transactionService.CreateTransaction(transactionI))
        {
            throw new Exception("Error creating transaction");
        }

        booking.Status = "Refund";
        booking.UpdatedAt = DateTimeOffset.UtcNow;

        foreach (var details in booking.BookingDetails)
        {
            details.Status = "Cancelled";
            details.UpdatedAt = DateTimeOffset.UtcNow;
        }

        var ownerUserId = booking.BookingDetails.FirstOrDefault()?.SubCourt?.Court?.Owner?.UserId;
        if (ownerUserId != null)
        {
            _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
            {
                UserId = ownerUserId.Value,
                Title = "Hoàn tiền cho khách hàng",
                Content = $"Hệ thống đã hủy lịch và hoàn tiền {booking.FinalPrice:N0}đ cho khách hàng.",
                Type = Notification.Request.TypeNotification.BookingRefunded,
                BookingId = booking.Id
            });
        }

        await _dbContext.SaveChangesAsync();
        // await _mailService.SendMail(new MailContent()
        // {
        //     To = user.Email,
        //     Subject = $"Welcom to Rallyhub",
        //     Body = $"Đã hoàn tiền thành công" + "\n"
        //         + $"{request.ImageUrl}"
        // });
        return new Response.BookingRefundResponse()
        {
            BookingId = booking.Id,
            Status = "Refund",
            RefundAmount = booking.FinalPrice,
            Message = "Hoàn tiền thành công"
        };
    }
    public async Task<string> CanCelBooking(Guid bookingId)
    {
        var customerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Customer not found");
        }
        var customerId = Guid.Parse(customerIdClaim);
       
        var pendingBooking = await _dbContext.Bookings
            .Include(x => x.BookingDetails)
            .FirstOrDefaultAsync(x => 
                x.Id == bookingId && 
                x.CustomerId == customerId
                && x.Status == "Pending");

        if (pendingBooking == null)
        {
            throw new Exception("Pending booking not found or you do not have permission to cancel this booking");
        }

        pendingBooking.Status = "Cancelled";
        pendingBooking.UpdatedAt = DateTimeOffset.UtcNow;

        if (pendingBooking.BookingDetails != null)
        {
            foreach(var slots in pendingBooking.BookingDetails)
            {
                slots.Status = "Cancelled";           
                slots.UpdatedAt = DateTimeOffset.UtcNow;
            }
        }
       
        await _dbContext.SaveChangesAsync();
        return "Booking cancelled successfully";
    }
    //customer xem tất cả các booking của nó
    public async Task<Base.Response.PageResult<Response.GetBookingResponse>> GetBooking(Base.Request.PagingDay2 pagingDay2)
    {
        var customerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Không tìm thấy danh tính của Customer");
        }
        var customerId = Guid.Parse(customerIdClaim);
        var user = await _dbContext.Users
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Customer!.Id == customerId);
        if (user == null)
        {
            throw new Exception("Không tìm thấy user trong hệ thống");
        }
        
        var booking = _dbContext.Bookings
            .Where(x => x.CustomerId == customerId);
        
        if (pagingDay2.Date != null)
        {
            booking = booking.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) == pagingDay2.Date);
        }

        booking = booking.OrderBy(x => 
                x.Status == "Pending" ? 1 :
                x.Status == "Banked" ? 2 :    
                x.Status == "Refund" ? 3 :
                x.Status == "Complete" ? 4 :
                x.Status == "Cancelled" ? 5 : 6) 
            .ThenBy(x => x.CreatedAt);
        var total = await booking.CountAsync();
        booking = booking
            .Skip((pagingDay2.PageIndex - 1) * pagingDay2.PageSize)
            .Take(pagingDay2.PageSize);
        var select = booking.Select(x => new Response.GetBookingResponse()
        {
            BookingId = x.Id,
            FinalPrice = x.FinalPrice,
            Status = x.Status,
            CourtName = x.BookingDetails.First().SubCourt.Name,
            Address = x.BookingDetails.First().SubCourt.Court.Address,
            PhoneNumber =  x.BookingDetails.First().SubCourt.Court.Owner.User.PhoneNumber!,
            UrlMap = x.BookingDetails.First().SubCourt.Court.MapUrl,
            SlotsResponses = x.BookingDetails.Select(x => new Response.SlotsResponse
            {
                SlotId = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price,
                Date = x.Date,
            }).ToList(),
            
        });
        var list = await  select.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetBookingResponse>()
        {
            Items = list,
            PageIndex = pagingDay2.PageIndex,
            PageSize = pagingDay2.PageSize,
            TotalItems = total
        };

        return result;
    }
}