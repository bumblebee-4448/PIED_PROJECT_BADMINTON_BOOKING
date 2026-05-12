using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
namespace Rallyhub.Service.Booking;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContext;
    private readonly Wallet.IService _walletService;
    private readonly Transaction.IService _transactionService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext, Wallet.IService walletService, Transaction.IService transactionService)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
        _walletService = walletService;
        _transactionService = transactionService;
    }
    
     public async Task<List<Response.SlotResponse>> GetAvailableSlots(Request.GetAvailableSlotsRequest request)
    {
         var subCourt = await _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefaultAsync(x => 
                x.Id == request.SubCourtId && 
                x.Court.Status == "Active");
        if (subCourt == null)
            throw new Exception("Sân con không tồn tại");
        
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        
        var configSlots = await _dbContext.ConfigSlots
            .Where(x => x.SubCourtDetailId == request.SubCourtId)
            .OrderBy(x => x.StartTime)
            .ToListAsync();
        
        var overrides = await _dbContext.OverideSlots
            .Where(x => 
                x.SubCourtDetailId == request.SubCourtId &&
                ( 
                     (!x.IsRecurring && x.Date == request.Date) || 
                     (x.IsRecurring && x.DayOfWeek == request.Date.DayOfWeek)
                            
                )).ToListAsync();

        var exceptions = await  _dbContext.Exceptions
            .Where(x => 
                x.SubCourtDetailId == request.SubCourtId &&
                x.Date == request.Date)
            .ToListAsync();

        var result = configSlots.Select(x => new Response.SlotResponse
        {
            StartTime =  x.StartTime,
            EndTime =  x.EndTime,
            Price = x.Price,
            IsAvailable = true
        }).ToList();
        
        foreach (var ov in overrides)
        {
            result.RemoveAll(x => 
                x.StartTime >= ov.StartTime && 
                x.EndTime <= ov.EndTime);

            result.Add(new Response.SlotResponse
            {
                StartTime = ov.StartTime,
                EndTime = ov.EndTime,
                Price = ov.Price,
                IsAvailable = true
            });
        }
        
        foreach (var ex in exceptions)
        {
            var exceptionAdd = false;
            foreach (var slot in result.ToList())
            {
                var hasOverlap = slot.StartTime < ex.EndTime &&
                                 slot.EndTime > ex.StartTime;
                if (!hasOverlap) continue;
                result.Remove(slot);

                if (slot.StartTime < ex.StartTime)
                {
                    result.Add(new Response.SlotResponse
                    {
                        StartTime = slot.StartTime,
                        EndTime = ex.StartTime,
                        IsAvailable = true,
                        Price = slot.Price,
                    });
                }

                if (!exceptionAdd)
                {
                    result.Add(new Response.SlotResponse()
                    {
                        StartTime = ex.StartTime,
                        EndTime = ex.EndTime,
                        IsAvailable = false,
                        Reason = ex.Reason,
                    });
                    exceptionAdd = true;
                }

                if (slot.EndTime > ex.EndTime)
                {
                    result.Add(new Response.SlotResponse()
                    {
                        StartTime = ex.EndTime,
                        EndTime = slot.EndTime,
                        IsAvailable = true,
                        Price = slot.Price,
                    });
                }
            }
        }
        
        var bookedSlots = await _dbContext.BookingDetails
            .Where(x =>
                x.SubCourtId == request.SubCourtId &&
                x.Date.Date == request.Date.ToDateTime(TimeOnly.MinValue) && 
                (x.Status == "Pending" || x.Status == "Banked"))
            .ToListAsync();
        
        foreach (var slot in result)
        {
            if (!slot.IsAvailable) continue;
            var isBooked = bookedSlots.Any(b =>
                b.StartTime < slot.EndTime &&
                b.EndTime > slot.StartTime);
            if (isBooked)
            {
                slot.IsAvailable = false;
                slot.Reason = "Đã được khách đặt";
            }
        }
        return result.OrderBy(x => x.StartTime).ToList();
    }
    public async Task<Response.CreateBookingResponse> CreateBooking(Request.ListAvailableSlots request)
    {
        //thêm campaign
        var customerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Không tìm thấy thông tin của customer");
        }
        var customerId = Guid.Parse(customerIdClaim);

        var availableSlots = await GetAvailableSlots(new Request.GetAvailableSlotsRequest
        {
            SubCourtId = request.SubCourtId,
            Date = request.Date
        });
        
        var now = DateTime.Now;
        foreach (var slot in request.Slots)
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
        
        var dateTime = new DateTimeOffset(request.Date.ToDateTime(TimeOnly.MinValue), TimeSpan.Zero);
        var bookedSlots = await _dbContext.BookingDetails
            .Where(x =>
                x.SubCourtId == request.SubCourtId &&
                x.Date.Date == dateTime.Date &&
                (x.Status == "Pending" || x.Status == "Banked")).ToListAsync();
        foreach (var slot in request.Slots)
        {
            var conflict = bookedSlots.Any(b =>
                b.StartTime < slot.EndTime &&
                b.EndTime > slot.StartTime);
            if (conflict)
            {
                throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị người khác đặt");
            }
        }
        
        var totalPrice = request.Slots.Sum(slot =>
            availableSlots.First(x => 
                x.StartTime == slot.StartTime &&
                x.EndTime == slot.EndTime).Price);
        //campain
        decimal finalPrice =  totalPrice;
        if (request.CampaignId != null)
        {
            var query = await _dbContext.Campaigns
                .FirstOrDefaultAsync(c => 
                    c.Id == request.CampaignId &&
                    c.Code == request.Code &&
                    c.StartDate <= request.Date.ToDateTime(TimeOnly.MinValue) &&
                    c.EndDate >= request.Date.ToDateTime(TimeOnly.MinValue));
            if (query != null)
            {
                throw new Exception("Campaign không tồn tại trong hệ thống");
            }

            finalPrice = totalPrice * (1 - query!.DiscountPercent / 100);
            if (finalPrice <= 0) finalPrice = 0;
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
        
        var bookingDetails = request.Slots.Select(slot => new Repository.Entity.BookingDetail
        {
            Id = Guid.NewGuid(),
            SubCourtId = request.SubCourtId,
            BookingId = booking.Id,
            Date = dateTime,
            StartTime = slot.StartTime,
            EndTime = slot.EndTime,
            Price = availableSlots.First(x =>
                x.StartTime == slot.StartTime &&
                x.EndTime == slot.EndTime).Price,
            Status = "Pending",
        }).ToList();
        
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
        
        return new Response.CreateBookingResponse
        {
            BookingId = booking.Id,
            TotalPrice = booking.FinalPrice,
            ExpiredAt = booking.ExpiresAt,
            Status = booking.Status,
            Slots = booking.BookingDetails.Select(x => new Response.BookingDetailItem
            {
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price
            }).ToList(),
            QrCodeUrl = qrCodeUrl
        };
    }

    public async Task<Response.CreateBookingResponse> CreateBookingByWallet(Request.ListAvailableSlots request)
    {
        var customerIdClaim = _httpContext.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Không tim thấy thông tin của Customer");
        }

        var customerId = Guid.Parse(customerIdClaim);
        var availableSlots = await GetAvailableSlots(new Request.GetAvailableSlotsRequest
        {
            SubCourtId = request.SubCourtId,
            Date = request.Date,
        });
        foreach (var slot in request.Slots)
        {
            var systemSlot = availableSlots.FirstOrDefault(x =>
                x.StartTime == slot.StartTime &&
                x.EndTime == slot.EndTime);
            if (systemSlot == null)
            {
                throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} không tồn tại");
            }

            if (!systemSlot.IsAvailable)
            {
                throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị đặt hoặc đã khóa");
            }
        }

        var dateTime = new DateTimeOffset(request.Date.ToDateTime(TimeOnly.MinValue), TimeSpan.Zero);
        var bookedSlots = await _dbContext.BookingDetails
            .Where(x =>
                x.SubCourtId == request.SubCourtId &&
                x.Date.Date == dateTime.Date &&
                (x.Status == "Pending" || x.Status == "Banked")).ToListAsync();
        foreach (var slot in request.Slots)
        {
            var conflict = bookedSlots.Any(b =>
                b.StartTime < slot.EndTime &&
                b.EndTime > slot.StartTime);
            if (conflict)
            {
                throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị người khác đặt");
            }
        }

        var totalPrice = request.Slots.Sum(slot =>
            availableSlots.First(x =>
                x.StartTime == slot.StartTime &&
                x.EndTime == slot.EndTime).Price);
        decimal finalPrice = totalPrice;
        if (request.CampaignId != null)
        {
            var query = await _dbContext.Campaigns
                .FirstOrDefaultAsync(c =>
                    c.Id == request.CampaignId &&
                    c.Code == request.Code &&
                    c.StartDate <= request.Date.ToDateTime(TimeOnly.MinValue) &&
                    c.EndDate >= request.Date.ToDateTime(TimeOnly.MinValue));
            if (query != null)
            {
                throw new Exception("Campaign không tồn tại trong hệ thống");
            }

            finalPrice = totalPrice * (1 - query!.DiscountPercent / 100);
            if (finalPrice <= 0) finalPrice = 0;
        }

        var booking = new Repository.Entity.Booking
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            TotalPrice = totalPrice,
            FinalPrice = finalPrice,
            Status = "Pending",
            CampaignId = request.CampaignId,
        };

        var bookingDetails = request.Slots.Select(slot => new Repository.Entity.BookingDetail
        {
            Id = Guid.NewGuid(),
            SubCourtId = request.SubCourtId,
            BookingId = booking.Id,
            Date = dateTime,
            StartTime = slot.StartTime,
            EndTime = slot.EndTime,
            Price = availableSlots.First(x =>
                x.StartTime == slot.StartTime &&
                x.EndTime == slot.EndTime).Price,
            Status = "Pending",
        }).ToList();
        if (!await _walletService.ApartBanlanceFromWallet(customerId, finalPrice, "Payment"))
        {
            throw new Exception("Wallet apart balance failed");
        } 
//transaction
        booking.Status = "Banked";
        await _dbContext.Bookings.AddAsync(booking);
        await _dbContext.BookingDetails.AddRangeAsync(bookingDetails);
        await _dbContext.SaveChangesAsync();

        return new Response.CreateBookingResponse
        {
            BookingId = booking.Id,
            TotalPrice = booking.FinalPrice,
            ExpiredAt = booking.ExpiresAt,
            Status = booking.Status,
            Slots = booking.BookingDetails.Select(x => new Response.BookingDetailItem
            {
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price
            }).ToList(),
        };
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
            .FirstOrDefaultAsync(x => x.Id == bookingId && x.CustomerId == customerId);
        if (booking.Status == "Pending" || booking.Status == "Refund")
        {
            throw new Exception("Booking already refund");
        }
        if (booking == null)
        {
            throw new Exception("Booking not found or you do not have permission to refund this booking");
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