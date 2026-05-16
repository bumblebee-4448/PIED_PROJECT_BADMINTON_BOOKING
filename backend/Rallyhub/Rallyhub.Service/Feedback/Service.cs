using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Feedback;

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
            throw new ArgumentException("không tìm thấy booking");
        }
        if (booking.Status != "Completed")
        {
            throw new ArgumentException("Không thể feedback cho booking chưa hoàn thành");
        }
        var now = DateTimeOffset.UtcNow;
        if (now - booking.UpdatedAt > TimeSpan.FromDays(30))
        {
            throw new ArgumentException("Đã quá 30 ngày kể từ khi hoàn thành, bạn không thể tạo đánh giá nữa");
        }
        var getCustomerId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (getCustomerId == null)
        {
            throw new ArgumentException("Không tìm thấy user");
        }
        var customerId = Guid.Parse(getCustomerId);
        if (request.Rating > 5 || request.Rating < 1)
        {
            throw new ArgumentException("Chỉ có thể đánh giá từ 1 - 5 sao");
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
        var court = bookingDetail.SubCourt.Court;
        var newFeedback = new Repository.Entity.Feedback()
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Rating = request.Rating,
            BookingId = request.BookingId,
            CourtId = court.Id,
            Comment = request.Comment,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };
        
        await _dbContext.AddAsync(newFeedback);

        var ownerUserId = court.Owner?.UserId;
        if (ownerUserId != null)
        {
            _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
            {
                UserId = ownerUserId.Value,
                Title = "Đánh giá mới cho sân",
                Content = $"Sân '{court.Name}' của bạn vừa nhận được đánh giá {request.Rating} sao từ khách hàng.",
                Type = Notification.Request.TypeNotification.FeedbackCreated,
                FeedbackId = newFeedback.Id,
                CourtId = court.Id
            });
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.GetFeedbackResponse>> GetFeedback(Request.GetFeedbackRequest request)
    {
        if (request.PageIndex < 1)
            throw new Exception("PageIndex must be greater than or equal to 1");
        var feadbackCourtList = _dbContext.Feedbacks
            .Where(x => 
                x.CourtId == request.CourtId && 
                x.IsDeleted == false);
        
        var totalCount = await feadbackCourtList.CountAsync();
        
        var selectQuery = await feadbackCourtList
            .OrderByDescending(x => x.CreatedAt)
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new Response.GetFeedbackResponse()
            {
                Id = x.Id,
                NameCustomer = x.Customer.User.FirstName + " "  + x.Customer.User.LastName,
                Rating = x.Rating,
                Comment =  x.Comment,
                CreatedAt = x.CreatedAt
            }).ToListAsync();
        var result = new Base.Response.PageResult<Response.GetFeedbackResponse>()
        {
            Items = selectQuery,
            PageSize = request.PageSize,
            PageIndex = request.PageIndex,
            TotalItems = totalCount
        };
        return result;
    }

    public async Task<Response.GetFeedbackResponse> FeedbackByBookingId(Guid bookingId)
    {
        var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.BookingId == bookingId && x.IsDeleted == false);
        if (feedback == null)
        {
            throw new ArgumentException("Không tìm thấy feedback");
        }

        return new Response.GetFeedbackResponse()
        {
            Id = feedback.Id,
            NameCustomer = feedback.Customer.User.FirstName + " " + feedback.Customer.User.LastName,
            Rating = feedback.Rating,
            Comment = feedback.Comment,
            CreatedAt = feedback.CreatedAt
        };
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
        // var getCustomerId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        // if (getCustomerId == null)
        // {
        //     throw new Exception("CustomerId not found");
        // }
        // var customerId = Guid.Parse(getCustomerId);
        // var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.CustomerId == customerId && x.BookingId == request.BookingId);
        // if (feedback == null)
        // {
        //     throw new Exception("feedback not found");
        // }
        var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (feedback == null)
        {
            throw new Exception("Không tìm thấy đánh giá");
        }
        var booking = await _dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == feedback.BookingId);
        if (booking == null)
        {
            throw new Exception("Không tìm thấy thông tin đơn đặt sân");
        }

        var now = DateTimeOffset.UtcNow;
        if (now - booking.UpdatedAt > TimeSpan.FromDays(30))
        {
            throw new Exception("Đã quá 30 ngày kể từ khi hoàn thành, bạn không thể chỉnh sửa đánh giá nữa");
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