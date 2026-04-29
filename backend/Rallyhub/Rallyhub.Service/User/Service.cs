using Microsoft.AspNetCore.Http;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;

namespace Rallyhub.Service.User;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly MediaService.IService _mediaService;
    private readonly IHttpContextAccessor _httpContext;

    // public Service(AppDbContext dbContext, MediaService.IService mediaService, IHttpContextAccessor httpContext)
    // {
    //     _dbContext = dbContext;
    //     _mediaService = mediaService;
    //     _httpContext = httpContext;
    // }
    //
    // public async Task OwnerRequest(Request.OwnerRequestRequest request)
    // {
    //     var userId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
    //     var userIdGuid = Guid.Parse(userId!);
    //     var user = _dbContext.Users.SingleOrDefault(x => x.Id == userIdGuid);
    //
    //     var customer = _dbContext.Customers.FirstOrDefault(x => x.UserId == userIdGuid);
    //
    //     if (user?.FirstName != request.FirstName || user?.LastName != request.LastName)
    //     {
    //         throw new Exception($"Tên {request.FirstName} {request.FirstName} không khớp với tên của tài khoản này");
    //     }
    //
    //     var ownerRequeest = new OwnerRequest()
    //     {
    //         BusinessName = request.BusinessName,
    //         TaxCode = request.TaxCode,
    //         BusinessAddress = request.BusinessAddress,
    //         BusinessLicenseUrl = await _mediaService.UploadImageAsync(request.BusinessLicenseUrl),
    //         IdentityNumber = request.IdentityNumber,
    //         IdentityCardFrontUrl = await _mediaService.UploadImageAsync(request.IdentityCardFrontUrl),
    //         IdentityCardBackUrl = await _mediaService.UploadImageAsync(request.IdentityCardBackUrl),
    //         CreatedAt = DateTimeOffset.Now,
    //         CustomerId = customer!.Id,
    //         Status = Enum.Enum.AllStatus.Pending.ToString(),
    //     };
    // }
}