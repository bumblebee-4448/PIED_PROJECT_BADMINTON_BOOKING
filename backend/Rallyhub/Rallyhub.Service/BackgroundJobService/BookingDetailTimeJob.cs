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

    public BookingDetailTimeJob(AppDbContext dbContext, ILogger<BookingDetailTimeJob> logger, Wallet.IService  walletService, Transaction.IService transactionService)
    {
        _dbContext = dbContext;
        _logger = logger;
        _walletService = walletService;
        _transactionService = transactionService;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        var bankedDetailSeconds = (int)BookingDetailTime.TotalSeconds;
        var now = DateTimeOffset.UtcNow;

        var nowDate = now.Date;
        var nowTime = TimeOnly.FromTimeSpan(now.TimeOfDay);
        
        var pendingBankedBookingDetails = await _dbContext.BookingDetails
             .Where(x => 
                 x.Status == PendingStatus && 
                            (x.Date.Date < nowDate || (x.Date.Date == nowDate && x.EndTime < nowTime)))
             .ToListAsync(context.CancellationToken);
        if (pendingBankedBookingDetails.Count == 0)
        {
            _logger.LogInformation("BookingTimeoutJob: no expired bookings found.");
            return;
        }
        foreach (var item in pendingBankedBookingDetails)
        {
            item.Status = CompletedStatus;
            item.UpdatedAt = now;
            var booking = await _dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == item.BookingId);
            if (booking!.Status == BankedStatus)
            {
                var wallet = item.SubCourt.Court.Owner.User.Wallet;
                booking.Status = CompletedStatus;
                booking.UpdatedAt = now;
                var transactionI = new Transaction.Request.CreateTransactionRequest()
                {
                    Type = Transaction.Request.TypeList.Receive,
                    Amount = booking.FinalPrice,
                    BalanceBefore = wallet.Balance,
                    BalanceAfter =  wallet.Balance + booking.FinalPrice,
                    Status = "Success",
                    WalletId =  wallet.Id,
                };
                if (!await _walletService.AddBanlanceToWallet(wallet.UserId, booking.FinalPrice, "Payment"))
                {
                    throw new Exception("Wallet reject balance failed");
                }
                if (!await _transactionService.CreateTransaction(transactionI))
                {
                    throw new Exception("Error creating transaction");
                }
            }
            _dbContext.Update(booking);
        }
        
        _dbContext.UpdateRange(pendingBankedBookingDetails);
        await _dbContext.SaveChangesAsync(context.CancellationToken);
        _logger.LogInformation(
            "BookingDetailTimeJob completed: cancelled {CancelledCount} pending orders older than {PendingTimeoutMinutes} minutes.",
            pendingBankedBookingDetails.Count,
            bankedDetailSeconds);
    }
}