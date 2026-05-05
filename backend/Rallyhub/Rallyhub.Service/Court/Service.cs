using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using StatusCourt = Rallyhub.Service.Enum.Enum.StatusCreateCourt;
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
    
    public async Task<Base.Response.PageResult<Response.SearchCourtResponse>> SearchByFilter(Request.SearchByFilterRequest request)
    {
        if (request.PageIndex <= 0)  
        {        
            throw new ArgumentException("PageIndex must be greater than 0");  
        }  
        if (request.PageSize <= 0)  
        {        
            throw new ArgumentException("PageSize must be greater than 0");  
        }    
        var  query = _dbContext.Courts
            .Where(x => x.Status == nameof(StatusCourt.Active))
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

    public async Task<Response.SearchCourtByIdResponse> GetCourtsDetailById(Guid courtId)
    {
        var courtResult = await _dbContext.Courts
            .Where(x => x.Id == courtId)
            .Select(court => new Response.SearchCourtByIdResponse
            {
                CourtId = court.Id,
                Name = court.Name,
                Address = court.Address,
                Status = court.Status,
                AverageRating = court.Feedbacks.Any() ? court.Feedbacks.Average(f => (double)f.Rating) : 0,
                OpenTime = court.OpenTime,
                CloseTime = court.CloseTime,
                PhoneNumber = court.Owner != null && court.Owner.User != null ? court.Owner.User.PhoneNumber : "",
                PictureUrl = court.PictureUrl,
                MapUrl = court.MapUrl,
                Description = court.Description
            })
            .FirstOrDefaultAsync();

        if (courtResult == null)
        {
            throw new Exception($"court with id {courtId} not found");
        }

        return courtResult;
    }

    public async Task<Response.ListSubCourtResponse> GetSubCourtById(Guid courtId)
    {
        var allSubCourts = await _dbContext.SubCourts
            .Where(x => x.CourtId == courtId && x.Court.Status == nameof(StatusCourt.Active))
            .OrderBy(x => x.Name)
            .Select(x => new Response.SubCourtResponse
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        if (allSubCourts.Count == 0)
        {
            throw new Exception($"Không tìm thấy sân con nào thuộc court {courtId}");
        }

        return new Response.ListSubCourtResponse
        {
            SubCourts = allSubCourts,
            TotalSubCount = allSubCourts.Count 
        };
    }

    public async Task<List<Response.SlotResponse>> GetAvailableSlots(Request.GetAvailableSlotsRequest request)
    {
        var subCourt = await _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefaultAsync(x => 
                x.Id == request.SubCourtId && 
                x.Court.Status == nameof(StatusCourt.Active));
        if (subCourt == null)
        {
            throw new Exception($"sub court with id {request.SubCourtId} not found");
        }
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (request.Date < today)
        {
            throw new Exception("Không thể xem slot trong quá khứ");
        }
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
        //Apply override 
        foreach (var ov in overrides)
        {
            //remove slot bi override
            result.RemoveAll(x => 
                x.StartTime >= ov.StartTime && 
                x.EndTime <= ov.EndTime);
            //add slot moi
            result.Add(new Response.SlotResponse
            {
                StartTime = ov.StartTime,
                EndTime = ov.EndTime,
                Price = ov.Price,
                IsAvailable = true
            });
        }
        //Apply exception 
        foreach (var ex in exceptions)
        {
            result.RemoveAll(x =>
                x.StartTime < ex.EndTime &&
                x.EndTime > ex.StartTime);
        }
        var bookedSlots = await _dbContext.BookingDetails
            .Where(x =>
                x.SubCourtId == request.SubCourtId &&
                x.Date.Date == request.Date.ToDateTime(TimeOnly.MinValue).Date && 
                (x.Status == "Pending" || x.Status == "Banked"))
            .ToListAsync();
        
        foreach (var slot in result)
        {
            slot.IsAvailable = !bookedSlots.Any(b =>
                b.StartTime < slot.EndTime &&
                b.EndTime > slot.StartTime);
        }
        return result.OrderBy(x => x.StartTime).ToList();
    }
}