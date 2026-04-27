using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Court;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContext;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
    }

    public async Task<string> CreateCourt(Request.CreateCourtRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext?.User?
            .FindFirst("OwnerId")?.Value;

        if (string.IsNullOrEmpty(ownerIdClaim))
        {
            throw new Exception("Unauthorized");
        }

        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        var existingOwnerQuery = _dbContext.Owners.Where(x => x.Id == ownerIdGuid);
        bool isExistOwner = await existingOwnerQuery.AnyAsync();
        if (!isExistOwner)
        {
            throw new Exception("Chủ sân không tồn tại trên hệ thống");
        }

        var existingCourtQuery = _dbContext.Courts.Where
        (x => x.Name.ToLower().Trim() == request.Name.ToLower().Trim()
              && ownerIdGuid == x.OwnerId);
        bool isExistCourt = await existingCourtQuery.AnyAsync();
        if (isExistCourt)
        {
            throw new Exception("Sân này đã tồn tại trên hệ thống của bạn");
        }

        var court = new Repository.Entity.Court()
        {
            OwnerId = ownerIdGuid,
            Name = request.Name,
            Address = request.Address,
            OpenTime = request.OpenTime,
            CloseTime = request.CloseTime,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            MapUrl = request.MapUrl,
            PictureUrl = request.PictureUrl,
            Status = "Pending"
        };

        _dbContext.Add(court);
        await _dbContext.SaveChangesAsync();

        return "Tạo sân thành công, đang chờ Admin duyệt";
    }

    
}