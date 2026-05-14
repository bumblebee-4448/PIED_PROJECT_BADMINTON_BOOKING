using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using Quartz.Util;
using Rallyhub.Repository;
using Rallyhub.Service.MailService;
namespace Rallyhub.Service.Admin;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly MailService.IService _mailService;
    private readonly Transaction.IService _transactionService;
    private readonly IHttpContextAccessor _httpContext;  
    private readonly Wallet.IService _walletService;
    private readonly Transaction.IService _transaction;
    private readonly Notification.IService _notificationService;

    public Service(AppDbContext dbContext, MailService.IService mailService, Transaction.IService transactionService, IHttpContextAccessor httpContext,
        Wallet.IService walletService, Transaction.IService transaction, Notification.IService notificationService)
    {
        _dbContext = dbContext;
        _mailService = mailService;
        _transactionService = transactionService;
        _httpContext = httpContext;
        _walletService = walletService;
        _transaction = transaction;
        _notificationService = notificationService;
    }
//user
    public async Task<Base.Response.PageResult<Response.UserDto>> FilterUser(Request.FilterUserRequest request)
    {
        var getAllUser = _dbContext.Users.Where(x => x.Role != "Admin");
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            getAllUser = getAllUser.Where(x => 
                x.Email.Contains(request.Search) ||
                (x.PhoneNumber != null && x.PhoneNumber.Contains(request.Search)));
        }

        if (request.Id != null)
        {
            getAllUser = getAllUser.Where(x => x.Id == request.Id);
        }
        if (!string.IsNullOrWhiteSpace(request.Role))
        {
            getAllUser = getAllUser.Where(x => x.Role == request.Role);
        }
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            getAllUser = getAllUser.Where(x => x.Status == request.Status);
        }
        var toTalItems = await getAllUser.CountAsync();
        var sortName = getAllUser.OrderBy(x => x.FirstName);
        var pagedQuery = sortName
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);
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
    //CẦn CHECK LẠI
    public async Task<Response.UserDto> UserDetail(Request.UserDetailRequest request)
    {
        var user = await _dbContext.Users
            .Include(x => x.Customer)
            .Include(x => x.Owner)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user == null)
        {
            throw new Exception("user không tồn tại");
        }

        if (user.Role == "Customer")
        {
            if(user.Customer == null) throw new Exception("Customer không tồn tại");
            var bookings = _dbContext.Bookings
                .Where(x => x.CustomerId == user.Customer.Id);
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

        if (user.Role == "Owner")
        {
            if(user.Owner == null) throw new Exception("Owner không tồn tại");
            var courts = _dbContext.Courts
                .Where(x => 
                    x.OwnerId == user.Owner.Id);
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
                BusinessLicenseUrl = user.Owner.BusinessLicenseUrl,
                IdentityNumber = user.Owner.IdentityNumber,
                IdentityCardFrontUrl = user.Owner.IdentityCardFrontUrl,
                IdentityCardBackUrl = user.Owner.IdentityCardBackUrl,
                Courts = resultCourtDto
            };
            return result;
        }
        throw new Exception("Không có quyền xem user ");
    }
    public async Task BanAndUnbanUser(Request.BanAndUnbanUserRequest request)
    {
        if (request.Status != "Banned" && 
            request.Status != "Active")
        {
            throw new Exception($"Không thể update status {request.Status}");
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user == null)
        {
            throw new Exception("User không tồn tại");
        }
        if (user.Role == "Customer")
        {
            if (user.Status == request.Status)
            {
                throw new Exception($"User đang có status {request.Status} không thể update sang {request.Status}");
            }
            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == request.Id);
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.UserId == request.Id);
            if (wallet != null && request.Status == "Banned")
            {
                wallet.IsDeleted = true;
                wallet.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Wallets.Update(wallet);
            }
            if (wallet != null && request.Status == "Active")
            {
                wallet.IsDeleted = false;
                wallet.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.Wallets.Update(wallet);
            }
            if (customer != null && request.Status == "Banned")
            {
                customer.IsDeleted = true;
                customer.UpdatedAt = DateTimeOffset.UtcNow;
                user.IsDeleted = true;
                _dbContext.Customers.Update(customer);
            }
            if (customer != null && request.Status == "Active")
            {
                customer.IsDeleted = false;
                customer.UpdatedAt = DateTimeOffset.UtcNow;
                user.IsDeleted = false;
                _dbContext.Customers.Update(customer);
            }
            user.Status = request.Status;
            user.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return;
        }
        if (user.Role == "Owner" && request.Status == "Banned")
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
        if (user.Role == "Owner" && request.Status == "Active")
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
//ownerRequest
    public async Task<Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>> AdminGetOwnerRequest(Base.Request.Pagination request)
    {
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
                x.BusinessName.Trim().ToLower().Contains(request.Search.Trim().ToLower()) ||
                x.BusinessAddress.Trim().ToLower().Contains(request.Search.Trim().ToLower()) ||
                x.IdentityNumber.Trim().ToLower().Contains(request.Search.Trim().ToLower()) ||
                x.TaxCode.Trim().ToLower().Contains(request.Search.Trim().ToLower()));
        }

        var total = await query.CountAsync();

        query = query.OrderBy(x => x.CreatedAt);
        query = query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);

        var selectOwnerRequest = query.Select(x => new Response.AdminGetOwnerRequestResponse()
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

        var listOwnerRequest = await selectOwnerRequest.ToListAsync();

        var result = new Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>()
        {
            Items = listOwnerRequest,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = total,
        };
        return result;
    }
    public async Task<string> AdminApprovedOwnerRequest(Guid ownerRequestId)
    {
        var query = await _dbContext.OwnerRequests
            .Include(ownerRequest => ownerRequest.Customer)
            .FirstOrDefaultAsync(x => x.Id == ownerRequestId);
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
        query.Status = "Approved";
        query.UpdatedAt = DateTimeOffset.UtcNow;
        var userId = query.Customer.UserId;
        var queryUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        queryUser!.Role = "Owner";
        _dbContext.Owners.Add(newOwner);
        var customerId = query.Customer.Id;
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
        // _dbContext.Customers.Remove(customer!);
        var result = await _dbContext.SaveChangesAsync();
        //gửi mail
        var subject = "Người tình trong mộng Ralluhub";
        var bodyMail = "Hồ sơ đăng ký làm chủ sân cầu lông của bạn đã được ban quản trị xét duyệt thành công.<br>" +
                       "Ngay bây giờ, bạn đã có thể đăng nhập vào hệ thống quản lý của rallyhub để thiết lập giá sân, lịch hoạt động và đón những vị khách đầu tiên.";
        await _mailService.SendMail(new MailContent()
        {
            To = newOwner.User.Email,
            Subject = subject,
            Body = MailTemplate.GenerateApprovalTemplate(newOwner.User.Email, bodyMail),
        });

        _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
        {
            UserId = newOwner.UserId,
            Title = "Yêu cầu đối tác được duyệt",
            Content = "Hồ sơ đăng ký làm chủ sân cầu lông của bạn đã được ban quản trị xét duyệt thành công.",
            Type = Notification.Request.TypeNotification.OwnerRequestApproved,
            OwnerRequestId = query.Id
        });
        await _dbContext.SaveChangesAsync();
        
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }
    public async Task<string> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason)
    {
        var query = await _dbContext.OwnerRequests
            .Include(ownerRequest => ownerRequest.Customer)
            .FirstOrDefaultAsync(x => x.Id == ownerRequestId);
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
        //gửi mail
        var subject = "Người tình trong mộng RallyHub";
        var bodyMail = "Cảm ơn bạn đã gửi hồ sơ đăng ký đối tác cho rallyhub.<br>" +
                       "Tuy nhiên, sau khi xem xét, chúng tôi chưa thể duyệt hồ sơ của bạn vào lúc này.";
        await _mailService.SendMail(new MailContent()
        {
            To = query.Customer.User.Email,
            Subject = subject,
            Body = MailTemplate.GenerateRejectionTemplate(query.Customer.User.Email, bodyMail, rejectReason),
        });

        _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
        {
            UserId = query.Customer.UserId,
            Title = "Yêu cầu đối tác bị từ chối",
            Content = $"Hồ sơ đăng ký của bạn không được duyệt. Lý do: {rejectReason}",
            Type = Notification.Request.TypeNotification.OwnerRequestRejected,
            OwnerRequestId = query.Id
        });
        await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }
