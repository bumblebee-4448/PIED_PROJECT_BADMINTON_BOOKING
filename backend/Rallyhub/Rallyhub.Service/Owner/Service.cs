using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;
using StatusCreateCourt = Rallyhub.Service.Enum.Enum.StatusCreateCourt;
namespace Rallyhub.Service.Owner;

public class Service : IService 
{  
    private readonly AppDbContext _dbContext;  
    private readonly IHttpContextAccessor _httpContext;  
    private readonly MediaService.IService _mediaService;  
  
    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext, MediaService.IService mediaService)  
    {        _dbContext = dbContext;  
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
    public async Task<Base.Response.PageResult<Response.GetMyCourtsResponse>> GetAllCourts(Request.GetMyCourtsRequest request)  
    {        
        if (request.PageIndex <= 0)  
        {            
            throw new ArgumentException("PageIndex must be greater than 0");  
        }  
        if (request.PageSize <= 0)  
        {            
            throw new ArgumentException("PageSize must be greater than 0");  
        }        
        var ownerIdClaim = _httpContext.HttpContext?.User?  
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;  
        if (string.IsNullOrEmpty(ownerIdClaim))  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);  
        var query = _dbContext.Courts.Where(x => x.OwnerId == ownerIdGuid);  
        if (!string.IsNullOrEmpty(request.Name))  
        {            
            query = query.Where(x =>   
                x.Name.Trim().ToLower()  
                    .Contains(request.Name.Trim().ToLower()));  
        }        
        var totalItems = await query.CountAsync();  
        query = query.OrderBy(x => x.Name);  
        query = query.Skip((request.PageIndex - 1) * request.PageSize)  
                        .Take(request.PageSize);  
        var selectedQuery = query  
            .Select(x => new Response.GetMyCourtsResponse()  
            {  
                Name = x.Name,  
                Status = x.Status,  
            });  
        var listResult = await selectedQuery.ToListAsync();  
  
        var result = new Base.Response.PageResult<Response.GetMyCourtsResponse>()  
        {  
            Items = listResult,  
            TotalItems = totalItems,  
            PageIndex = request.PageIndex,  
            PageSize = request.PageSize,  
        };  
        return result;  
    }

    public async Task<Response.SubCourtResponse> CreateSubCourt(Request.CreateSubCourtRequest request)
    {
        //kiểm tra owner
        var ownerIdClaim = _httpContext.HttpContext?.User?  
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;  
  
        if (string.IsNullOrEmpty(ownerIdClaim))  
        {            
            throw new Exception("Owner không tồn tại");  
        }
        var ownerIdGuid = Guid.Parse(ownerIdClaim); 
        //check court tồn tại
        var court = await _dbContext.Courts.
            FirstOrDefaultAsync(x => x.Id == request.CourtId);
        if (court == null)
        {
            throw new Exception("Không tìm thấy sân");
        }
        //check sân đó có phải của thằng đó không
        if (court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Sân đó không phải của bạn");
        }
        //kiểm tra trùng tên
        var isExistName = await _dbContext.SubCourts.AnyAsync(
            x => x.CourtId == request.CourtId
            && x.Name.Trim().ToLower() == request.Name.Trim().ToLower());
        if (isExistName)
        {
            throw new Exception("Sân con đó đã tồn tại!");
        }
        //tạo sân
        var newSubCourt =  new SubCourt
        {
            Id = Guid.NewGuid(),
            CourtId =  request.CourtId,
            Name = request.Name,
        };
        //lưu
        _dbContext.Add(newSubCourt);
        await _dbContext.SaveChangesAsync();
        return new Response.SubCourtResponse
        {
            Id  = newSubCourt.Id,
            Name = newSubCourt.Name,
        };
    }
}

    
    
    