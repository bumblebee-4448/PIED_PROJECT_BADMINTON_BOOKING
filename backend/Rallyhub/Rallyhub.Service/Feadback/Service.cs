using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Feadback;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Notification.IService _notificationService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, Notification.IService notificationService)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _notificationService = notificationService;
    }

    public async Task CreateFeedback(Request.CreateFeedbackRequest request)
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
        var bookingDetail = await _dbContext.BookingDetails
            .Include(x => x.SubCourt)
                .ThenInclude(sc => sc.Court)
                    .ThenInclude(c => c.Owner)
            .FirstOrDefaultAsync(x => x.BookingId == request.BookingId);
        if (bookingDetail == null)
        {
            throw new Exception("Lỗi");
        }
        var newFeedback = new Repository.Entity.Feedback()
        {
            CustomerId = customerId,
            Rating = request.Rating,
            BookingId = request.BookingId,
            CourtId = bookingDetail.SubCourt.CourtId,
            Comment = request.Comment,
            CreatedAt = DateTimeOffset.UtcNow
        };
        
        await _dbContext.AddAsync(newFeedback);

        var ownerUserId = bookingDetail.SubCourt.Court.Owner?.UserId;
        if (ownerUserId != null)
        {
            _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
            {
                UserId = ownerUserId.Value,
                Title = "Nhận được đánh giá mới",
                Content = $"Sân của bạn vừa nhận được đánh giá {request.Rating} sao từ khách hàng.",
                Type = Notification.Request.TypeNotification.FeedbackCreated,
                FeedbackId = newFeedback.Id,
                CourtId = bookingDetail.SubCourt.CourtId
            });
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.GetFeedbackResponse>> GetFeedback(Request.GetFeedbackRequest request)
    {
        var feadbackCourtList = _dbContext.Feedbacks.Where(x => x.CourtId == request.CourtId && x.IsDeleted == false);
        var sort = feadbackCourtList.OrderByDescending(x => x.CreatedAt);
        var pageQuery = sort.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.GetFeedbackResponse()
        {
            NameCustomer = x.Customer.User.FirstName,
            Rating = x.Rating,
            Comment =  x.Comment,
            CreatedAt = x.CreatedAt
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetFeedbackResponse>()
        {
            Items = listResult,
            PageSize = request.PageSize,
            PageIndex = request.PageIndex,
            TotalItems = listResult.Count
        };
        return result;
    }

    public async Task DeteteFeedback(Request.DeteteFeedbackRequest request)
    {
        var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (feedback == null)
        {
            throw new Exception("feedback not found");
        }

        if (feedback.IsDeleted)
        {
            throw new Exception("feedback not exist");
        }
        feedback.IsDeleted = true;
        feedback.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.Update(feedback);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateFeeback(Request.UpdateFeedbackRequest request)
    {
        var getCustomerId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (getCustomerId == null)
        {
            throw new Exception("CustomerId not found");
        }
        var customerId = Guid.Parse(getCustomerId);
        var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.CustomerId == customerId && x.BookingId == request.BookingId);
        if (feedback == null)
        {
            throw new Exception("feedback not found");
        }

        if (request.Rating > 5 || request.Rating < 1)
        {
            throw new Exception("Chỉ có thể đánh giá từ 1 - 5 sao");
        }
        feedback.Rating = request.Rating;
        feedback.Comment = request.Comment;
        feedback.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.Update(feedback);
        await _dbContext.SaveChangesAsync();
    }
}