//court
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
    public async Task<Base.Response.PageResult<Response.AdminGetPendingCourtsResponse>> AdminGetPendingCourts (Base.Request.Pagination request)
    {  
        var query = _dbContext.Courts
            .Include(x => x.Owner)
            .Where(x => x.Status == "Pending");
        if (request.Id != null)
        {
            query = query.Where(x => x.Id == request.Id);
        }
        if (request.Search != null)   
        {        
            query = query.Where(x =>   
                x.Name.Trim().ToLower()  
                    .Contains(request.Search.Trim().ToLower()));  
        }    
        var totalItems = await query.CountAsync();  
            query = query.OrderBy(x => x.Name);  
            query = query
                .Skip((request.PageIndex - 1) * request.PageSize)  
                .Take(request.PageSize);  
      
        var result = query.Select(x => new Response.AdminGetPendingCourtsResponse()  
        {  
            CourtId =  x.Id,  
            OwnerId =  x.OwnerId,  
            OwnerName = x.Owner.BusinessName,
            Name = x.Name,  
            Status = x.Status,  
            Address = x.Address,
            OpenTime = x.OpenTime,
            CloseTime = x.CloseTime,
            PictureUrl = x.PictureUrl,
        });  
        var listResult = await result.ToListAsync();  
        return new Base.Response.PageResult<Response.AdminGetPendingCourtsResponse>()  
        {  
            Items = listResult,  
            PageIndex = request.PageIndex,  
            PageSize = request.PageSize,  
            TotalItems = totalItems,  
        };  
    }  
    public async Task<string> AdminApprovePendingCourt(Guid courtId) 
    {  
        var court = await _dbContext.Courts
            .Include(x => x.Owner.User)
            .FirstOrDefaultAsync(x => x.Id == courtId);  
        if (court == null)  
        {        
            throw new Exception("Error 500");  
        }  
        if (court.Status != "Pending")  
        {        
            throw new Exception("Error 500");  
        }        
        court.Status = "Active";  
        court.UpdatedAt = DateTimeOffset.UtcNow;
        int result = await _dbContext.SaveChangesAsync();  
        string htmlBody = MailTemplate.ApproveCourtTemplate(court.Owner.User.Email, court.Name);
        await _mailService.SendMail(new MailContent
        {
            To = court.Owner.User.Email,
            Subject = "Approved court",
            Body = htmlBody,
        });

        _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
        {
            UserId = court.Owner.UserId,
            Title = "Sân đã được duyệt",
            Content = $"Sân {court.Name} của bạn đã được ban quản trị xét duyệt và hiện đang hoạt động.",
            Type = Notification.Request.TypeNotification.CourtApproved,
            CourtId = court.Id
        });
        await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }  
    public async Task<string> AdminRejectPendingCourt(Guid courtId, string? rejectReason)  
    {  
        var court = await _dbContext.Courts
            .Include(x => x.Owner.User)
            .FirstOrDefaultAsync(x => x.Id == courtId);  
        if (court == null)  
        {        
            throw new Exception("Error 500");  
        }  
        if (court.Status != "Pending")  
        {        
            throw new Exception("Error 500");  
        }        
        court.Status = "InActive";          
        court.UpdatedAt = DateTimeOffset.UtcNow;
        var result = await _dbContext.SaveChangesAsync();  
        string htmlBody = MailTemplate.RejectCourtTemplate(court.Owner.User.Email, court.Name, rejectReason!);
        // Console.WriteLine(court.Owner.User.Email);
        await _mailService.SendMail(new MailContent
        {
            To = court.Owner.User.Email,
            Subject = "Rejected court", 
            Body = htmlBody,
        });  

        _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
        {
            UserId = court.Owner.UserId,
            Title = "Sân bị từ chối duyệt",
            Content = $"Sân {court.Name} của bạn không được duyệt. Lý do: {rejectReason}",
            Type = Notification.Request.TypeNotification.CourtRejected,
            CourtId = court.Id
        });
        await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }
    
    public async Task<Response.GetWalletResponse> GetWallet(Request.GetWalletRequest request)
    {
        if(request.Email == null)
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
            BankAccountName = wallet.BankAccountName
        };
    }
    public async Task<string> AddBalanceToUser(Request.AddBalanceRequest request)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
        if (user == null)
        {
            throw new Exception("User not exsit");
        }
        if (request.Amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }
        
        var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == request.UserId);
        if (wallet == null)
        {
            throw new Exception("Not found wallet");
        }

        wallet.Balance += request.Amount;
        wallet.Version += 1;
        wallet.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.Wallets.Update(wallet);

        //add transaction
        
        try
        {
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
                {
                    UserId = request.UserId,
                    Title = "Ví đã được cộng tiền",
                    Content = $"Quản trị viên đã cộng {request.Amount:N0}đ vào ví của bạn.",
                    Type = Notification.Request.TypeNotification.WalletDepositSuccess
                });
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            return "Fail";
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new Exception("The system is processing another transaction on this wallet. Please try again later.");
        }


    }
    public async Task<List<Response.GetBookingDetailStatusRefundPendingResponse>> GetBookingDetailStatusRefundPending()
    {
        var bookingDetailStatusRefundPending = _dbContext.BookingDetails
            .Include(x => x.Booking)
            .Where(x => x.Status == "RefundPending");
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