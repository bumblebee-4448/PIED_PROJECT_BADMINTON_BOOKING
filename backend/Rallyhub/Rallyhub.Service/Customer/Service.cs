using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Rallyhub.Service.MailService;
using Exception = System.Exception;

namespace Rallyhub.Service.Customer;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly MediaService.IService _mediaService;
    private readonly IHttpContextAccessor _httpContext;
    private readonly Rallyhub.Service.MailService.IService _mailService;

    public Service(AppDbContext dbContext, MediaService.IService mediaService, IHttpContextAccessor httpContext, MailService.IService mailService)
    {
        _dbContext = dbContext;
        _mediaService = mediaService;
        _httpContext = httpContext;
        _mailService = mailService;
    }

    public async Task<string> OwnerRequest(Request.OwnerRequestRequest request)
    {
        var userId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        var userIdGuid = Guid.Parse(userId!);
        var user = _dbContext.Users.FirstOrDefault(x => x.Id == userIdGuid);
    
        // var customer = _dbContext.Customers.FirstOrDefault(x => x.UserId == userIdGuid);
        var customerId =_httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var custmerIdGuild = Guid.Parse(customerId!);
        var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == custmerIdGuild);
    
        if (user?.FirstName != request.FirstName || user?.LastName != request.LastName)
        {
            throw new Exception($"Tên {request.FirstName} {request.FirstName} không khớp với tên của tài khoản này");
        }
        var isExistIdentityNumber = await _dbContext.OwnerRequests.AnyAsync(x => x.IdentityNumber == request.IdentityNumber);
        if (isExistIdentityNumber)
        {
            throw new Exception("Identity number already exists");
        }
        var ownerRequest = new OwnerRequest()
        {
            BusinessName = request.BusinessName,
            TaxCode = request.TaxCode,
            BusinessAddress = request.BusinessAddress,
            BusinessLicenseUrl = await _mediaService.UploadImageAsync(request.BusinessLicenseUrl),
            IdentityNumber = request.IdentityNumber,
            IdentityCardFrontUrl = await _mediaService.UploadImageAsync(request.IdentityCardFrontUrl),
            IdentityCardBackUrl = await _mediaService.UploadImageAsync(request.IdentityCardBackUrl),
            CreatedAt = DateTimeOffset.UtcNow,
            CustomerId = custmerIdGuild,
            Status = Enum.Enum.AllStatus.Pending.ToString(),
        };
        _dbContext.OwnerRequests.Add(ownerRequest);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 1)
        {
            return "Success";
        }
        return "Fail";
    }

    public async Task<Base.Response.PageResult<Response.GetOwnerRequestResponse>> GetOwnerRequest(Request.GetOwnerRequest request)
    {
        if(request.PageIndex < 1)
            throw new Exception("PageIndex must be greater than or equal to 1");
        var customerId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var customerIdGuild = Guid.Parse(customerId!);
        var ownerRequestQuery = _dbContext.OwnerRequests.Where(x => x.CustomerId == customerIdGuild);
        ownerRequestQuery = ownerRequestQuery.OrderBy(x => x.CreatedAt);
        ownerRequestQuery = ownerRequestQuery
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);
        var selectOwnerRequest = ownerRequestQuery.Select(x => new Response.GetOwnerRequestResponse()
        {
            Id =  x.Id,
            CustomerId = x.CustomerId,
            OwnerId = x.OwnerId,
            BusinessName = x.BusinessName,
            TaxCode = x.TaxCode,
            BusinessAddress = x.BusinessAddress,
            BusinessLicenseUrl = x.BusinessLicenseUrl,
            IdentityNumber = x.IdentityNumber,
            IdentityCardFrontUrl = x.IdentityCardFrontUrl,
            IdentityCardBackUrl = x.IdentityCardBackUrl,
            Status = x.Status,
            RejectionReason = x.RejectionReason,
            CreatedAt =  x.CreatedAt,
        });

        var listResult = await selectOwnerRequest.ToListAsync();
        var totalCount = listResult.Count;
        var result = new Base.Response.PageResult<Response.GetOwnerRequestResponse>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = totalCount,
        };
        return result;
    }

    public async Task<bool> CheckCancelBooking(Request.CancelBooking request)
    {
        var getCustomerId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var customerId = Guid.Parse(getCustomerId!);
        var bookingDetail = await _dbContext.BookingDetails.Include(x => x.Booking)
                                                .FirstOrDefaultAsync(x => x.Id == request.BookingDetailId &&
                                                                                        x.Booking.CustomerId == customerId);
        if (bookingDetail == null)
        {
            throw new Exception("Không tìm thấy");
        }
        var timeCurrent = DateTime.Now; 
        var bookingDateTime = bookingDetail.Date.Date.Add(bookingDetail.StartTime.ToTimeSpan());
        var timeRemaining = bookingDateTime - timeCurrent;
        if (timeRemaining < TimeSpan.FromHours(2))
        {
            return false; 
        }
        return true; 
    }
    public async Task CancelBooking(Request.CancelBooking request)
    {
        var getCustomerId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var customerId = Guid.Parse(getCustomerId!);
        var checkCancelBooking = await CheckCancelBooking(request);
        if (checkCancelBooking)
        {
            var user = await _dbContext.Users.Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Customer!.Id == customerId);
            await _mailService.SendMail(new MailContent()
            {
                To = user.Email,
                Subject = "Welcom to Rallyhub",
                Body = "Tiền sẽ được hoàn từ 3 - 5 ngày tính từ lúc hủy"
            });
            var bookingDetail = await _dbContext.BookingDetails
                                                    .FirstOrDefaultAsync(x => x.Id == request.BookingDetailId);
            bookingDetail!.Status = Enum.Enum.StatusBookingDetails.RefundPending.ToString();
            bookingDetail.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.BookingDetails.Update(bookingDetail);
            await _dbContext.SaveChangesAsync();
            return;
        }
        var bookingDetailQuery = await _dbContext.BookingDetails
                                                .FirstOrDefaultAsync(x => x.Id == request.BookingDetailId);
        bookingDetailQuery!.Status = Enum.Enum.StatusBookingDetails.Cancelled.ToString();
        bookingDetailQuery.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.BookingDetails.Update(bookingDetailQuery);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.LikeListResponse>> GetAllLikeList(Request.LikeListDetailRequest request)
    {
        var getCustomerId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var customerId = Guid.Parse(getCustomerId!);
        var likeList = _dbContext.LikeListDetails
                                                        .Include(x => x.Court)
                                                        .Where(x => x.CustomerId == customerId && 
                                                                                x.IsDeleted == false);
        if (!await likeList.AnyAsync())
        {
            return new Base.Response.PageResult<Response.LikeListResponse>()
            {
                Items = [],
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalItems = 0,
            };
        }
        var pageQuery = likeList.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.LikeListResponse()
        {
            CourtId = x.CourtId,
            CourtName = x.Court.Name,
            CourtAddress = x.Court.Address,
        });
        var listResult = await selectQuery.ToListAsync();
        return new Base.Response.PageResult<Response.LikeListResponse>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = await likeList.CountAsync(),
        };
    }

    public async Task AddCourtLikeList(Request.AddCourtLikeListRequest request)
    {
        var getCustomerId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var customerId = Guid.Parse(getCustomerId!);
        var court = await _dbContext.Courts.FirstOrDefaultAsync(x => x.Id == request.CourtId);
        if (court == null)
        {
            throw new Exception("Sân không tồn tại trên hệ thống");

        }
        var likeList = await _dbContext.LikeListDetails
            .FirstOrDefaultAsync(x => x.CourtId == request.CourtId &&  
                                      x.CustomerId == customerId);
        if (likeList != null)
        {
            if (likeList.IsDeleted)
            {
                likeList.IsDeleted = false;
                likeList.UpdatedAt = DateTimeOffset.UtcNow;
                _dbContext.LikeListDetails.Update(likeList);
                await _dbContext.SaveChangesAsync();
                return;
            }
            throw new Exception("Đã tồn tại trong danh sách yêu thích");
        }
        if (court.Name != request.CourtName || court.Address != request.CourtAddress)
        {
            throw new Exception("Error tên hoặc địa chỉ không khớp");
        }
        var courtLike = new LikeListDetail()
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            CourtId = request.CourtId,
        };
        await _dbContext.LikeListDetails.AddAsync(courtLike);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCourtLikeList(Request.DeteleCourtLikeListRequest request)
    {
        var getCustomerId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var customerId = Guid.Parse(getCustomerId!);
        var courtLike = await _dbContext.LikeListDetails.FirstOrDefaultAsync(x => x.CourtId == request.CourtId && x.CustomerId == customerId);
        if (courtLike == null)
        {
            throw new Exception("Sân không nằm trong danh sách yêu thích");
        }
        courtLike.IsDeleted = true;
        courtLike.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.LikeListDetails.Update(courtLike);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.BookingResponse>> GetAllBooking(Request.GetAllBookingRequest request)
    {
        var getCustomerId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var customerId = Guid.Parse(getCustomerId!);
        var bookingList = _dbContext.Bookings.Where(x => x.CustomerId == customerId);
        if (!await bookingList.AnyAsync())
        {
            return new Base.Response.PageResult<Response.BookingResponse>()
            {
                Items = [],
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalItems = 0
            };
        }
        var pageQuery = bookingList.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.BookingResponse()
        {
            Id =  x.Id,
            FinalPrice = x.FinalPrice,
            Status = x.Status,
        });
        var result = await selectQuery.ToListAsync();
        return new Base.Response.PageResult<Response.BookingResponse>()
        {
            Items = result,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = await bookingList.CountAsync()
        };
    }
}