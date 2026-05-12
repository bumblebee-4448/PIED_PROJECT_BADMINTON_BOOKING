using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Feadback;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task CreateFeadback(Request.CreateFeadbackRequest request)
    {
        var booking = await _dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == request.BookingId);
        if (booking == null)
        {
            throw new Exception("không tìm thấy booking");
        }
        if (booking.Status != "Completed")
        {
            throw new Exception("Không thể feadback");
        }
        var getCustomerId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (getCustomerId == null)
        {
            throw new Exception("Không tìm thấy user");
        }
        var customerId = Guid.Parse(getCustomerId);
        if (request.Rating > 5 || request.Rating < 1)
        {
            throw new Exception("Chỉ có thể đánh giá từ 1 - 5 sao");
        }
        var bookingDetail = await _dbContext.BookingDetails.Include(x => x.SubCourt).FirstOrDefaultAsync(x => x.BookingId == request.BookingId);
        if (bookingDetail == null)
        {
            throw new Exception("Lỗi");
        }
        var newFeadback = new Repository.Entity.Feedback()
        {
            CustomerId = customerId,
            Rating = request.Rating,
            BookingId = request.BookingId,
            CourtId = bookingDetail.SubCourt.CourtId,
            Comment = request.Comment,
            CreatedAt = DateTimeOffset.UtcNow
        };
        
        await _dbContext.AddAsync(newFeadback);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.GetFeadbackResponse>> GetFeadback(Request.GetFeadbackRequest request)
    {
        var feadbackCourtList = _dbContext.Feedbacks.Where(x => x.CourtId == request.CourtId);
        var sort = feadbackCourtList.OrderByDescending(x => x.CreatedAt);
        var pageQuery = sort.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.GetFeadbackResponse()
        {
            NameCustomer = x.Customer.User.FirstName,
            Rating = x.Rating,
            Comment =  x.Comment,
            CreatedAt = x.CreatedAt
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetFeadbackResponse>()
        {
            Items = listResult,
            PageSize = request.PageSize,
            PageIndex = request.PageIndex,
            TotalItems = listResult.Count
        };
        return result;
    }
}