using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.SepayService;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly Transaction.IService _transactionService;
    private readonly Wallet.IService _walletService;
    private readonly Notification.IService _notificationService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext, Transaction.IService transactionService,
        Wallet.IService walletService, Notification.IService notificationService)
    {
        _dbContext = dbContext;
        _transactionService = transactionService;
        _walletService = walletService;
        _notificationService = notificationService;
    }

    public async Task<bool> BookingSepayWebhookHandler(Request.SepayWebhookRequest request)
    {
        var description = request.Code;
        if (string.IsNullOrEmpty(description))
        {
            throw new Exception("Description is empty");
        }

        if (description.StartsWith("RA"))
        {
            var raw = description.Replace("RA", "");

            if (string.IsNullOrEmpty(raw) || raw.Length < 28)
            {
                throw new Exception("Error code");
            }

            var formatted =
                $"{raw.Substring(0, 8)}-" +
                $"{raw.Substring(8, 4)}-" +
                $"{raw.Substring(12, 4)}-" +
                $"{raw.Substring(16, 4)}-" +
                $"{raw.Substring(20, 10)}";

            Repository.Entity.Booking? targetBooking = null;

            if (Guid.TryParse(formatted, out var exactGuid))
            {
                targetBooking = await _dbContext.Bookings
                    .Include(x => x.BookingDetails)
                        .ThenInclude(bd => bd.SubCourt)
                            .ThenInclude(sc => sc.Court)
                                .ThenInclude(c => c.Owner)
                    .Include(x => x.Customer)
                    .FirstOrDefaultAsync(x => x.Id == exactGuid);
            }

            if (targetBooking == null)
            {
                targetBooking = await _dbContext.Bookings
                    .Include(x => x.BookingDetails)
                        .ThenInclude(bd => bd.SubCourt)
                            .ThenInclude(sc => sc.Court)
                                .ThenInclude(c => c.Owner)
                    .Include(x => x.Customer)
                    .Where(x => EF.Functions.TrigramsSimilarity(x.Id.ToString(), formatted) > 0.68)
                    .OrderBy(x => EF.Functions.TrigramsSimilarityDistance(x.Id.ToString(), formatted))
                    .FirstOrDefaultAsync();
            }

            if (targetBooking == null)
            {
                throw new Exception("Not found");
            }

            if (targetBooking.Status != "Pending")
            {
                throw new Exception("Booking is completed or banked");
            }

            if (targetBooking.FinalPrice != request.TransferAmount)
            {
                throw new Exception("Invalid transfer amount");
            }

            targetBooking.Status = "Banked";
            targetBooking.UpdatedAt = DateTimeOffset.UtcNow;

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == targetBooking.Customer.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (wallet == null)
            {
                throw new Exception("Wallet not found");
            }
            var transactionI = new Transaction.Request.CreateTransactionRequest()
            {
                Type = Transaction.Request.TypeList.PaymentByBank,
                Amount = request.TransferAmount,
                BalanceBefore = wallet.Balance,
                BalanceAfter = wallet.Balance,
                Status = "Success",
                SePayId = request.Id.ToString(), //
                BankRefCode = request.ReferenceCode, //
                BankAccountNumber = request.AccountNumber,
                TransferContent = request.Content, //
                ActionCode = request.Code, //
                Signature = request.Description, //
                BookingId = targetBooking.Id, //
                WalletId = wallet.Id,
            };

            if (!await _transactionService.CreateTransaction(transactionI))
            {
                throw new Exception("Error creating transaction");
            }
            foreach (var detail in targetBooking.BookingDetails)
            {
                detail.Status = "Banked";
                detail.UpdatedAt = DateTimeOffset.UtcNow;
            }

            var ownerUserId = targetBooking.BookingDetails.FirstOrDefault()?.SubCourt?.Court?.Owner?.UserId;
            if (ownerUserId != null)
            {
                _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
                {
                    UserId = ownerUserId.Value,
                    Title = "Thanh toán thành công",
                    Content = $"Khách hàng vừa thanh toán {request.TransferAmount:N0}đ qua mã QR.",
                    Type = Notification.Request.TypeNotification.BookingPaid,
                    BookingId = targetBooking.Id
                });
            }

            _dbContext.Update(targetBooking);
            await _dbContext.SaveChangesAsync();

            

            return true;
        }
        else if (description.StartsWith("WA"))
        {
            var raw = description.Replace("WA", "");

            if (string.IsNullOrEmpty(raw) || raw.Length < 28)
            {
                throw new Exception("Error code");
            }

            var formatted =
                $"{raw.Substring(0, 8)}-" +
                $"{raw.Substring(8, 4)}-" +
                $"{raw.Substring(12, 4)}-" +
                $"{raw.Substring(16, 4)}-" +
                $"{raw.Substring(20, 10)}";

            Repository.Entity.Transaction? targetTransaction = null;
            if (Guid.TryParse(formatted, out var exactGuid))
            {
                targetTransaction = await _dbContext.Transactions
                    .Include(x => x.Wallet)
                    .FirstOrDefaultAsync(x => x.Id == exactGuid);
            }

            if (targetTransaction == null)
            {
                targetTransaction = await _dbContext.Transactions
                    .Include(x => x.Wallet)
                    .Where(x => EF.Functions.TrigramsSimilarity(x.Id.ToString(), formatted) > 0.68)
                    .OrderBy(x => EF.Functions.TrigramsSimilarityDistance(x.Id.ToString(), formatted))
                    .FirstOrDefaultAsync();
            }

            if (targetTransaction == null)
            {
                throw new Exception("Not found");
            }

            if (targetTransaction.Status != "Pending")
            {
                throw new Exception("Transaction is completed or banked");
            }

            if (targetTransaction.Amount != request.TransferAmount)
            {
                throw new Exception("Invalid transfer amount");
            }

            var targetWallet = targetTransaction.Wallet;
            if (targetWallet == null)
            {
                throw new Exception("Wallet not found");
            }

            if (!await _walletService.AddBanlanceToWallet(targetWallet.UserId, request.TransferAmount, "Payment"))
            {
                throw new Exception("Wallet reject balance failed");
            }

            targetTransaction.Status = "Success";
            targetTransaction.SePayId = request.Id.ToString(); //
            targetTransaction.BankRefCode = request.ReferenceCode; //
            targetTransaction.BankAccountNumber = request.AccountNumber;
            targetTransaction.TransferContent = request.Content; //
            targetTransaction.ActionCode = request.Code; //
            targetTransaction.Signature = request.Description; //
            targetTransaction.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Update(targetTransaction);
            
            _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
            {
                UserId = targetWallet.UserId,
                Title = "Nạp tiền thành công",
                Content = $"Bạn đã nạp thành công {request.TransferAmount:N0}đ vào ví qua chuyển khoản ngân hàng.",
                Type = Notification.Request.TypeNotification.WalletDepositSuccess
            });

            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;
        }
        else
        {
            throw new Exception("Unknown prefix");
        }
    }
}