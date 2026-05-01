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

    public async Task<Response.CreateConfigSlotResponse> CreateConfigSlot(Request.CreateConfigSlotRequest request)
    {
        //Lấy token của OwnerId
        var ownerIdClaim = _httpContext.HttpContext?.User?  
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;  
        if (string.IsNullOrEmpty(ownerIdClaim))  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        
        //CheckSubCourt co ton tai va co thuoc Owner
        var existSubCourt = await _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefaultAsync(x => x.Id == request.SubCourtId);
        if (existSubCourt == null)
        {
            throw new Exception("Sân con không tồn tại!");
        }

        if (existSubCourt.Court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Bạn không có quyền");
        }
        //Validate time
        if(request.StartTime >= request.EndTime)
        {
            throw new Exception("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc của khung giờ đó!");
        }
        //Validate overlap
        var isOverlap = await _dbContext.ConfigSlots.AnyAsync(x =>
            x.SubCourtDetailId == request.SubCourtId
            && request.StartTime < x.EndTime 
            && request.EndTime > x.StartTime);

        if (isOverlap)
        {
            throw new Exception("Slot bị trùng thời gian");
        }
        
        //validate gap slot
        var duration = request.EndTime - request.StartTime;
        if (duration.TotalMinutes != 30)
        {
            throw new Exception("Mỗi slot phải đúng 30 phút");
        }
        
        if (request.StartTime.Minute % 30 != 0 ||
            request.EndTime.Minute % 30 != 0)
        {
            throw new Exception("Slot phải align 30 phút");
        }
        //Create entity
        var newConfigSlot = new ConfigSlot
        {
            Id = Guid.NewGuid(),
            SubCourtDetailId = request.SubCourtId,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Price = request.Price,
        };
        _dbContext.Add(newConfigSlot);
        await _dbContext.SaveChangesAsync();

        return new Response.CreateConfigSlotResponse
        {
            Id = newConfigSlot.Id,
            StartTime = newConfigSlot.StartTime,
            EndTime = newConfigSlot.EndTime,
            Price = newConfigSlot.Price,
        };
    }

    public async Task<List<Response.GetConfigSlotResponse>> GetConfigSlotBySubCourtId(Guid subCourtId)
    {
        //Lấy token của OwnerId
        var ownerIdClaim = _httpContext.HttpContext?.User?  
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;  
        if (string.IsNullOrEmpty(ownerIdClaim))  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        //check subCourt + ownerShip
        var existSubCourt = _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefault(x => x.Id == subCourtId);
        if (existSubCourt == null)
        {
            throw new Exception("Sân con không tồn tại");
        }

        if (existSubCourt.Court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Bạn không có quyền");
        }
        
        //get ConfigSlot
        var slots = await _dbContext.ConfigSlots
            .Where(x => x.SubCourtDetailId == subCourtId)
            .OrderBy(x => x.StartTime)
            .Select(x => new Response.GetConfigSlotResponse()
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price,
            }).ToListAsync();
        return slots;
    }

    public async Task<Response.CreateOverrideSlotResponse> CreateOverrideSlot(Request.CreateOverrideSlotRequest request)
    {
        //Lấy token của OwnerId
        var ownerIdClaim = _httpContext.HttpContext?.User?  
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;  
        if (string.IsNullOrEmpty(ownerIdClaim))  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        //check subCort + Owner
        var subCourt = await _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefaultAsync(x => x.Id == request.SubCourtId);
        if (subCourt == null)
        {
            throw new Exception("Sân con không tồn tại!");
        }

        if (subCourt.Court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Bạn không có quyền");
        }
        //Validate Date / DateOfWeek
        if (request.IsRecurring)
        {
            if (request.DayOfWeek == null)
            {
                throw new Exception("Thiếu DateOfWeek");
            }

            if (request.Date != null)
            {
                throw new Exception("Recurring không được có Date");
            }
        }else
        {
            if (request.Date == null)
            {
                throw new Exception("Thiếu Date");
            }
        }
        //Validate Time
        if (request.StartTime >= request.EndTime)
        {
            throw new Exception("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc");
        }
        //Validate overlap với override 
        var isOverlap = await _dbContext.OverideSlots.AnyAsync(x =>
            x.SubCourtDetailId == request.SubCourtId &&
            (
                (request.IsRecurring && x.IsRecurring && x.DayOfWeek == request.DayOfWeek) || 
                (!request.IsRecurring && !x.IsRecurring && x.Date == request.Date)
            )&& request.StartTime < x.EndTime
            && request.EndTime > x.StartTime
        );
        if (isOverlap)
        {
            throw new Exception("Override bị trùng thời ");
        }
        
        //Validate align voiws ConfigSlot
        var configSlots = await  _dbContext.ConfigSlots
            .Where(x => x.SubCourtDetailId == request.SubCourtId)
            .OrderBy(x => x.StartTime)
            .ToListAsync();
        
        if (!configSlots.Any())
        {
            throw new Exception("SubCourt chưa có ConfigSlot");
        }
        
        var validStart = configSlots.Any(x => x.StartTime == request.StartTime);
        var validEnd   = configSlots.Any(x => x.EndTime == request.EndTime);

        if (!validStart || !validEnd)
            throw new Exception("Override phải align với ConfigSlot");

        var coveredSlots = configSlots
            .Where(x => x.StartTime >= request.StartTime &&
                        x.EndTime <= request.EndTime)
            .ToList();

        var expected = (request.EndTime - request.StartTime).TotalMinutes;
        var actual = coveredSlots.Sum(x => (x.EndTime - x.StartTime).TotalMinutes);

        if (expected != actual)
            throw new Exception("Override không cover full ConfigSlot");
        
        var overrideSlot = new OverideSlot
        {
            Id = Guid.NewGuid(),
            SubCourtDetailId = request.SubCourtId,
            IsRecurring = request.IsRecurring,
            DayOfWeek = request.DayOfWeek ?? default,
            Date = request.Date ?? default,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Price = request.Price,
        };
        
        //
        _dbContext.Add(overrideSlot);
        await _dbContext.SaveChangesAsync();
        return new Response.CreateOverrideSlotResponse
        {
            Id = overrideSlot.Id,
            DayOfWeek = overrideSlot.DayOfWeek,
            Date = overrideSlot.Date,
            StartTime = overrideSlot.StartTime,
            EndTime = overrideSlot.EndTime,
            Price = overrideSlot.Price,
        };
    }

    public async Task<List<Response.GetOverrideSlotResponse>> GetOverrideSlotBySubCourtId(Guid subCourtId)
    {
        //Lấy token của OwnerId
        var ownerIdClaim = _httpContext.HttpContext?.User?  
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;  
        if (string.IsNullOrEmpty(ownerIdClaim))  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        
        //check subCort + Owner
        var subCourt = await _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefaultAsync(x => x.Id == subCourtId);
        if (subCourt == null)
        {
            throw new Exception("Sân con không tồn tại!");
        }

        if (subCourt.Court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Bạn không có quyền");
        }
      
        
        var overrideSlots = await   _dbContext.OverideSlots
            .Where(x => x.SubCourtDetailId == subCourtId)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.DayOfWeek)
            .ThenBy(x => x.StartTime)
            .Select(x => new Response.GetOverrideSlotResponse
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price,
                DayOfWeek = x.DayOfWeek,
                Date = x.Date,
                IsRecurring = x.IsRecurring
            }).ToListAsync();
        
       return overrideSlots;
    }
}

    
    
    