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

        // 1. Lấy danh sách booking đang chờ hoàn tất (Banked)
        var bookings = await _dbContext.Bookings
            .Include(x => x.BookingDetails).ThenInclude(bd => bd.SubCourt).ThenInclude(sc => sc.Court).ThenInclude(c => c.Owner).ThenInclude(o => o.User).ThenInclude(u => u.Wallet)
            .Where(x => x.Status == BankedStatus)
            .ToListAsync(context.CancellationToken);

        foreach (var booking in bookings)
        {
            // 2. Kiểm tra xem đã đến giờ đánh chưa (dựa trên detail sớm nhất)
            var earliest = booking.BookingDetails.OrderBy(x => x.Date).ThenBy(x => x.StartTime).FirstOrDefault();
            if (earliest == null || localNow < earliest.Date.Date.Add(earliest.StartTime.ToTimeSpan())) continue;

            // 3. Xử lý hoàn tất và cộng tiền trong một Transaction
            using var transaction = await _dbContext.Database.BeginTransactionAsync(context.CancellationToken);
            try
            {
                // Cập nhật trạng thái
                booking.Status = CompletedStatus;
                booking.UpdatedAt = now;
                foreach (var d in booking.BookingDetails) { d.Status = CompletedStatus; d.UpdatedAt = now; }

                // Cộng tiền cho chủ sân (Trừ 5% phí)
                var wallet = earliest.SubCourt?.Court?.Owner?.User?.Wallet;
                if (wallet != null)
                {
                    decimal amount = booking.FinalPrice * 0.95m;
                    
                    await _walletService.AddBanlanceToWallet(wallet.UserId, amount, "Payment");
                    await _transactionService.CreateTransaction(new Transaction.Request.CreateTransactionRequest
                    {
                        Type = Transaction.Request.TypeList.Receive,
                        Amount = amount,
                        BalanceBefore = wallet.Balance - amount,
                        BalanceAfter = wallet.Balance,
                        Status = "Success",
                        WalletId = wallet.Id,
                        BookingId = booking.Id,
                        TransferContent = $"Thanh toán lịch đặt {booking.Id}"
                    });

                    _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
                    {
                        UserId = wallet.UserId,
                        Title = "Cộng tiền hoàn thành Booking",
                        Content = $"Sân {earliest.SubCourt?.Court?.Name} đã bắt đầu. +{amount:N0}đ vào ví.",
                        Type = Notification.Request.TypeNotification.BookingCompleted,
                        BookingId = booking.Id
                    });
                }

                await _dbContext.SaveChangesAsync(context.CancellationToken);
                await transaction.CommitAsync(context.CancellationToken);
                _logger.LogInformation($"Booking {booking.Id} processed successfully.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(context.CancellationToken);
                _logger.LogError(ex, $"Failed to process booking {booking.Id}");
            }
        }
    }
}