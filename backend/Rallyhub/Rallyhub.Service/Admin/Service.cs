using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using Quartz.Util;
using Rallyhub.Repository;
using Rallyhub.Service.MailService;
using StatusCreateCourt = Rallyhub.Service.Enum.Enum.StatusCreateCourt;
namespace Rallyhub.Service.Admin;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly MailService.IService _mailService;

    public Service(AppDbContext dbContext, MailService.IService mailService)
    {
        _dbContext = dbContext;
        _mailService = mailService;
    }

    public async Task<Base.Response.PageResult<Response.UserDto>>
        FilterUser(Request.FilterUserRequest request)
    {
        var getAllUser = _dbContext.Users.Where(x => x.Role != Enum.Enum.Role.Admin.ToString());

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            getAllUser = getAllUser.Where(x => x.Email.Contains(request.Search) ||
                                               (x.PhoneNumber != null && x.PhoneNumber.Contains(request.Search)));
        }
        if (request.Id.HasValue)
        {
            getAllUser = getAllUser.Where(x => x.Id == request.Id);
        }
        if (request.Role.HasValue)
        {
            getAllUser = getAllUser.Where(x => x.Role == request.Role.ToString());
        }
        if (request.Status.HasValue)
        {
            getAllUser = getAllUser.Where(x => x.Status == request.Status.ToString());
        }
        var toTalItems = await getAllUser.CountAsync();
        if (toTalItems < 1)
        {
            return new Base.Response.PageResult<Response.UserDto>()
            {
                Items = [],
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalItems = toTalItems,
            };
        }
        var sortName = getAllUser.OrderBy(x => x.FirstName);
        var pagedQuery = sortName.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pagedQuery.Select(x => new Response.UserDto()
        {
            Id  = x.Id,
            Email = x.Email,
            Role = x.Role,
            FirstName =  x.FirstName,
            LastName =  x.LastName,
            PhoneNumber = x.PhoneNumber,
            AvatarUrl = x.AvatarUrl,
            Status = x.Status,
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.UserDto>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = toTalItems,
        };
        return result;
    }

    public async Task<Response.UserDto> UserDetail(Request.UserDetailRequest request)
    {
        var user = await _dbContext.Users
            .Include(x => x.Customer)
            .Include(x => x.Owner).FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user == null)
        {
            throw new Exception("user không tồn tại");
        }

        if (user.Role == Enum.Enum.Role.Customer.ToString())
        {
            if(user.Customer == null) throw new Exception("Customer không tồn tại");
            var bookings = _dbContext.Bookings.Where(x => x.CustomerId == user.Customer.Id);
            var bookingDto = bookings.Select(x => new Response.BookingDto()
            {
                Id = x.Id,
                TotalPrice = x.TotalPrice,
                DiscountAmount =  x.DiscountAmount,
                FinalPrice =  x.FinalPrice,
                Status =  x.Status,
                CancellationReason =   x.CancellationReason,
            });
            var resultBookingDto = await bookingDto.ToListAsync();
            var result = new Response.CustomerDto()
            {
                Id =  user.Id,
                Email = user.Email,
                Role = user.Role,
                FirstName =  user.FirstName,
                LastName =  user.LastName,
                PhoneNumber = user.PhoneNumber,
                AvatarUrl = user.AvatarUrl,
                Status = user.Status,
                Bookings = resultBookingDto
            };
            return result;
        }

        if (user.Role == Enum.Enum.Role.Owner.ToString())
        {
            if(user.Owner == null) throw new Exception("Owner không tồn tại");
            var courts = _dbContext.Courts.Where(x => x.OwnerId == user.Owner.Id);
            var courtDto = courts.Select(x => new Response.CourtDto()
            {
                Id =  x.Id,
                Name = x.Name,
                Address = x.Address,
                OpenTime = x.OpenTime,
                CloseTime = x.CloseTime,
                Status = x.Status,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                MapUrl = x.MapUrl,
            });
            var resultCourtDto =  await courtDto.ToListAsync();
            var result = new Response.OwnerDto()
            {
                Id =   user.Id,
                Email = user.Email,
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                AvatarUrl = user.AvatarUrl,
                Status = user.Status,
                BusinessAddress = user.Owner.BusinessAddress,
                BusinessName = user.Owner.BusinessName,
                TaxCode = user.Owner.TaxCode,
                Courts = resultCourtDto
            };
            return result;
        }
        throw new Exception("Không có quyền xem user admin");
    }
    
    public async Task<Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>> AdminGetOwnerRequest(Base.Request.Pagination request)
    {
        //Customer và User để lấy thông tin cá nhân
        var query = _dbContext.OwnerRequests
            .Include(x => x.Customer)
            .ThenInclude(c => c.User)
            .Where(x => x.Status == "Pending");

        if (request.Id != null)
        {
            query = query.Where(x => x.CustomerId == request.Id);
        }

        if (request.Search != null)
        {
            query = query.Where(x => 
                x.BusinessName.Contains(request.Search) ||
                x.BusinessAddress.Contains(request.Search) ||
                x.IdentityNumber.Contains(request.Search) ||
                x.TaxCode.Contains(request.Search));
        }

        var total = await query.CountAsync();

        query = query.OrderBy(x => x.CreatedAt);
        query = query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);

        var selectOwenerRequest = query.Select(x => new Response.AdminGetOwnerRequestResponse()
        {
            Id = x.Id,
            UserId = x.Customer.UserId,
            CustomerId = x.CustomerId,
            BusinessName = x.BusinessName,
            TaxCode = x.TaxCode,
            BusinessAddress = x.BusinessAddress,
            BusinessLicenseUrl = x.BusinessLicenseUrl,
            IdentityNumber = x.IdentityNumber,
            IdentityCardFrontUrl = x.IdentityCardFrontUrl,
            IdentityCardBackUrl = x.IdentityCardBackUrl,
            Status = x.Status,
            CreatedAt = x.CreatedAt,
            // Thông tin customer từ User entity
            FirstName = x.Customer.User.FirstName,
            LastName = x.Customer.User.LastName,
            Email = x.Customer.User.Email,
            PhoneNumber = x.Customer.User.PhoneNumber,
            AvatarUrl = x.Customer.User.AvatarUrl,
        });

        var listOwnerRequest = await selectOwenerRequest.ToListAsync();

        var result = new Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>()
        {
            Items = listOwnerRequest,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = total,
        };
        return result;
    }

    public async Task<string> AdminAcceptOwnerRequest(Guid ownerRequestId)
    {
        var query = await _dbContext.OwnerRequests.Include(ownerRequest => ownerRequest.Customer).FirstOrDefaultAsync(x => x.Id == ownerRequestId);
        if (query!.Status != "Pending")
        {
            throw new Exception("Error 500");
        }
        if (query.OwnerId != null)
        {
            throw new Exception("Error 500");
        }

        var newOwner = new Repository.Entity.Owner()
        {
            UserId = query.Customer.UserId,
            BusinessName = query.BusinessName,
            TaxCode = query.TaxCode,
            BusinessAddress = query.BusinessAddress,
            BusinessLicenseUrl = query.BusinessLicenseUrl,
            IdentityNumber = query.IdentityNumber,
            IdentityCardFrontUrl = query.IdentityCardFrontUrl,
            IdentityCardBackUrl = query.IdentityCardBackUrl,
            CreatedAt = DateTimeOffset.UtcNow,
        };
        query.Status = "Accept";
        query.UpdatedAt = DateTimeOffset.UtcNow;
        var userId = query.Customer.UserId;
        var queryUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        queryUser!.Role = "Owner";
        _dbContext.Owners.Add(newOwner);
        var customerId = query.Customer.Id;
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
        // _dbContext.Customers.Remove(customer!);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }

    public async Task<string> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason)
    {
        var query = await _dbContext.OwnerRequests.Include(ownerRequest => ownerRequest.Customer).FirstOrDefaultAsync(x => x.Id == ownerRequestId);
        if (query!.Status != "Pending")
        {
            throw new Exception("Error 500");
        }
        if (query.OwnerId != null)
        {
            throw new Exception("Error 500");
        }
        query.Status = "Reject";
        query.RejectionReason = rejectReason;
        query.UpdatedAt = DateTimeOffset.UtcNow;
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }

    public async Task DeleteCourt(Guid id)
    {
        var court = await  _dbContext.Courts.FirstOrDefaultAsync(x => x.Id == id);
        if (court == null)
        {
            throw new Exception("Không tìm thấy sân");
        }
        _dbContext.Courts.Remove(court);
        await _dbContext.SaveChangesAsync();
    }
    public async Task BanAndUnbanUser(Request.BanAndUnbanUserRequest request)
    {
        if (request.Status != Enum.Enum.StatusUsers.Banned.ToString() && 
            request.Status != Enum.Enum.StatusUsers.Active.ToString())
        {
            throw new Exception($"Không thể update status {request.Status}");
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user == null)
        {
            throw new Exception("User không tồn tại");
        }
        if (user.Role == Enum.Enum.Role.Customer.ToString())
        {
            if (user.Status == request.Status)
            {
                throw new Exception($"User đang có status {request.Status} không thể update sang {request.Status}");
            }
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == request.Id);
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.UserId == request.Id);
            if (wallet != null && request.Status == Enum.Enum.StatusUsers.Banned.ToString())
            {
                wallet.IsDeleted = true;
                wallet.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Wallets.Update(wallet);
            }
            if (wallet != null && request.Status == Enum.Enum.StatusUsers.Active.ToString())
            {
                wallet.IsDeleted = false;
                wallet.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Wallets.Update(wallet);
            }
            if (customer != null && request.Status == Enum.Enum.StatusUsers.Banned.ToString())
            {
                customer.IsDeleted = true;
                customer.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Customers.Update(customer);
            }
            if (customer != null && request.Status == Enum.Enum.StatusUsers.Active.ToString())
            {
                customer.IsDeleted = false;
                customer.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Customers.Update(customer);
            }
            user.Status = request.Status;
            user.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return;
        }
        if (user.Role == Enum.Enum.Role.Owner.ToString() && request.Status == Enum.Enum.StatusUsers.Banned.ToString())
        {
            if (user.Status == request.Status)
            {
                throw new Exception($"User đang có status {request.Status} không thể update sang {request.Status}");
            }
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == request.Id);
            if (wallet != null)
            {
                wallet.IsDeleted = true;
                wallet.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Wallets.Update(wallet);
            }
            var owner = await _dbContext.Owners.FirstOrDefaultAsync(x => x.UserId == request.Id);
            if (owner == null)
            {
                throw new Exception("Không tìm thấy owner");
            }
            var courtList = await _dbContext.Courts.Where(x => x.OwnerId == owner.Id).ToListAsync();
            if (!courtList.Any())
            {
                user.Status = request.Status;
                user.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return;
            }
            foreach (var court in courtList)
            {
                var likeListDetail = await _dbContext.LikeListDetails.Where(x => x.CourtId == court.Id).ToListAsync();
                if (likeListDetail.Any())
                {
                    foreach (var item in likeListDetail)
                    {
                        item.IsDeleted = true;
                        item.UpdatedAt =  DateTimeOffset.UtcNow;
                    }
                    _dbContext.LikeListDetails.UpdateRange(likeListDetail);
                }
                var campaignCourt = await _dbContext.CampaignCourts.Where(x => x.CourtId == court.Id).ToListAsync();
                if (campaignCourt.Any())
                {
                    var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignCourt[0].CampaignId);
                    if (campaign != null)
                    {
                        campaign.IsDeleted = true;
                        campaign.UpdatedAt = DateTimeOffset.UtcNow;
                        _dbContext.Campaigns.Update(campaign);
                    }
                    
                    foreach (var item in campaignCourt)
                    {
                        item.IsDeleted = true;
                    }
                    _dbContext.CampaignCourts.UpdateRange(campaignCourt);
                }
                var subCourtList = await _dbContext.SubCourts.Where(x => x.CourtId == court.Id).ToListAsync();
                if (subCourtList.Any())
                {
                    foreach (var subCourt in subCourtList)
                    {
                        var exceptionList = await _dbContext.Exceptions.Where(x => x.SubCourtDetailId == subCourt.Id).ToListAsync();
                        if (exceptionList.Any())
                        {
                            foreach (var item in exceptionList)
                            {
                                item.IsDeleted = true;
                                item.UpdatedAt =  DateTimeOffset.UtcNow;
                            }
                            _dbContext.Exceptions.UpdateRange(exceptionList);
                        }
                        var configSlotList = await _dbContext.ConfigSlots.Where(x => x.SubCourtDetailId == subCourt.Id).ToListAsync();
                        if (configSlotList.Any())
                        {
                            foreach (var item in configSlotList)
                            {
                                item.IsDeleted = true;
                                
                            }
                            _dbContext.ConfigSlots.UpdateRange(configSlotList);
                        }
                        var overrideSlotList = await _dbContext.OverideSlots.Where(x => x.SubCourtDetailId ==  subCourt.Id).ToListAsync();
                        if (overrideSlotList.Any())
                        {
                            foreach (var item in overrideSlotList)
                            {
                                item.IsDeleted = true;
                                item.UpdatedAt =  DateTimeOffset.UtcNow;
                            }
                            _dbContext.OverideSlots.UpdateRange(overrideSlotList);
                        }
                        subCourt.IsDeleted = true;
                        subCourt.UpdatedAt = DateTimeOffset.UtcNow;
                        _dbContext.SubCourts.Update(subCourt);
                    }
                }
                court.IsDeleted = true;
                court.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Courts.Update(court);
            }
            owner.IsDeleted = true;
            user.Status = request.Status;
            user.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return;
        }
        if (user.Role == Enum.Enum.Role.Owner.ToString() && request.Status == Enum.Enum.StatusUsers.Active.ToString())
        {
            if (user.Status == request.Status)
            {
                throw new Exception($"User đang có status {request.Status} không thể update sang {request.Status}");
            }
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == request.Id);
            if (wallet != null)
            {
                wallet.IsDeleted = false;
                wallet.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Wallets.Update(wallet);
            }
            var owner = await _dbContext.Owners.FirstOrDefaultAsync(x => x.UserId == request.Id);
            if (owner == null)
            {
                throw new Exception("Không tìm thấy owner");
            }
            var courtList = await _dbContext.Courts.Where(x => x.OwnerId == owner.Id).ToListAsync();
            if (!courtList.Any())
            {
                user.Status = request.Status;
                user.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return;
            }
            foreach (var court in courtList)
            {
                var likeListDetail = await _dbContext.LikeListDetails.Where(x => x.CourtId == court.Id).ToListAsync();
                if (likeListDetail.Any())
                {
                    foreach (var item in likeListDetail)
                    {
                        item.IsDeleted = false;
                        item.UpdatedAt = DateTimeOffset.UtcNow;
                    }
                    _dbContext.LikeListDetails.UpdateRange(likeListDetail);
                }
                var campaignCourt = await _dbContext.CampaignCourts.Where(x => x.CourtId == court.Id).ToListAsync();
                if (campaignCourt.Any())
                {
                    var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignCourt[0].CampaignId);
                    if (campaign != null)
                    {
                        campaign.IsDeleted = false;
                        campaign.UpdatedAt = DateTimeOffset.UtcNow;
                        _dbContext.Campaigns.Update(campaign);
                    }
                    foreach (var item in campaignCourt)
                    {
                        item.IsDeleted = false;
                        item.UpdatedAt = DateTimeOffset.UtcNow;
                    }
                    _dbContext.CampaignCourts.UpdateRange(campaignCourt);
                }
                var subCourtList = await _dbContext.SubCourts.Where(x => x.CourtId == court.Id).ToListAsync();
                if (subCourtList.Any())
                {
                    foreach (var subCourt in subCourtList)
                    {
                        var exceptionList = await _dbContext.Exceptions.Where(x => x.SubCourtDetailId == subCourt.Id).ToListAsync();
                        if (exceptionList.Any())
                        {
                            foreach (var item in exceptionList)
                            {
                                item.IsDeleted = false;
                                item.UpdatedAt = DateTimeOffset.UtcNow;
                            }
                            _dbContext.Exceptions.UpdateRange(exceptionList);
                        }
                        var configSlotList = await _dbContext.ConfigSlots.Where(x => x.SubCourtDetailId == subCourt.Id).ToListAsync();
                        if (configSlotList.Any())
                        {
                            foreach (var item in configSlotList)
                            {
                                item.IsDeleted = false;
                                item.UpdatedAt = DateTimeOffset.UtcNow;
                            }
                            _dbContext.ConfigSlots.UpdateRange(configSlotList);
                        }
                        var overrideSlotList = await _dbContext.OverideSlots.Where(x => x.SubCourtDetailId ==  subCourt.Id).ToListAsync();
                        if (overrideSlotList.Any())
                        {
                            foreach (var item in overrideSlotList)
                            {
                                item.IsDeleted = false;
                                item.UpdatedAt = DateTimeOffset.UtcNow;
                            }
                            _dbContext.OverideSlots.UpdateRange(overrideSlotList);
                        }
                        subCourt.IsDeleted = false;
                        subCourt.UpdatedAt = DateTimeOffset.UtcNow;
                        _dbContext.SubCourts.Update(subCourt);
                    }
                }
                court.IsDeleted = false;
                court.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Courts.Update(court);
                
            }
            owner.IsDeleted = false;
            user.Status = request.Status;
            user.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task<Base.Response.PageResult<Response.GetPendingCourtsResponse>> GetPendingCourts  
    (Request.GetPendingCourtsRequest request)  
{  
    if (request.PageIndex <= 0)  
    {        
        throw new ArgumentException("PageIndex must be greater than 0");  
    }  
    if (request.PageSize <= 0)  
    {        
        throw new ArgumentException("PageSize must be greater than 0");  
    }    
    var query = _dbContext.Courts.Where(x => x.Status == nameof(StatusCreateCourt.Pending));  
    if (!string.IsNullOrEmpty(request.Name))  
    {        query = query.Where(x =>   
            x.Name.Trim().ToLower()  
                .Contains(request.Name.Trim().ToLower()));  
    }    var totalItems = await query.CountAsync();  
    query = query.OrderBy(x => x.Name);  
    query = query        .Skip((request.PageIndex - 1) * request.PageSize)  
        .Take(request.PageSize);  
  
    var result = query.Select(x => new Response.GetPendingCourtsResponse()  
    {  
        CourtId =  x.Id,  
        OwnerId =  x.OwnerId,  
        Name = x.Name,  
        Status = x.Status,  
    });  
    var listResult = await result.ToListAsync();  
    return new Base.Response.PageResult<Response.GetPendingCourtsResponse>()  
    {  
        Items = listResult,  
        PageIndex = request.PageIndex,  
        PageSize = request.PageSize,  
        TotalItems = totalItems,  
    };  
}  
  
    public async Task ApprovePendingCourt(Guid courtId)  
    {  
        var court = await _dbContext.Courts
            .Include(x => x.Owner.User)
            .FirstOrDefaultAsync(x => x.Id == courtId);  
        if (court == null)  
        {        
            throw new Exception("Court not found");  
        }  
        if (court.Status != nameof(StatusCreateCourt.Pending))  
        {        
            throw new Exception("Cannot approve court");  
        }        
        court.Status = nameof(StatusCreateCourt.Active);  
        await _dbContext.SaveChangesAsync();  
        string htmlBody = MailTemplate.ApproveCourtTemplate(court.Owner.User.Email, court.Name);
        await _mailService.SendMail(new MailContent
        {
            To = court.Owner.User.Email,
            Subject = "Approved court",
            Body = htmlBody,
        });
    }  
  
    public async Task RejectPendingCourt(Guid courtId, Request.RejectPendingCourtsRequest request)  
    {  
        var court = await _dbContext.Courts
            .Include(x => x.Owner.User)
            .FirstOrDefaultAsync(x => x.Id == courtId);  
        if (court == null)  
        {        
            throw new Exception("Court not found");  
        }  
        if (court.Status != nameof(StatusCreateCourt.Pending))  
        {        
            throw new Exception("Cannot approve court");  
        }        
        court.Status = nameof(StatusCreateCourt.Inactive);  
        await _dbContext.SaveChangesAsync();  
        string htmlBody = MailTemplate.RejectCourtTemplate(court.Owner.User.Email, court.Name, request.Reason);
        // Console.WriteLine(court.Owner.User.Email);
        await _mailService.SendMail(new MailContent
        {
            To = court.Owner.User.Email,
            Subject = "Rejected court", 
            Body = htmlBody,
        });  
        
    }
    public async Task<Response.RefundResponse> Refund(Request.RefundRequest request)
    {
        var user = await _dbContext.Users.Include(x => x.Customer)
                                .FirstOrDefaultAsync(x => x.Customer!.Id == request.CustomerId);
        if (user == null)
        {
            throw new Exception("Không tìm thấy user");
        }
        var bookingDetail = await _dbContext.BookingDetails
                                .FirstOrDefaultAsync(x => x.Id == request.BookingDetailId);
        if (bookingDetail == null)
        {
            throw new Exception("Không tìm thấy  booking detail");
        }

        if (bookingDetail.Status == Enum.Enum.StatusBookingDetails.Refunded.ToString())
        {
            throw new Exception("Đã hoàn tiền rồi");
        }
        bookingDetail.Status = Enum.Enum.StatusBookingDetails.Refunded.ToString();
        bookingDetail.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.BookingDetails.Update(bookingDetail);
        await _dbContext.SaveChangesAsync();
        await _mailService.SendMail(new MailContent()
        {
            To = user.Email,
            Subject = $"Welcom to Rallyhub",
            Body = $"Đã hoàn tiền thành công" + "\n"
                + $"{request.ImageUrl}"
        });
        return new Response.RefundResponse()
        {
            Message = "Hoàn tiền thành công",
            ImageUrl = request.ImageUrl
        };
    }

    

    public async Task<Response.GetWalletResponse> GetWallet(Request.GetWalletRequest request)
    {
        if(request.Email == null || request.Email == "")
        {
            throw new Exception("Email không hợp lệ");
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null)
        {
            throw new Exception("User không tồn tại");
        }
        var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (wallet == null)
        {
            throw new Exception("User không có ví");
        }

        return new Response.GetWalletResponse()
        {
            BankName = wallet.BankName,
            BankAccount = wallet.BankAccount,
            Balance = wallet.Balance,
        };
    }
    public async Task<List<Response.GetBookingDetailStatusRefundPendingResponse>> GetBookingDetailStatusRefundPending()
    {
        var bookingDetailStatusRefundPending =
            _dbContext.BookingDetails.Include(x => x.Booking)
                .Where(x => x.Status == Enum.Enum.StatusBookingDetails.RefundPending.ToString());
        var selectQuery = bookingDetailStatusRefundPending
            .Select(x => new Response.GetBookingDetailStatusRefundPendingResponse()
            {
                BookingDetailId = x.Id,
                CustomerId = x.Booking.CustomerId,
                Email = x.Booking.Customer.User.Email,
                Status = x.Status,
                Price = x.Price
            });
        var result = await selectQuery.ToListAsync();
        return result;
    }
}