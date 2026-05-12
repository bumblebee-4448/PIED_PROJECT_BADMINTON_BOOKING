
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Exception = System.Exception;
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

    public async Task<Base.Response.PageResult<Response.SearchCourtResponse>> SearchByFilter(
        Request.SearchByFilterRequest request)
    {
        var query = _dbContext.Courts
            .Where(x => x.Status == "Active")
            .Select(x => new
            {
                Court = x,
                AverageRating = _dbContext.Feedbacks
                    .Where(f => f.CourtId == x.Id)
                    .Select(f => (double?)f.Rating)  
                    .Average() ?? 0,
            });
        if (request.Keyword != null)
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
            Address = x.Court.Address,
            Status = x.Court.Status,
            AverageRating = x.AverageRating,
            PictureUrl = x.Court.PictureUrl,
            DefaultPrice = x.Court.SubCourts.First().ConfigSlots.First().Price
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
                Description = court.Description,
                DefaultPrice = court.SubCourts.First().ConfigSlots.First().Price,
            })
            .FirstOrDefaultAsync();

        if (courtResult == null)
        {
            throw new Exception("Không tìm thấy sân");
        }

        return courtResult;
    }
    public async Task<Response.ListSubCourtResponse> GetSubCourtById(Guid courtId)
    {
        var allSubCourts = await _dbContext.SubCourts
            .Where(x => x.CourtId == courtId && x.Court.Status == "Active")
            .OrderBy(x => x.Name)
            .Select(x => new Response.SubCourtResponse
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        if (allSubCourts.Count == 0)
        {
            throw new Exception($"Không tìm thấy sân con nào");
        }

        return new Response.ListSubCourtResponse
        {
            SubCourts = allSubCourts,
            TotalSubCount = allSubCourts.Count
        };
    }
    
}