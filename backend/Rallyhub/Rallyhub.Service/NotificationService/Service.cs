using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;

namespace Rallyhub.Service.NotificationService;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly Transaction.IService _transactionService;
    private readonly Wallet.IService _walletService;
    private readonly Booking.IService _booking;

    public Service(AppDbContext dbContext, Transaction.IService transactionService, Wallet.IService walletService, Booking.IService booking)
    {
        _dbContext = dbContext;
        _transactionService = transactionService;
        _walletService = walletService;
        _booking = booking;
    }

    public async Task<bool> CreateNotification(Request.CreateNotificationRequest request)
    {
        
        var newNote = new Notification
        {
            UserId = request.UserId,
            Title = request.Title,
            Type = request.Type,
            Content = request.Content,
            BookingId = request.BookingId,
            CourtId = request.CourtId,
            TransactionId = request.TransactionId,
            ReportId = request.ReportId,
            SystemReportId = request.SystemReportId,
            FeedbackId = request.FeedbackId,
            OwnerRequestId = request.OwnerRequestId,
            CreatedAt = DateTimeOffset.UtcNow,
            IsRead = false
        };
        _dbContext.Notifications.Add(newNote);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> ReadNotification(Guid notificationId)
    {
        var notification = await _dbContext.Notifications.FirstOrDefaultAsync(x => x.Id == notificationId);
        if (notification == null)
        {
            throw new Exception("Notification not found");
        }
        notification.IsRead = true;
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return true;
        }
        return false;
    }

    // public async Task<Base.Response.PageResult<Response.GetNotificationResponse>> GetNotification(Base.Request.PagingRequest request)
    // {
    //     var notification = await _dbContext.Notifications.FirstOrDefaultAsync(x => x.Id == notificationId);
    //     if (notification == null)
    //     {
    //         throw new Exception("Notification not found");
    //     }
    //     
    // }
}