using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Feedback;

public class Service: IService
{
    private const string CompleteStatus = "Complete";
    private const string CompletedStatus = "Completed";

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
        if (booking == null) throw new ArgumentException("Không tìm thấy booking");

        if (!IsCompletedBooking(booking.Status))
        {
            throw new ArgumentException("Chỉ có thể đánh giá sau khi đã hoàn thành buổi chơi");
        }

        var now = DateTimeOffset.UtcNow;
        if (now - booking.UpdatedAt > TimeSpan.FromDays(30))
        {
            throw new ArgumentException("Đã quá hạn 30 ngày để tạo đánh giá");
        }

        var customerIdStr = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (string.IsNullOrEmpty(customerIdStr)) throw new ArgumentException("Không tìm thấy thông tin khách hàng");
        var customerId = Guid.Parse(customerIdStr);

        if (booking.CustomerId != customerId)
        {
            throw new ArgumentException("Bạn không có quyền đánh giá booking này");
        }

        if (request.Rating > 5 || request.Rating < 1)
        {
            throw new ArgumentException("Số sao đánh giá phải từ 1 đến 5");
        }

        var existingFeedback = await _dbContext.Feedbacks
            .FirstOrDefaultAsync(x => x.BookingId == request.BookingId);

        var bookingDetail = await _dbContext.BookingDetails
            .Include(x => x.SubCourt).ThenInclude(sc => sc.Court).ThenInclude(c => c.Owner)
            .FirstOrDefaultAsync(x => x.BookingId == request.BookingId);

        if (bookingDetail == null) throw new Exception("Không tìm thấy chi tiết booking");
        
        var court = bookingDetail.SubCourt.Court;
        if (existingFeedback != null)
        {
            if (existingFeedback.CustomerId != customerId)
            {
                throw new ArgumentException("Bạn không có quyền chỉnh sửa đánh giá này");
            }

            existingFeedback.Rating = request.Rating;
            existingFeedback.Comment = request.Comment;
            existingFeedback.CourtId = court.Id;
            existingFeedback.CustomerId = customerId;
            existingFeedback.IsDeleted = false;
            existingFeedback.UpdatedAt = DateTimeOffset.UtcNow;
            await _dbContext.SaveChangesAsync();
            return;
        }

        var newFeedback = new Repository.Entity.Feedback()
        {
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
                BookingId = x.BookingId,
                CourtId = x.CourtId,
                CustomerId = x.CustomerId,
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

    public async Task<Response.GetFeedbackResponse?> FeedbackByBookingId(Guid bookingId)
    {
        var feedback = await _dbContext.Feedbacks
            .Include(x => x.Customer).ThenInclude(c => c.User)
            .FirstOrDefaultAsync(x => x.BookingId == bookingId && x.IsDeleted == false);
            
        if (feedback == null) return null;

        return new Response.GetFeedbackResponse()
        {
            Id = feedback.Id,
            BookingId = feedback.BookingId,
            CourtId = feedback.CourtId,
            CustomerId = feedback.CustomerId,
            NameCustomer = feedback.Customer.User.FirstName + " " + feedback.Customer.User.LastName,
            Rating = feedback.Rating,
            Comment = feedback.Comment,
            CreatedAt = feedback.CreatedAt
        };
    }

    public async Task DeleteFeedback(Request.DeteteFeedbackRequest request)
    {
        var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (feedback == null || feedback.IsDeleted) throw new Exception("Không tìm thấy đánh giá");

        // Kiểm tra quyền sở hữu hoặc quyền Admin
        var customerIdStr = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        var role = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
        
        if (feedback.CustomerId.ToString() != customerIdStr && role != "Admin")
        {
            throw new Exception("Bạn không có quyền xóa đánh giá này");
        }

        feedback.IsDeleted = true;
        feedback.UpdatedAt = DateTimeOffset.UtcNow;
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateFeedback(Request.UpdateFeedbackRequest request)
    {
        var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (feedback == null) throw new Exception("Không tìm thấy đánh giá");

        var customerIdStr = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (feedback.CustomerId.ToString() != customerIdStr)
        {
            throw new Exception("Bạn không có quyền chỉnh sửa đánh giá này");
        }

        var booking = await _dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == feedback.BookingId);
        if (booking == null) throw new Exception("Không tìm thấy thông tin đơn đặt sân");

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
        feedback.IsDeleted = false;
        feedback.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.Update(feedback);
        await _dbContext.SaveChangesAsync();
    }

    private static bool IsCompletedBooking(string status)
    {
        return status == CompleteStatus || status == CompletedStatus;
    }
}
