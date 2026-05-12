
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Exception = System.Exception;
namespace Rallyhub.Service.Court;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContext;
    private readonly Validation.IService _validationService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext,  Validation.IService validationService)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
        _validationService = validationService;
    }

    public async Task<Base.Response.PageResult<Response.SearchCourtResponse>> SearchByFilter(
        Request.SearchByFilterRequest request)
    {
        var rawList = await _dbContext.Courts
            .Where(x => x.Status == "Active")
            .Select(x => new
            {
                Court = x,
                AverageRating = Math.Round(
                    _dbContext.Feedbacks
                        .Where(f => f.CourtId == x.Id)
                        .Select(f => (double?)f.Rating)  
                        .Average() ?? 0, 1),
                TotalFeedbacks = _dbContext.Feedbacks
                    .Count(f => f.CourtId == x.Id),
                TotalBooked = _dbContext.BookingDetails
                    .Count(b => b.SubCourt.CourtId == x.Id),
            })
            .ToListAsync();
        
        if (request.Keyword != null)
        {
            var keyword = _validationService.RemoveDiacritics(request.Keyword.Trim().ToLower());
            rawList = rawList
                .Where(x =>
                    _validationService.RemoveDiacritics(x.Court.Name.ToLower().Trim()).Contains(keyword) ||
                    _validationService.RemoveDiacritics(x.Court.Address.ToLower().Trim()).Contains(keyword))
                .ToList();
        }

        rawList = request.SortBy?.ToLower() switch
        {
            "name" => request.IsDescending
                ? rawList.OrderByDescending(x => x.Court.Name).ToList()
                : rawList.OrderBy(x => x.Court.Name).ToList(),

            "rate" => request.IsDescending
                ? rawList.OrderByDescending(x => x.AverageRating)
                    .ThenByDescending(x => x.Court.Name).ToList()
                : rawList.OrderBy(x => x.AverageRating).ToList(),

            _ => rawList.OrderByDescending(x => x.AverageRating).ToList()
        };

        var totalItems =  rawList.Count();
        var listResult = rawList
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new Response.SearchCourtResponse()
            {
                CourtId = x.Court.Id,
                Name = x.Court.Name,
                Address = x.Court.Address,
                Status = x.Court.Status,
                AverageRating = x.AverageRating,
                TotalFeedbacks = x.TotalFeedbacks,
                TotalBooked = x.TotalBooked,
                PictureUrl = x.Court.PictureUrl,
                DefaultPrice = x.Court.SubCourts.FirstOrDefault()?.ConfigSlots.FirstOrDefault()?.Price ?? 0,
                PhoneNumber = x.Court.Owner != null && x.Court.Owner.User != null ? x.Court.Owner.User.PhoneNumber : "",
            }).ToList();
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
            .Include(x => x.Feedbacks)
            .Where(x => x.Id == courtId)
            .Select(court => new Response.SearchCourtByIdResponse
            {
                CourtId = court.Id,
                Name = court.Name,
                Address = court.Address,
                Status = court.Status,
                AverageRating = court.Feedbacks.Any() ? Math.Round(court.Feedbacks.Average(f => (double)f.Rating), 1) : 0,
                OpenTime = court.OpenTime,
                CloseTime = court.CloseTime,
                PhoneNumber = court.Owner != null && court.Owner.User != null ? court.Owner.User.PhoneNumber : "",
                PictureUrl = court.PictureUrl,
                MapUrl = court.MapUrl,
                Description = court.Description,
                DefaultPrice = court.SubCourts.First().ConfigSlots.First().Price,
                Feedbacks = court.Feedbacks
                    .OrderBy(x => x.CreatedAt) 
                    .Take(5)
                    .Select(x => new Response.FeedbackPreviewResponse()
                {
                    NameCustomer = x.Customer.User.FirstName,
                    Rating = x.Rating,
                    Comment =  x.Comment!,
                    CreatedAt = x.CreatedAt
                }).ToList()
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