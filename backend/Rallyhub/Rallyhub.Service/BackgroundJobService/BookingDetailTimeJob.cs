using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quartz;
using Rallyhub.Repository;

namespace Rallyhub.Service.BackgroundJobService;

public class BookingDetailTimeJob : IJob
{
    private const string PendingStatus = "Pending";
    private const string BankedStatus = "Banked";
    private const string CompletedStatus = "Completed";
    private static readonly TimeSpan BookingDetailTime = TimeSpan.FromSeconds(150);
    private readonly AppDbContext _dbContext;
    private readonly ILogger _logger;
    private readonly Wallet.IService _walletService;
    private readonly Transaction.IService _transactionService;
    private readonly Notification.IService _notificationService;

    public BookingDetailTimeJob(AppDbContext dbContext, ILogger<BookingDetailTimeJob> logger, Wallet.IService walletService, Transaction.IService transactionService, Notification.IService notificationService)
    {
        _dbContext = dbContext;
        _logger = logger;
        _walletService = walletService;
        _transactionService = transactionService;
        _notificationService = notificationService;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        var now = DateTimeOffset.UtcNow;
        var localNow = DateTime.Now;

        var bankedBookings = await _dbContext.Bookings
            .Include(x => x.BookingDetails)
                .ThenInclude(bd => bd.SubCourt)
                    .ThenInclude(sc => sc.Court)
                        .ThenInclude(c => c.Owner)
                            .ThenInclude(o => o.User)
                                .ThenInclude(u => u.Wallet)
            .Where(x => x.Status == BankedStatus)
            .ToListAsync(context.CancellationToken);

        int processedCount = 0;

        foreach (var booking in bankedBookings)
        {
            if (booking.BookingDetails == null || !booking.BookingDetails.Any()) continue;

            var earliestDetail = booking.BookingDetails.OrderBy(x => x.Date).ThenBy(x => x.StartTime).First();
            var startDateTime = earliestDetail.Date.Date.Add(earliestDetail.StartTime.ToTimeSpan());

            if (localNow >= startDateTime)
            {
                booking.Status = CompletedStatus;
                booking.UpdatedAt = now;

                foreach (var detail in booking.BookingDetails)
                {
                    detail.Status = CompletedStatus;
                    detail.UpdatedAt = now;
                }

                var owner = earliestDetail.SubCourt?.Court?.Owner;
                var wallet = owner?.User?.Wallet;

                if (wallet != null)
                {
                    var transactionI = new Transaction.Request.CreateTransactionRequest()
                    {
                        Type = Transaction.Request.TypeList.Receive,
                        Amount = booking.FinalPrice - (booking.FinalPrice * 0.05m),
                        BalanceBefore = wallet.Balance,
                        BalanceAfter = wallet.Balance + (booking.FinalPrice - (booking.FinalPrice * 0.05m)),
                        Status = "Success",
                        WalletId = wallet.Id,
                        BookingId = booking.Id,
                    };
                    
                    if (!await _walletService.AddBanlanceToWallet(wallet.UserId, booking.FinalPrice - (booking.FinalPrice * 0.05m), "Payment"))
                    {
                        throw new Exception("Wallet add balance failed");
                    }
                    if (!await _transactionService.CreateTransaction(transactionI))
                    {
                        throw new Exception("Error creating transaction");
                    }

                    _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
                    {
                        UserId = owner.UserId,
                        Title = "Cộng tiền hoàn thành Booking",
                        Content = $"Lịch đặt sân đã bắt đầu. Hệ thống cộng {booking.FinalPrice:N0}đ vào ví của bạn.",
                        Type = Notification.Request.TypeNotification.BookingCompleted,
                        BookingId = booking.Id
                    });
                }
                
                _dbContext.Update(booking);
                processedCount++;
            }
        }

        if (processedCount > 0)
        {
            await _dbContext.SaveChangesAsync(context.CancellationToken);
            _logger.LogInformation("BookingDetailTimeJob completed: {Count} banked bookings moved to Complete.", processedCount);
        }
        else
        {
            _logger.LogInformation("BookingDetailTimeJob: no banked bookings ready to complete.");
        }
    }
}