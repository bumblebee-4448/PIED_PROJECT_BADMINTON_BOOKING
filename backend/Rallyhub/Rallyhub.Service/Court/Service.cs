using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using StatusCreateCourt = Rallyhub.Service.Enum.Enum.StatusCreateCourt;
namespace Rallyhub.Service.Court;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContext;
    private readonly MediaService.IService _mediaService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext, MediaService.IService mediaService)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
        _mediaService = mediaService;
    }

    public async Task<Response.CreateCourtResponse> CreateCourt(Request.CreateCourtRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext?.User?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(ownerIdClaim))
        {
            throw new Exception("Owner không tồn tại");
        }
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        if (string.IsNullOrEmpty(request.Name))
        {
            throw new Exception("Tân sân không được bỏ trống");
        }

        if (request.OpenTime >= request.CloseTime)
        {
            throw new Exception("Giờ mở phải nhỏ hơn giờ đóng");
        }
        
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
            Id = Guid.NewGuid(),
            OwnerId = ownerIdGuid,
            Name = request.Name.Trim(),
            Address = request.Address,
            OpenTime = request.OpenTime,
            CloseTime = request.CloseTime,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            MapUrl = request.MapUrl,
            PictureUrl = await _mediaService.UploadImageAsync(request.PictureUrl),
            Status = nameof(StatusCreateCourt.Pending),
        };

        _dbContext.Add(court);
        await _dbContext.SaveChangesAsync();

        return new Response.CreateCourtResponse()
        {
            CourtId = court.Id,
            Status = court.Status,
        };
    }

    public async Task<Base.Response.PageResult<Response.SearchCourtResponse>> SearchByFilter(Request.SearchByFilterRequest request)
    {

        var  query = _dbContext.Courts
            .Where(x => x.Status == nameof(StatusCreateCourt.Approved))
            .Select(x => new
            {
                Court = x,
                AverageRating = _dbContext.Feedbacks
                    .Where(f => f.CourtId == x.Id)
                    .Select(f => (double?)f.Rating)//.Select(f => f.Rating).Average() => exception if rỗng  
                    .Average() ?? 0,
            });
        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            var keyword = request.Keyword.Trim().ToLower();
            query = query.Where(x => 
                x.Court.Name.ToLower().Contains(keyword) ||
                x.Court.Address.ToLower().Contains(keyword));
        }

        query = request.SortBy?.ToLower() switch
        {
            "name" => request.IsDescending
            ? query.OrderByDescending(x => x.Court.Name)
            : query.OrderBy(x => x.Court.Name),
            
            "rate" => request.IsDescending
            ? query.OrderByDescending(x => x.AverageRating)
                .ThenByDescending(x => x.Court.Name)
            : query.OrderBy(x => x.AverageRating),
            
            _ => query.OrderByDescending(x => x.AverageRating)
        };
    
        var totalItems = await query.CountAsync();
        query = query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);
        var selectedQuery = query.Select(x => new Response.SearchCourtResponse()
        {
            CourtId = x.Court.Id,
            Name = x.Court.Name,
            Address =  x.Court.Address,
            Status = x.Court.Status,
            AverageRating = x.AverageRating,
            PictureUrl = x.Court.PictureUrl,
            MapUrl = x.Court.MapUrl,
            PhoneNumber = x.Court.Owner.User.PhoneNumber!,
        });
        
        var listResult = await selectedQuery.ToListAsync();
        
        var result = new Base.Response.PageResult<Response.SearchCourtResponse>
        {
            Items = listResult,
            TotalItems = totalItems,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };
        
        return result;
    }
    
    
}