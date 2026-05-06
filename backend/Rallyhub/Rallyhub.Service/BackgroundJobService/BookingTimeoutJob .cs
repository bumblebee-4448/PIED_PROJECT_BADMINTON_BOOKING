using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quartz;
using Rallyhub.Repository;

namespace Rallyhub.Service.BackgroundJobService;

[DisallowConcurrentExecution]
public class BookingTimeoutJob  : IJob
{
    private const string PendingStatus = "Pending";
    private const string CancelledStatus = "Cancelled";
    private static readonly TimeSpan BookingTimeout = TimeSpan.FromSeconds(20);
    
    private readonly AppDbContext _dbContext;
    private readonly ILogger _logger;

    public BookingTimeoutJob(AppDbContext dbContext, ILogger<BookingTimeoutJob> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        var pendingTimeoutMinutes = (int)BookingTimeout.TotalSeconds;
        var now = DateTimeOffset.UtcNow;
        
        var expiredPendingBookings = await _dbContext.Bookings
            .Include(x => x.BookingDetails)
            .Where(x => x.Status ==  PendingStatus && x.ExpiresAt < now)
            .ToListAsync(context.CancellationToken);

        if (expiredPendingBookings.Count == 0)
        {
            _logger.LogInformation("BookingTimeoutJob: no expired bookings found.");
            return;
        }

        foreach (var booking in expiredPendingBookings)
        {
            booking.Status = CancelledStatus;
            booking.UpdatedAt = now;

            foreach (var detail in booking.BookingDetails)
            {
                detail.Status = CancelledStatus;
            }
        }
        
        _dbContext.Bookings.UpdateRange(expiredPendingBookings);
        await _dbContext.SaveChangesAsync(context.CancellationToken);
        
        _logger.LogInformation(
            "BookingTimeoutJob: cancelled {Count} expired bookings (timeout = {Timeout} minutes).",
            expiredPendingBookings.Count,
            pendingTimeoutMinutes);
    }
}