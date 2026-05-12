using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;
namespace Rallyhub.Service.Owner;

public class Service : IService
{  
    private readonly AppDbContext _dbContext;  
    private readonly IHttpContextAccessor _httpContext;  
    private readonly MediaService.IService _mediaService;  
    private readonly Validation.IService _validationService;
  
    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext, MediaService.IService mediaService, Validation.IService validationService)  
    {       
        _dbContext = dbContext;  
        _httpContext = httpContext;  
        _mediaService = mediaService;  
        _validationService = validationService;
    }  
    public async Task<Response.CreateCourtResponse> CreateCourt(Request.CreateCourtRequest request)  
    {        
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);  
        var existingCourtQuery = _dbContext.Courts.Where(x => 
            x.Name.ToLower().Trim() == request.Name.ToLower().Trim() && 
            ownerIdGuid == x.OwnerId);  
        bool isExistCourt = await existingCourtQuery.AnyAsync();  
        if (isExistCourt)  
        {            
            throw new Exception($"Sân tên: {request.Name} đã tồn tại trên hệ thống của bạn");  
        }  
        var court = new Repository.Entity.Court()  
        {  
            Id = Guid.NewGuid(),  
            OwnerId = ownerIdGuid,  
            Name = request.Name,  
            Address = request.Address,  
            OpenTime = request.OpenTime,  
            CloseTime = request.CloseTime,  
            Latitude = request.Latitude,  
            Longitude = request.Longitude,  
            MapUrl = request.MapUrl,  
            PictureUrl = await _mediaService.UploadImageAsync(request.PictureUrl),  
            Status = "Pending",  
        };  
  
        _dbContext.Add(court);  
        await _dbContext.SaveChangesAsync();  
  
        return new Response.CreateCourtResponse()  
        {  
            CourtId = court.Id,  
            Status = court.Status,  
        };  
    }  
    public async Task<Base.Response.PageResult<Response.GetMyCourtsResponse>> GetAllMyCourts(Request.GetAllMyCourtsRequest request)  
    {        
        if (request.PageIndex <= 0)  
        {            
            throw new ArgumentException("Số trang phải lớn hơn 0");  
        }  
        if (request.PageSize <= 0)  
        {            
            throw new ArgumentException("Các phần tử trong trang phải lớn hơn 0");  
        }        
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        
        var query = await _dbContext.Courts
            .OrderBy(x => x.Name)
            .Where(x => x.OwnerId == ownerIdGuid).ToListAsync();
        if (request.Name != null)  
        {            
            var keyword = _validationService.RemoveDiacritics(request.Name.Trim().ToLower());
            query = query
                .Where(x =>
                    _validationService.RemoveDiacritics(x.Name.ToLower().Trim()).Contains(keyword))
                .ToList();
        }
        var totalItems = query.Count();  
        var listResult = query
            .OrderBy(x => x.Name)  
            .Skip((request.PageIndex - 1) * request.PageSize)  
            .Take(request.PageSize)  
            .Select(x => new Response.GetMyCourtsResponse()  
            {  
                CourtId = x.Id,
                Name = x.Name,  
                Status = x.Status,
                Address = x.Address,
                StartTime = x.OpenTime,
                EndTime = x.CloseTime,
                PictureUrl = x.PictureUrl,
                MapUrl = x.MapUrl,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
            }).ToList();  
  
        var result = new Base.Response.PageResult<Response.GetMyCourtsResponse>()  
        {  
            Items = listResult,  
            TotalItems = totalItems,  
            PageIndex = request.PageIndex,  
            PageSize = request.PageSize,  
        };  
        return result;  
    }
    public async Task<Response.CreateSubCourtResponse> CreateSubCourt(Request.CreateSubCourtRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }
        var ownerIdGuid = Guid.Parse(ownerIdClaim); 
        var court = await _dbContext.Courts
            .FirstOrDefaultAsync(x => 
                x.Id == request.CourtId && 
                x.Status == "Active");
        if (court == null)
        {
            throw new Exception("Không tìm thấy sân");
        }
        if (court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Sân đó không phải của bạn");
        }
        var isExistName = await _dbContext.SubCourts.AnyAsync(x => 
            x.CourtId == request.CourtId && 
            x.Name.Trim().ToLower() == request.Name.Trim().ToLower());
        if (isExistName)
        {
            throw new Exception("Sân con đó đã tồn tại!");
        }
        var newSubCourt =  new SubCourt
        {
            Id = Guid.NewGuid(),
            CourtId =  request.CourtId,
            Name = request.Name,
        };
        _dbContext.Add(newSubCourt);
        await _dbContext.SaveChangesAsync();
        //create slot
        var slots = new List<ConfigSlot>();
        var current = court.OpenTime;
        while (current.AddMinutes(30) <= court.CloseTime)
        {
            slots.Add(new ConfigSlot
            {
                Id = Guid.NewGuid(),
                SubCourtDetailId = newSubCourt.Id,
                StartTime = current,
                EndTime = current.AddMinutes(30),
                Price = request.DefaultPrice,
                
            });
            current = current.AddMinutes(30);
        }
        _dbContext.ConfigSlots.AddRange(slots);
        await _dbContext.SaveChangesAsync();
        return new Response.CreateSubCourtResponse
        {
            SubCourtId  = newSubCourt.Id,
            Name = newSubCourt.Name,
        };
    }
    public async Task<Base.Response.PageResult<Response.GetMySubCourtsResponse>> GetMySubCourts(Request.GetMySubCourtsRequest request)
    {   
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        
        if (request.CourtId != null)
        {
            var court = await _dbContext.Courts
                .FirstOrDefaultAsync(x => 
                    x.Id == request.CourtId && 
                    x.OwnerId == ownerIdGuid);
            if (court == null || court.Status != "Active")
            {
                throw new Exception("Sân chưa được vận hành");
            }
            
            var hasSubCourt = await _dbContext.SubCourts
                .AnyAsync(x => 
                    x.CourtId == request.CourtId);
            if (!hasSubCourt)
            {
                throw new Exception($"Sân {request.Name} không tồn tại sân con");
            }
        }
        
        var query = _dbContext.SubCourts
            .Include(x => x.Court)
            .Where(x =>
                x.Court.OwnerId == ownerIdGuid &&
                x.Court.Status == "Active")
            .AsQueryable();
        if (request.CourtId != null)
        {
            query = query.Where(x => x.Court.Id == request.CourtId);
        }
        var rawQuery = await query.ToListAsync();
        if (request.Name != null)
        {
            var keyword = _validationService.RemoveDiacritics(request.Name.Trim().ToLower());
            rawQuery = rawQuery
                .Where(x => 
                 _validationService.RemoveDiacritics(x.Name.Trim().ToLower()).Contains(keyword))
                .ToList();
        }
        
        var totalItems =  rawQuery.Count();
        var result =  rawQuery
            .OrderBy(x => x.Name)
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new Response.GetMySubCourtsResponse
            {
                CourtId = x.Court.Id,
                SubCourtId = x.Id,
                Name = x.Name,
            }).ToList();
        return new Base.Response.PageResult<Response.GetMySubCourtsResponse>
        {
            Items = result,
            TotalItems = totalItems,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };
    }
    //comment đừng xóa
    /*public async Task<Response.CreateConfigSlotResponse> CreateConfigSlot(Request.CreateConfigSlotRequest request)
    {
        //Lấy token của OwnerId
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
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
    }*/
    public async Task<List<Response.GetConfigSlotResponse>> GetConfigSlotBySubCourtId(Guid subCourtId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);

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
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null) 
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);

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

        if (request.StartTime >= request.EndTime)
        {
            throw new Exception("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc");
        }
         
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
            throw new Exception("Override bị trùng thời gian ");
        }
        
        var configSlots = await  _dbContext.ConfigSlots
            .Where(x => x.SubCourtDetailId == request.SubCourtId)
            .OrderBy(x => x.StartTime)
            .ToListAsync();
        
        var validStart = configSlots.Any(x => x.StartTime == request.StartTime);
        var validEnd   = configSlots.Any(x => x.EndTime == request.EndTime);

        if (!validStart || !validEnd)
            throw new Exception("Override match với ConfigSlot");

        var coveredSlots = configSlots
            .Where(x => 
                x.StartTime >= request.StartTime &&
                x.EndTime <= request.EndTime)
            .ToList();

        var expected = (request.EndTime - request.StartTime).TotalMinutes;
        var actual = coveredSlots.Sum(x => 
            (x.EndTime - x.StartTime).TotalMinutes);

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
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
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
    public async Task<Response.CreateExceptionSlotResponse> CreateExceptionSlot(Request.CreateExceptionSlotRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
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
        if (request.StartTime >= request.EndTime)
        {
            throw new Exception("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc");
        }

        if (request.Date < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new Exception("Không thể block slot trong quá khứ");
        }
        
        var isOverlap = await  _dbContext.Exceptions.AnyAsync(x => 
            x.SubCourtDetailId == request.SubCourtId &&
            x.Date == request.Date &&
            request.StartTime < x.EndTime &&
            request.EndTime > x.StartTime);
        if (isOverlap)
        {
            throw new Exception("Khoảng thời gian này đã bị khóa rồi");
        }

        //
        var configSlots = await _dbContext.ConfigSlots
            .Where(x => x.SubCourtDetailId == request.SubCourtId)
            .OrderBy(x => x.StartTime)
            .ToListAsync();
        
        var validStart = configSlots.Any(x => x.StartTime == request.StartTime);
        var validEnd = configSlots.Any(x => x.EndTime == request.EndTime);

        if (!validStart || !validEnd)
        {
            throw new Exception("Exception slot phải match với ConfigSlot");
        }
        
        var lockedSlots = configSlots
            .Where(x => 
                x.StartTime >= request.StartTime && 
                x.EndTime <= request.EndTime)
            .ToList();
        
        var excepted = (request.EndTime - request.StartTime).TotalMinutes;
        var actual = lockedSlots.Sum(x =>
            (x.EndTime - x.StartTime).TotalMinutes);

        if (excepted != actual)
        {
            throw new Exception("Exception slot phải cover full ConfigSlot");
        }
        
        var newExceptionSlot = new Repository.Entity.Exception
        {
            Id = Guid.NewGuid(),
            SubCourtDetailId = request.SubCourtId,
            Date = request.Date,
            StartTime = request.StartTime, 
            EndTime = request.EndTime,
            Reason = request.Reason,
        };
        _dbContext.Exceptions.Add(newExceptionSlot);
        await _dbContext.SaveChangesAsync();
        var result = new Response.CreateExceptionSlotResponse
        {
            Id = newExceptionSlot.Id,
            Date = newExceptionSlot.Date,
            StartTime = newExceptionSlot.StartTime,
            EndTime = newExceptionSlot.EndTime,
            Reason = newExceptionSlot.Reason,
        };
        return result;
    }
    public async Task<List<Response.GetExceptionSlotResponse>> GetExceptionSlotBySubCourtId(Guid subCourtId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
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
        var exceptionSlot = await _dbContext.Exceptions
            .Where(x => x.SubCourtDetailId == subCourtId)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.StartTime)
            .Select(x => new Response.GetExceptionSlotResponse
            {
                Id = x.Id,
                Date = x.Date,
                StartTime = x.StartTime,                                        
                EndTime = x.EndTime,
                Reason = x.Reason,
            }).ToListAsync();
        return exceptionSlot;
    }
    public async Task<Response.GetSetupSlotResponse> GetSetupSlots(Guid subCourtId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
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

        var configSlots = await _dbContext.ConfigSlots
            .Where(x => x.SubCourtDetailId ==  subCourtId)
            .OrderBy(x => x.StartTime)
            .Select(x => new Response.GetConfigSlotResponse
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price,
            }).ToListAsync();
        var overrideSlots = await _dbContext.OverideSlots
            .Where(x => x.SubCourtDetailId == subCourtId)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.DayOfWeek)
            .Select(x => new Response.GetOverrideSlotResponse
            {
                Id = x.Id,
                IsRecurring =  x.IsRecurring,
                DayOfWeek = x.DayOfWeek,
                Date =  x.Date,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price,
            }).ToListAsync();
        var exceptions = await _dbContext.Exceptions
            .Where(x => x.SubCourtDetailId == subCourtId)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.StartTime)
            .Select(x => new Response.GetExceptionSlotResponse
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Date =   x.Date,
                Reason = x.Reason,
            }).ToListAsync();
        return new Response.GetSetupSlotResponse
        {
            ConfigSlots = configSlots,
            ExceptionSlots = exceptions,
            OverrideSlots = overrideSlots,
        };
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
}

    
    
    