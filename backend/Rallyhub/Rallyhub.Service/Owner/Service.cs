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
    public async Task<string> RemoveCourt(Guid courtId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerId = Guid.Parse(ownerIdClaim);
        var hasCourt = await _dbContext.Courts
            .FirstOrDefaultAsync(x => 
                x.Id ==  courtId &&
                (x.Status == "Active" || x.Status == "Pending") &&
                x.OwnerId == ownerId);
        if (hasCourt == null)
        {
            throw new Exception("Không tìm thấy sân ");
        }
        var hasBooking = await _dbContext.BookingDetails
            .Include(x => x.SubCourt)
            .FirstOrDefaultAsync(x => 
                x.SubCourt.Court.Id == hasCourt.Id &&
                (x.Status == "Pending" ||  x.Status == "Banked"));
        if (hasBooking != null)
        {
            throw new Exception("Đang có đơn đặt, không thể xóa sân");
        }
        hasCourt.IsDeleted = true;
        
        var subCourts = await _dbContext.SubCourts
            .Where(x => x.CourtId == hasCourt.Id)
            .ToListAsync();
        foreach (var subCourt in subCourts)
        {
            subCourt.IsDeleted = true;
        }
        await _dbContext.SaveChangesAsync();
        return "Xóa sân thành công";
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
    public async Task<Response.UpdateCourtInfoResponse> UpdateCourtInfo(Request.UpdateCourtInfoRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
        if (ownerIdClaim == null)
        {
            throw new Exception("Không xác minh được danh tính");
        }
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        var existCourt = _dbContext.Courts
            .FirstOrDefault(x => 
                x.Id == request.CourtId && 
                x.OwnerId == ownerIdGuid &&
                (x.Status == "Active" || x.Status == "Pending"));
        if (existCourt == null)
        {
            throw new Exception("Không tìm thấy sân!");
        }
        
        if (request.Name != null)
            existCourt.Name = request.Name;

        if (request.Address != null)
            existCourt.Address = request.Address;

        if (request.MapUrl != null)
            existCourt.MapUrl = request.MapUrl;

        if (request.Description != null)
            existCourt.Description = request.Description;

        if (request.PictureUrl != null)
        {
            existCourt.PictureUrl = await _mediaService.UploadImageAsync(request.PictureUrl);
        }

        if (request.TimeRefundBefore != null)
        {
            if (request.TimeRefundBefore < 0)
            {
                throw new Exception("Thời gian hoàn tiền phải lớn hơn hoặc bằng 0");
            }
            var hasBooking = await _dbContext.BookingDetails
                .Include(x => x.SubCourt)
                .AnyAsync(x =>
                    x.SubCourt.CourtId == existCourt.Id &&
                    (x.Status == "Banked" || x.Status =="Pending"));
            if (hasBooking)
            {
                throw new Exception("Đang có đơn đặt sân, không thể thay đổi chính sách hoàn tiền");
            }
            existCourt.TimeRefundBefor = request.TimeRefundBefore;
        }

        var oldOpenTime = existCourt.OpenTime;
        var oldCloseTime = existCourt.CloseTime;
        var newOpenTime = request.OpenTime ?? oldOpenTime;
        var newCloseTime = request.CloseTime ?? oldCloseTime;
        
        if (newOpenTime > oldOpenTime || newCloseTime < oldCloseTime)
        {
            throw new Exception("Không được thu hẹp thời gian");
        }
        existCourt.OpenTime = newOpenTime;
        existCourt.CloseTime = newCloseTime;
        
        var subCourts = await _dbContext.SubCourts
            .Where(x => x.CourtId == existCourt.Id)
            .ToListAsync();
        var slotsNeedAdd = new List<ConfigSlot>();
        foreach (var subCourt in subCourts)
        {
            var configSlots = await _dbContext.ConfigSlots
                .Where(x => x.SubCourtDetailId == subCourt.Id)
                .OrderBy(x => x.StartTime)
                .ToListAsync();
            
            if (newOpenTime < oldOpenTime)
            {
                var current = newOpenTime;
                while (current.AddMinutes(30) <= oldOpenTime)
                {
                    slotsNeedAdd.Add(new ConfigSlot()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = subCourt.Id,
                        StartTime = current,
                        EndTime = current.AddMinutes(30),
                        Price = configSlots.First().Price,
                    });
                    current = current.AddMinutes(30);
                }
            }

            if (newCloseTime > oldCloseTime)
            {
                var current = oldCloseTime;
                while (current.AddMinutes(30) <= newCloseTime)
                {
                    slotsNeedAdd.Add(new ConfigSlot()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = subCourt.Id,
                        StartTime = current,
                        EndTime = current.AddMinutes(30),
                        Price = configSlots.First().Price,
                    });
                    current = current.AddMinutes(30);
                }
            }
            
        }
        await _dbContext.ConfigSlots.AddRangeAsync(slotsNeedAdd);
        await _dbContext.SaveChangesAsync();
        return new Response.UpdateCourtInfoResponse()
        {
            CourtId = existCourt.Id,
            Name = existCourt.Name,
            Address = existCourt.Address,
            MapUrl = existCourt.MapUrl,
            Description = existCourt.Description,
            StartTime = existCourt.OpenTime,
            EndTime = existCourt.CloseTime,
            PictureUrl = existCourt.PictureUrl,
            TimeRefundBefore = existCourt.TimeRefundBefor,
        };
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
                (x.Status == "Active" || x.Status == "Pending"));
        if (court == null)
        {
            throw new Exception("Không tìm thấy sân");
        }
        if (court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Sân đó không phải của bạn");
        }
        if (request.DefaultPrice < 0)
        {
            throw new Exception("Số tiền phải lớn hơn không");
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

    public async Task<string> RemoveSubCourt(Guid subCourtId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerId = Guid.Parse(ownerIdClaim);
        var hasSubCourt = await _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefaultAsync(x => 
                x.Id == subCourtId &&
                x.Court.OwnerId == ownerId &&
                (x.Court.Status == "Active" || x.Court.Status == "Pending"));
        if (hasSubCourt == null)
        {
            throw new Exception("Không tìm thấy sân con");
        }
        var hasBooking = _dbContext.BookingDetails
            .Include(x => x.SubCourt)
            .FirstOrDefault(x => 
                x.SubCourtId == subCourtId &&
                (x.Status == "Pending" ||  x.Status == "Banked"));
        if (hasBooking != null)
        {
            throw new Exception("Đang có đơn đặt, không thể xóa sân con");
        }
        hasSubCourt.IsDeleted = true;
        await _dbContext.SaveChangesAsync();
        return "Xóa sân con thành công";
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
            if (court == null || (court.Status != "Active" && court.Status != "Pending"))
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
                (x.Court.Status == "Active" || x.Court.Status == "Pending"))
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
    public async Task<Response.UpdateSubCourtInfoResponse> UpdateSubCourtInfo(Request.UpdateSubCourtInfoRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
        if (ownerIdClaim == null)
        {
            throw new Exception("Không xác minh được danh tính");
        }
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        var existSubCourt = _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefault(x => 
                x.Id == request.SubCourtId && 
                x.Court.OwnerId == ownerIdGuid &&
                (x.Court.Status == "Active" || x.Court.Status == "Pending"));
        if (existSubCourt == null)
        {
            throw new Exception("Không tìm thấy sân!");
        }
        existSubCourt.Name = request.Name;
        _dbContext.Update(existSubCourt);
        await _dbContext.SaveChangesAsync();
        return new Response.UpdateSubCourtInfoResponse()
        {
            SubCourtId = request.SubCourtId,
            Name = request.Name,
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
    public async Task<string> UpdateConfigSlotPrice(Request.UpdateConfigSlotPriceRequest request)
    {
        var  ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
        if (ownerIdClaim == null)
        {
            throw new Exception("Không tìm thấy owner");
        }
        var ownerIdGuid = Guid.Parse(ownerIdClaim);
        var existConfigSlot =  await _dbContext.ConfigSlots
            .Include(x => x.SubCourtDetail)
            .ThenInclude(x => x.Court)
            .FirstOrDefaultAsync(x => x.Id == request.ConfigSlotId);
        if (existConfigSlot == null)
        {
            throw new Exception("Slot không tồn tại trong hệ thống");
        }
        if (existConfigSlot.SubCourtDetail.Court.OwnerId != ownerIdGuid)
        {
            throw new Exception("Bạn không có quyền");
        }
        if (request.NewPrice < 0)
        {
            throw new Exception("Giá phải lớn hơn không");
        }
        existConfigSlot.Price = request.NewPrice;
        _dbContext.Update(existConfigSlot);
        await _dbContext.SaveChangesAsync();
        return "Update giá thành công";
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
            !x.IsDeleted &&
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
    public async Task<string> RemoveOverrideSlot(Guid overrideSlotId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerId = Guid.Parse(ownerIdClaim);
        var isExistOverrideSlot = _dbContext.OverideSlots
            .Include(x => x.SubCourtDetail)
            .ThenInclude(x => x.Court)
            .FirstOrDefault(x => x.Id == overrideSlotId &&
                                 x.SubCourtDetail.Court.OwnerId == ownerId);
        if (isExistOverrideSlot == null)
        {
            throw new Exception("Override slot not found");
        }
        isExistOverrideSlot.IsDeleted = true;
        await _dbContext.SaveChangesAsync();
        return "Slot gộp đã được xóa";
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
        
        if (request.Date < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new Exception("Không thể block slot trong quá khứ");
        }
        
        var isOverlap = await  _dbContext.Exceptions.AnyAsync(x => 
            !x.IsDeleted &&
            x.SubCourtDetailId == request.SubCourtId &&
            (
                (request.IsRecurring && x.IsRecurring && x.DayOfWeek == request.DayOfWeek) || 
                (!request.IsRecurring && !x.IsRecurring && x.Date == request.Date)
            )&& request.StartTime < x.EndTime
            && request.EndTime > x.StartTime
        );
        
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
            IsRecurring = request.IsRecurring,
            DayOfWeek = request.DayOfWeek ?? default,
            Date = request.Date ?? default,
            StartTime = request.StartTime, 
            EndTime = request.EndTime,
            Reason = request.Reason,
        };
        _dbContext.Exceptions.Add(newExceptionSlot);
        await _dbContext.SaveChangesAsync();
        var result = new Response.CreateExceptionSlotResponse
        {
            Id = newExceptionSlot.Id,
            DayOfWeek = newExceptionSlot.DayOfWeek,
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
            .ThenBy(x => x.DayOfWeek)
            .ThenBy(x => x.StartTime)
            .Select(x => new Response.GetExceptionSlotResponse
            {
                Id = x.Id,
                StartTime = x.StartTime,                                        
                EndTime = x.EndTime,
                Date = x.Date,
                DayOfWeek = x.DayOfWeek,
                IsRecurring = x.IsRecurring,
                Reason = x.Reason,
            }).ToListAsync();
        return exceptionSlot;
    }
    public async Task<string> UnlockException(Guid exceptionSlotId)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value; 
        if (ownerIdClaim == null)  
        {            
            throw new Exception("Owner không tồn tại");  
        }        
        var ownerId = Guid.Parse(ownerIdClaim);
        var isExistException = _dbContext.Exceptions
            .Include(x => x.SubCourtDetail)
            .ThenInclude(x => x.Court)
            .FirstOrDefault(x => x.Id == exceptionSlotId &&
                                 x.SubCourtDetail.Court.OwnerId == ownerId );
        if (isExistException == null)
        {
            throw new Exception("Exception slot not found");
        }
        isExistException.IsDeleted = true;
        await _dbContext.SaveChangesAsync();
        return "Slot bạn khóa đã được xóa";
    }
    public async Task<Response.GetSetupSlotResponse> GetSetupSlots(Guid subCourtId, DateOnly date)
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
                Type = "Default",
            }).ToListAsync();
        var overrideSlots = await _dbContext.OverideSlots
            .Where(x => 
                x.SubCourtDetailId == subCourtId && 
                x.Date == date &&
                !x.IsDeleted)
            .OrderBy(x => x.StartTime)
            .Select(x => new Response.GetOverrideSlotResponse
            {
                Id = x.Id,
                IsRecurring =  x.IsRecurring,
                DayOfWeek = x.DayOfWeek,
                Date =  x.Date,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price,
                Type = "Override"
            }).ToListAsync();
        var exceptions = await _dbContext.Exceptions
            .Where(x => 
                x.SubCourtDetailId == subCourtId && 
                x.Date == date &&
                !x.IsDeleted)
            .OrderBy(x => x.StartTime)
            .Select(x => new Response.GetExceptionSlotResponse
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Date =   x.Date,
                Reason = x.Reason,
                Type = "Blocked"
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
                (x.Court.Status == "Active" || x.Court.Status == "Pending"));
        if (subCourt == null)
            throw new Exception("Sân con không tồn tại");
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
        if (ownerIdClaim != null)
        {
            var ownerIdGuid = Guid.Parse(ownerIdClaim!);
            var existSubCourt = await _dbContext.SubCourts
                .Include(x => x.Court)
                .FirstOrDefaultAsync(x => 
                    x.Id == request.SubCourtId && 
                    (x.Court.Status == "Active" || x.Court.Status == "Pending") &&
                    x.Court.OwnerId == ownerIdGuid);
            if (existSubCourt == null)
            {
                throw new Exception("Sân con không tồn tại");
            }
        }
        else
        {
            if (subCourt.Court.Status != "Active")
            {
                throw new Exception("Sân chưa được vận hành");
            }
        }
        
        // // var today = DateOnly.FromDateTime(DateTime.UtcNow);
        // var vnZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        // var today = DateOnly.FromDateTime(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnZone));    
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
                            
                ) && !x.IsDeleted)
            .ToListAsync();

        var exceptions = await  _dbContext.Exceptions
            .Where(x => 
                x.SubCourtDetailId == request.SubCourtId &&
                ( 
                    (!x.IsRecurring && x.Date == request.Date) || 
                    (x.IsRecurring && x.DayOfWeek == request.Date.DayOfWeek)
                            
                ) && !x.IsDeleted)
            .ToListAsync();

        var result = configSlots.Select(x => new Response.SlotResponse
        {
            ConfigSlotId = x.Id,
            StartTime =  x.StartTime,
            EndTime =  x.EndTime,
            Price = x.Price,
            IsAvailable = true,
            Type = "Default"
        }).ToList();
        
        foreach (var ov in overrides)
        {
            result.RemoveAll(x => 
                x.StartTime >= ov.StartTime && 
                x.EndTime <= ov.EndTime);

            result.Add(new Response.SlotResponse
            {
                OverrideSlotId = ov.Id,
                StartTime = ov.StartTime,
                EndTime = ov.EndTime,
                Price = ov.Price,
                IsAvailable = true,
                Type = "Override"
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
                        ConfigSlotId = slot.ConfigSlotId,
                        OverrideSlotId = slot.OverrideSlotId,
                        StartTime = slot.StartTime,
                        EndTime = ex.StartTime,
                        IsAvailable = true,
                        Price = slot.Price,
                        Type = slot.Type
                    });
                }

                if (!exceptionAdd)
                {
                    result.Add(new Response.SlotResponse()
                    {
                        ExceptionId = ex.Id,
                        StartTime = ex.StartTime,
                        EndTime = ex.EndTime,
                        IsAvailable = false,
                        Reason = ex.Reason,
                        Type = "Blocked"
                    });
                    exceptionAdd = true;
                }

                if (slot.EndTime > ex.EndTime)
                {
                    result.Add(new Response.SlotResponse()
                    {
                        ConfigSlotId = slot.ConfigSlotId,
                        OverrideSlotId = slot.OverrideSlotId,
                        StartTime = ex.EndTime,
                        EndTime = slot.EndTime,
                        IsAvailable = true,
                        Price = slot.Price,
                        Type = slot.Type
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
               // slot.Reason = "Đã được khách đặt";
                slot.Type = "Booked";   
            }
        }
        return result.OrderBy(x => x.StartTime).ToList();
    }

    public async Task<Response.DashboardResponse> GetDashboard(Request.DashboardRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
        if (ownerIdClaim == null)
        {
            throw new Exception("Owner không tồn tại");
        }
        var ownerIdGuid = Guid.Parse(ownerIdClaim);

        List<Guid> targetCourtIds = new List<Guid>();

        if (request.CourtId.HasValue)
        {
            var court = await _dbContext.Courts
                .FirstOrDefaultAsync(x => x.Id == request.CourtId.Value && x.OwnerId == ownerIdGuid);
            if (court == null) throw new Exception("Sân không tồn tại hoặc không thuộc quyền sở hữu của bạn");
            targetCourtIds.Add(request.CourtId.Value);
        }
        else if (request.BookingId.HasValue)
        {
            var courtIdFromBooking = await _dbContext.BookingDetails
                .Where(bd => bd.BookingId == request.BookingId.Value)
                .Select(bd => bd.SubCourt.CourtId)
                .FirstOrDefaultAsync();
            if (courtIdFromBooking == Guid.Empty) throw new Exception("Không tìm thấy sân liên quan đến Booking này");
            
            var court = await _dbContext.Courts
                .FirstOrDefaultAsync(x => x.Id == courtIdFromBooking && x.OwnerId == ownerIdGuid);
            if (court == null) throw new Exception("Sân liên quan đến Booking này không thuộc quyền sở hữu của bạn");
            
            targetCourtIds.Add(courtIdFromBooking);
        }
        else
        {
            // Nếu không truyền gì, lấy tất cả ID sân của Owner này
            targetCourtIds = await _dbContext.Courts
                .Where(x => x.OwnerId == ownerIdGuid)
                .Select(x => x.Id)
                .ToListAsync();

            if (!targetCourtIds.Any())
            {
                // Trả về kết quả trống nếu owner chưa có sân nào
                return new Response.DashboardResponse 
                { 
                    Period = request.Period,
                    ComparisonStatus = "NoChange",
                    BookingComparisonStatus = "NoChange"
                };
            }
        }

        DateTimeOffset now = DateTimeOffset.Now;
        DateTimeOffset referenceDate = request.Date.HasValue
            ? new DateTimeOffset(request.Date.Value.ToDateTime(TimeOnly.MinValue), now.Offset)
            : now;
            
        DateTimeOffset currentStart, currentEnd, prevStart, prevEnd;

        switch (request.Period.ToLower())
        {
            case "week":
                // Tính từ Thứ 2 của tuần chứa ngày referenceDate
                int diff = (7 + (referenceDate.DayOfWeek - DayOfWeek.Monday)) % 7;
                currentStart = referenceDate.AddDays(-1 * diff).Date;
                currentStart = new DateTimeOffset(currentStart.DateTime, referenceDate.Offset);
                currentEnd = currentStart.AddDays(7).AddTicks(-1);
                prevStart = currentStart.AddDays(-7);
                prevEnd = currentStart.AddTicks(-1);
                break;
            case "month":
                currentStart = new DateTimeOffset(referenceDate.Year, referenceDate.Month, 1, 0, 0, 0, referenceDate.Offset);
                currentEnd = currentStart.AddMonths(1).AddTicks(-1);
                prevStart = currentStart.AddMonths(-1);
                prevEnd = currentStart.AddTicks(-1);
                break;
            case "quarter":
                int quarter = (referenceDate.Month - 1) / 3 + 1;
                currentStart = new DateTimeOffset(referenceDate.Year, (quarter - 1) * 3 + 1, 1, 0, 0, 0, referenceDate.Offset);
                currentEnd = currentStart.AddMonths(3).AddTicks(-1);
                prevStart = currentStart.AddMonths(-3);
                prevEnd = currentStart.AddTicks(-1);
                break;
            case "year":
                currentStart = new DateTimeOffset(referenceDate.Year, 1, 1, 0, 0, 0, referenceDate.Offset);
                currentEnd = currentStart.AddYears(1).AddTicks(-1);
                prevStart = currentStart.AddYears(-1);
                prevEnd = currentStart.AddTicks(-1);
                break;
            case "day":
            default:
                currentStart = new DateTimeOffset(referenceDate.Year, referenceDate.Month, referenceDate.Day, 0, 0, 0, referenceDate.Offset);
                currentEnd = currentStart.AddDays(1).AddTicks(-1);
                prevStart = currentStart.AddDays(-1);
                prevEnd = currentStart.AddTicks(-1);
                break;
        }

        currentStart = currentStart.ToUniversalTime();
        currentEnd = currentEnd.ToUniversalTime();
        prevStart = prevStart.ToUniversalTime();
        prevEnd = prevEnd.ToUniversalTime();

        var currentRevenue = await _dbContext.Transactions
            .Where(t => t.Type == "Receive" && t.Status == "Success" &&
                        t.CreatedAt >= currentStart && t.CreatedAt <= currentEnd &&
                        t.Booking.BookingDetails.Any(bd => targetCourtIds.Contains(bd.SubCourt.CourtId)))
            .SumAsync(t => t.Amount);

        var prevRevenue = await _dbContext.Transactions
            .Where(t => t.Type == "Receive" && t.Status == "Success" &&
                        t.CreatedAt >= prevStart && t.CreatedAt <= prevEnd &&
                        t.Booking.BookingDetails.Any(bd => targetCourtIds.Contains(bd.SubCourt.CourtId)))
            .SumAsync(t => t.Amount);

        var currentBookingCount = await _dbContext.Bookings
            .Where(b => b.CreatedAt >= currentStart && b.CreatedAt <= currentEnd &&
                        (b.Status == "Banked" || b.Status == "Complete") &&
                        b.BookingDetails.Any(bd => targetCourtIds.Contains(bd.SubCourt.CourtId)))
            .CountAsync();

        var prevBookingCount = await _dbContext.Bookings
            .Where(b => b.CreatedAt >= prevStart && b.CreatedAt <= prevEnd &&
                        (b.Status == "Banked" || b.Status == "Complete") &&
                        b.BookingDetails.Any(bd => targetCourtIds.Contains(bd.SubCourt.CourtId)))
            .CountAsync();

        decimal difference = currentRevenue - prevRevenue;
        double percentage = 0;
        if (prevRevenue != 0)
        {
            percentage = (double)(difference / prevRevenue) * 100;
        }
        else if (currentRevenue != 0)
        {
            percentage = 100;
        }

        string status = "NoChange";
        if (difference > 0) status = "Increase";
        else if (difference < 0) status = "Decrease";

        int bookingDiff = currentBookingCount - prevBookingCount;
        double bookingPercentage = 0;
        if (prevBookingCount != 0)
        {
            bookingPercentage = (double)bookingDiff / prevBookingCount * 100;
        }
        else if (currentBookingCount != 0)
        {
            bookingPercentage = 100;
        }

        string bookingStatus = "NoChange";
        if (bookingDiff > 0) bookingStatus = "Increase";
        else if (bookingDiff < 0) bookingStatus = "Decrease";

        return new Response.DashboardResponse
        {
            CurrentRevenue = currentRevenue,
            PreviousRevenue = prevRevenue,
            RevenueDifference = Math.Abs(difference),
            ComparisonPercentage = Math.Round(percentage, 2),
            ComparisonStatus = status,
            CurrentBookingCount = currentBookingCount,
            PreviousBookingCount = prevBookingCount,
            BookingDifference = Math.Abs(bookingDiff),
            BookingComparisonPercentage = Math.Round(bookingPercentage, 2),
            BookingComparisonStatus = bookingStatus,
            Period = request.Period
        };
        // return response;
    }

    public async Task<Base.Response.PageResult<Response.GetCourtBookingsResponse>> GetCourtBookings(Request.GetCourtBookingsRequest request)
    {
        var ownerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
        if (ownerIdClaim == null) throw new Exception("Owner không tồn tại");
        var ownerIdGuid = Guid.Parse(ownerIdClaim);

        var court = await _dbContext.Courts.FirstOrDefaultAsync(x => x.Id == request.CourtId && x.OwnerId == ownerIdGuid);
        if (court == null) throw new Exception("Sân không tồn tại hoặc không thuộc quyền sở hữu của bạn");

        // Step 1: Lấy tất cả SubCourtId thuộc sân này
        var subCourtIds = await _dbContext.SubCourts
            .Where(sc => sc.CourtId == request.CourtId)
            .Select(sc => sc.Id)
            .ToListAsync();

        if (!subCourtIds.Any())
            return new Base.Response.PageResult<Response.GetCourtBookingsResponse>
            {
                Items = new List<Response.GetCourtBookingsResponse>(),
                TotalItems = 0,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };

        DateTimeOffset now = DateTimeOffset.Now;
        DateTimeOffset referenceDate = request.Date.HasValue
            ? new DateTimeOffset(request.Date.Value.ToDateTime(TimeOnly.MinValue), now.Offset)
            : now;

        DateTimeOffset start, end;
        switch (request.Period.ToLower())
        {
            case "week":
                int diff = (7 + (referenceDate.DayOfWeek - DayOfWeek.Monday)) % 7;
                start = referenceDate.AddDays(-1 * diff).Date;
                start = new DateTimeOffset(start.DateTime, referenceDate.Offset);
                end = start.AddDays(7).AddTicks(-1);
                break;
            case "month":
                start = new DateTimeOffset(referenceDate.Year, referenceDate.Month, 1, 0, 0, 0, referenceDate.Offset);
                end = start.AddMonths(1).AddTicks(-1);
                break;
            case "quarter":
                int quarter = (referenceDate.Month - 1) / 3 + 1;
                start = new DateTimeOffset(referenceDate.Year, (quarter - 1) * 3 + 1, 1, 0, 0, 0, referenceDate.Offset);
                end = start.AddMonths(3).AddTicks(-1);
                break;
            case "year":
                start = new DateTimeOffset(referenceDate.Year, 1, 1, 0, 0, 0, referenceDate.Offset);
                end = start.AddYears(1).AddTicks(-1);
                break;
            case "day":
            default:
                start = new DateTimeOffset(referenceDate.Year, referenceDate.Month, referenceDate.Day, 0, 0, 0, referenceDate.Offset);
                end = start.AddDays(1).AddTicks(-1);
                break;
        }

        start = start.ToUniversalTime();
        end = end.ToUniversalTime();

        // Step 2: Truy vấn Bookings có BookingDetail chứa SubCourtId của sân này
        var query = _dbContext.Bookings
            .Where(b => b.CreatedAt >= start && b.CreatedAt <= end &&
                        b.BookingDetails.Any(bd => subCourtIds.Contains(bd.SubCourtId)))
            .OrderByDescending(b => b.CreatedAt);

        var total = await query.CountAsync();
        var pagedBookings = await query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(b => new Response.GetCourtBookingsResponse
            {
                BookingId = b.Id,
                CustomerName = b.Customer.User.FirstName + " " + b.Customer.User.LastName,
                CustomerPhone = b.Customer.User.PhoneNumber ?? "",
                CourtName = court.Name,
                BookingDate = b.BookingDetails.FirstOrDefault().Date,
                TotalPrice = b.FinalPrice,
                Status = b.Status,
                CreatedAt = b.CreatedAt,
                Slots = b.BookingDetails.Select(bd => new Response.BookingSlotResponse
                {
                    StartTime = bd.StartTime,
                    EndTime = bd.EndTime,
                    Price = bd.Price
                }).ToList()
            })
            .ToListAsync();

        return new Base.Response.PageResult<Response.GetCourtBookingsResponse>
        {
            Items = pagedBookings,
            TotalItems = total,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };
    }
}

    
    
    