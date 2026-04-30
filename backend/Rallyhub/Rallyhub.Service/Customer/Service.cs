using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;

namespace Rallyhub.Service.Customer;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly MediaService.IService _mediaService;
    private readonly IHttpContextAccessor _httpContext;

    public Service(AppDbContext dbContext, MediaService.IService mediaService, IHttpContextAccessor httpContext)
    {
        _dbContext = dbContext;
        _mediaService = mediaService;
        _httpContext = httpContext;
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
}