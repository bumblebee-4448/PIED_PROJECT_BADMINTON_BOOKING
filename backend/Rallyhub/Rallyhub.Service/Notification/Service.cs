using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;

namespace Rallyhub.Service.Notification;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpAccessor)
    {
        _dbContext = dbContext;
        _httpAccessor = httpAccessor;
    }

    public async Task<bool> CreateNotification(Request.CreateNotificationRequest request)
    {
        // Validation logic
        switch (request.Type)
        {
            case Request.TypeNotification.CourtHasBooking:
                if (request.BookingId == null) throw new Exception($"BookingId is required for type {request.Type}");
                if (request.CourtId == null) throw new Exception($"CourtId is required for type {request.Type}");
                break;
            case Request.TypeNotification.BookingPaid:
            case Request.TypeNotification.BookingRefunded:
                if (request.BookingId == null) throw new Exception($"BookingId is required for type {request.Type}");
                break;
            case Request.TypeNotification.FeedbackCreated:
                if (request.FeedbackId == null) throw new Exception("FeedbackId is required");
                break;
            case Request.TypeNotification.ReportCreated:
                if (request.ReportId == null) throw new Exception("ReportId is required");
                break;
            case Request.TypeNotification.SystemReportCreated:
                if (request.SystemReportId == null) throw new Exception("SystemReportId is required");
                break;
            case Request.TypeNotification.OwnerRequestSubmitted:
            case Request.TypeNotification.OwnerRequestApproved:
            case Request.TypeNotification.OwnerRequestRejected:
                if (request.OwnerRequestId == null) throw new Exception("OwnerRequestId is required");
                break;
        }

        var newNote = new Repository.Entity.Notification()
        {
            UserId = request.UserId,
            Title = request.Title,
            Type = request.Type,
            Content = request.Content,
            BookingId = request.BookingId,
            CourtId = request.CourtId,
            ReportId = request.ReportId,
            SystemReportId = request.SystemReportId,
            FeedbackId = request.FeedbackId,
            OwnerRequestId = request.OwnerRequestId,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
            IsRead = false
        };
        _dbContext.Notifications.Add(newNote);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ReadNotification(Guid notificationId)
    {
        var userIdStr = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (userIdStr == null) throw new Exception("Unauthorized");
        var userId = Guid.Parse(userIdStr);

        var notification = await _dbContext.Notifications.FirstOrDefaultAsync(x => x.Id == notificationId);
        if (notification == null)
        {
            throw new Exception("Notification not found");
        }
        
        var role = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Role)?.Value;
        bool isAdminReadingSystemNote = role == "Admin" && 
            (notification.Type == Request.TypeNotification.SystemReportCreated || 
             notification.Type == Request.TypeNotification.OwnerRequestSubmitted ||
             notification.Type == Request.TypeNotification.OwnerRequestApproved ||
             notification.Type == Request.TypeNotification.OwnerRequestRejected);

        if (notification.UserId != userId && !isAdminReadingSystemNote)
        {
            throw new Exception("Access Denied. You do not own this notification.");
        }

        if (notification.IsRead) return true;

        notification.IsRead = true;
        notification.UpdatedAt = DateTimeOffset.UtcNow;
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<int> GetUnreadCount()
    {
        var userIdStr = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (userIdStr == null) return 0;
        var userId = Guid.Parse(userIdStr);
        
        var role = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

        if (role == "Admin")
        {
            return await _dbContext.Notifications.CountAsync(x => !x.IsRead && (
                x.Type == Request.TypeNotification.SystemReportCreated || 
                x.Type == Request.TypeNotification.OwnerRequestSubmitted ||
                x.Type == Request.TypeNotification.OwnerRequestApproved ||
                x.Type == Request.TypeNotification.OwnerRequestRejected));
        }

        return await _dbContext.Notifications.CountAsync(x => x.UserId == userId && !x.IsRead);
    }

    public async Task<bool> MarkAllAsRead()
    {
        var userIdStr = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (userIdStr == null) throw new Exception("Unauthorized");
        var userId = Guid.Parse(userIdStr);

        var role = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

        IQueryable<Repository.Entity.Notification> query = _dbContext.Notifications.Where(x => !x.IsRead);
        if (role == "Admin")
        {
            query = query.Where(x => 
                x.Type == Request.TypeNotification.SystemReportCreated || 
                x.Type == Request.TypeNotification.OwnerRequestSubmitted ||
                x.Type == Request.TypeNotification.OwnerRequestApproved ||
                x.Type == Request.TypeNotification.OwnerRequestRejected);
        }
        else
        {
            query = query.Where(x => x.UserId == userId);
        }

        var unreadNotes = await query.ToListAsync();
        if (!unreadNotes.Any()) return true;

        foreach (var note in unreadNotes)
        {
            note.IsRead = true;
            note.UpdatedAt = DateTimeOffset.UtcNow;
        }
        
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Base.Response.PageResult<Response.GetNotificationResponse>> GetNotification(Base.Request.PagingRequest request)
    {
        var userIdStr = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (userIdStr == null) throw new Exception("Unauthorized");
        var userIdGuild = Guid.Parse(userIdStr);
        
        var query = _dbContext.Notifications
            .Include(n => n.Court)
            .Include(n => n.Booking)
                .ThenInclude(b => b.Customer)
                    .ThenInclude(c => c.User)
            .Include(n => n.Booking)
                .ThenInclude(b => b.BookingDetails)
                    .ThenInclude(bd => bd.SubCourt)
                        .ThenInclude(sc => sc.Court)
            .Include(n => n.Feedback)
            .Include(n => n.Report)
            .Include(n => n.SystemReport)
            .Where(x => x.UserId == userIdGuild)
            .OrderByDescending(x => x.CreatedAt);

        var total = await query.CountAsync();
        
        var list = await query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        var items = MapNotifications(list);

        return new Base.Response.PageResult<Response.GetNotificationResponse>()
        {
            Items = items,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = total,
        };
    }

    public async Task<Base.Response.PageResult<Response.GetNotificationResponse>> AdminGetNotification(Base.Request.PagingRequest request)
    {
        var query = _dbContext.Notifications
            .Include(n => n.Court)
            .Include(n => n.Booking)
                .ThenInclude(b => b.Customer)
                    .ThenInclude(c => c.User)
            .Include(n => n.Booking)
                .ThenInclude(b => b.BookingDetails)
                    .ThenInclude(bd => bd.SubCourt)
                        .ThenInclude(sc => sc.Court)
            .Include(n => n.Feedback)
            .Include(n => n.Report)
            .Include(n => n.SystemReport)
            .Where(x => 
                x.Type == Request.TypeNotification.SystemReportCreated || 
                x.Type == Request.TypeNotification.OwnerRequestSubmitted ||
                x.Type == Request.TypeNotification.OwnerRequestApproved ||
                x.Type == Request.TypeNotification.OwnerRequestRejected)
            .OrderByDescending(x => x.CreatedAt);

        var total = await query.CountAsync();
        
        var list = await query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        var items = MapNotifications(list);

        return new Base.Response.PageResult<Response.GetNotificationResponse>()
        {
            Items = items,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = total,
        };
    }

    private List<Response.GetNotificationResponse> MapNotifications(List<Repository.Entity.Notification> list)
    {
        return list.Select(x => 
        {
            object? data = null;
            var firstDetail = x.Booking?.BookingDetails?.OrderBy(bd => bd.Date).ThenBy(bd => bd.StartTime).FirstOrDefault();

            if (x.Type == Request.TypeNotification.CourtHasBooking || 
                x.Type == Request.TypeNotification.BookingPaid || 
                x.Type == Request.TypeNotification.BookingRefunded)
            {
                data = new
                {
                    BookingId = x.BookingId,
                    CourtId = x.CourtId,
                    CourtName = firstDetail?.SubCourt?.Court?.Name ?? x.Court?.Name,
                    PhoneNumber = x.Booking?.Customer?.User?.PhoneNumber,
                    Slots = x.Booking?.BookingDetails?.Select(bd => new {
                        SubCourtName = bd.SubCourt?.Name,
                        Date = bd.Date,
                        TimeStart = bd.StartTime,
                        TimeEnd = bd.EndTime
                    }).ToList()
                };
            }
            else if (x.Type == Request.TypeNotification.FeedbackCreated)
            {
                data = new
                {
                    FeedbackId = x.FeedbackId,
                    CourtName = firstDetail?.SubCourt?.Court?.Name ?? x.Court?.Name,
                    FeedbackBody = x.Feedback?.Comment,
                    RatingScore = x.Feedback?.Rating ?? 0
                };
            }
            else if (x.Type == Request.TypeNotification.ReportCreated)
            {
                data = new
                {
                    ReportId = x.ReportId,
                    CourtName = firstDetail?.SubCourt?.Court?.Name ?? x.Court?.Name,
                    Reason = x.Report?.Reason
                };
            }
            else if (x.Type == Request.TypeNotification.SystemReportCreated)
            {
                data = new
                {
                    SystemReportId = x.SystemReportId,
                    Reason = x.SystemReport?.Reason
                };
            }
            else if (x.Type == Request.TypeNotification.OwnerRequestSubmitted ||
                     x.Type == Request.TypeNotification.OwnerRequestApproved ||
                     x.Type == Request.TypeNotification.OwnerRequestRejected)
            {
                data = new
                {
                    OwnerRequestId = x.OwnerRequestId
                };
            }
            
            return new Response.GetNotificationResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                Title = x.Title,
                Content = x.Content,
                Type = x.Type,
                IsRead = x.IsRead,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                Data = data
            };
        }).ToList();
    }
}