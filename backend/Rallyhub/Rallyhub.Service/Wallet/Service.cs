using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Wallet;

public class Service : IService
{
    private readonly AppDbContext _dbcontext;
    private readonly IHttpContextAccessor _httpAccessor;
    private readonly Transaction.IService _transactionService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpAccessor, Transaction.IService transactionService)
    {
        _dbcontext = dbContext;
        _httpAccessor = httpAccessor;
        _transactionService = transactionService;
    }
    
    public async Task<bool> CreateWallet(Guid userId)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        var wallet = await _dbcontext.Wallets.AnyAsync(x => x.UserId == userId);
        if (wallet)
        {
            throw new Exception("Error creating wallet");
        }
        
        var newWallet = new Repository.Entity.Wallet()
        {
            UserId = userId,
            Balance = 0,
            CreatedAt = DateTimeOffset.UtcNow,
        };
        _dbcontext.Wallets.Add(newWallet);
        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return true;
        }
        return false;
    }

    public async Task<string> AddInforWallet(Request.AddInforWalletRequest request)
    {
        var userIdGuild = Guid.Parse(_httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value);
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.UserId == userIdGuild);
        if (wallet == null)
        {
            throw new Exception("Wallet not found");
        }

        wallet.BankAccount = request.BankAccount;
        wallet.BankName = request.BankName;
        wallet.BankAccountName = request.BankAccountName;
        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success add infor wallet";
        }
        return "Failed add infor wallet";
    }

    public async Task<Response.GetInfoWalletResponse> GetInforWallet()
    {
        var userIdGuild = Guid.Parse(_httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value);
        var wallet = await _dbcontext.Wallets
            .Include(wallet => wallet.User)
            .FirstOrDefaultAsync(x => x.UserId == userIdGuild);
        if (wallet == null)
        {
            throw new Exception("Wallet not found");
        }
        var selectQuery = new Response.GetInfoWalletResponse()
        {
            Id = wallet.Id,
            FirstName = wallet.User.FirstName,
            LastName = wallet.User.LastName,
            BankName = wallet.BankName,
            BankAccount = wallet.BankAccount,
            BankAccountName = wallet.BankAccountName,
            Balance = wallet.Balance,
        };
        return selectQuery;
    }
    
    public async Task<string> RemoveBankWallet()
    {
        var userIdGuild = Guid.Parse(_httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value);
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.UserId == userIdGuild);
        if (wallet == null)
        {
            throw new Exception("Wallet not found");
        }

        wallet.BankAccount = null;
        wallet.BankName = null;
        wallet.BankAccountName = null;
        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success remove bank wallet";
        }
        return "Failed remove bank wallet";
    }
    public async Task<Response.AddBalanceToWalletFromPaymentResponse> AddBalanceToWalletFromPayment(
        decimal requestAmount)
    {
        var userIdClaim = _httpAccessor.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (userIdClaim == null)
        {
            throw new Exception("Không tìm thấy thông tin của User");
        }
        var userId = Guid.Parse(userIdClaim);
        
        var existWallet = await _dbcontext.Wallets
            .FirstOrDefaultAsync(x => x.UserId == userId);
        if (existWallet == null)
        {
            throw new Exception("Không tìm thấy ví");
        }
        var pendingTransaction = await _dbcontext.Transactions
            .FirstOrDefaultAsync(x => x.Status == "Pending" &&
                                      x.WalletId == existWallet.Id);
        if (pendingTransaction != null)
        {
            if (pendingTransaction.Amount != requestAmount)
            {
                pendingTransaction.Amount = requestAmount;
            }
            pendingTransaction.CreatedAt = DateTimeOffset.UtcNow;
            pendingTransaction.UpdatedAt = DateTimeOffset.UtcNow;
            _dbcontext.Transactions.Update(pendingTransaction);
            await _dbcontext.SaveChangesAsync();
        
            string bankName = "MBBank";
            string bankAccount = "VQRQAIUZK3222";
            string description = $"WA-{existWallet.Id:N}";
        
            string qrCodeUrl = $"https://qr.sepay.vn/img?" +
                               $"acc={bankAccount}&" +
                               $"bank={bankName}&" +
                               $"amount={requestAmount}&" +
                               $"des={description}&" +
                               $"template=qronly";
            
            return new Response.AddBalanceToWalletFromPaymentResponse
            {
                Id = existWallet.Id,
                TransactionId = pendingTransaction.Id,
                Amount = requestAmount,
                QrCodeUrl = qrCodeUrl,
            };
        }
        else
        {
            string bankName = "MBBank";
            string bankAccount = "VQRQAIUZK3222";
            string description = $"WA-{existWallet.Id:N}";
            string nguoinhan = "PHAM QUOC HOANG";
            string qrCodeUrl = $"https://qr.sepay.vn/img?" +
                               $"acc={bankAccount}&" +
                               $"bank={bankName}&" +
                               $"amount={requestAmount}&" +
                               $"des={description}&" +
                               $"template=qronly";
    
            var transactionI = new Repository.Entity.Transaction
            {
                Type = Transaction.Request.TypeList.Deposit,
                Amount = requestAmount,
                BalanceBefore = existWallet.Balance,
                BalanceAfter =  existWallet.Balance + requestAmount,
                Status = "Pending",
                WalletId =  existWallet.Id,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };
            _dbcontext.Transactions.Add(transactionI);
            await _dbcontext.SaveChangesAsync();

            return new Response.AddBalanceToWalletFromPaymentResponse
            {
                Id = existWallet.Id,
                TransactionId = transactionI.Id,
                BankName = bankName,
                BankAccount = nguoinhan,
                Amount = requestAmount,
                QrCodeUrl = qrCodeUrl,
                Created = DateTimeOffset.UtcNow,
            };
        }
    }

    public async Task<string> CheckDepositStatus(Guid transactionId)
    {
        var transaction = await _dbcontext.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId);
        if (transaction == null)
        {
            throw new ArgumentException("Transaction not found");
        }

        if (transaction.Status == "Success")
        {
            return "Success";
        }

        if (transaction.Status == "Pending")
        {
            var now = DateTimeOffset.UtcNow;
            if (now.Subtract(transaction.CreatedAt).TotalSeconds > 900) // 15 minutes timeout for banking transfers
            {
                transaction.Status = "Failed";
                transaction.UpdatedAt = now;
                _dbcontext.Transactions.Update(transaction);
                await _dbcontext.SaveChangesAsync();
                return "Expired";
            }
            return "Pending";
        }

        return transaction.Status;
    }
    public async Task<bool> AddBanlanceToWallet(Guid userId, decimal amount, string type)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.UserId == userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (wallet == null)
        {
            throw new  Exception("Wallet not found");
        }

        switch (type.ToLower())
        {
            case "payment":
            {
                break;
            }
            case "wallet":
            {
                if (wallet.BankName == null || wallet.BankAccount == null || wallet.BankAccountName == null)
                {
                    throw new Exception("Fill your bank account");
                }

                break;
            }
        }

        if (amount <= 0)
        {
            throw new Exception("Amount not valid");
        }
        wallet.Balance += amount;
        wallet.Version += 1;
        wallet.UpdatedAt = DateTimeOffset.UtcNow;
        _dbcontext.Wallets.Update(wallet);
        // var result = await _dbcontext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> ApartBanlanceFromWallet(Guid userId, decimal amount, string type)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.UserId == userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (wallet == null)
        {
            throw new  Exception("Wallet not found");
        }
        switch (type)
        {
            case "Payment":
            {
                break;
            }
            case "Wallet":
            {
                if (wallet.BankName == null || wallet.BankAccount == null || wallet.BankAccountName == null)
                {
                    throw new Exception("Fill your bank account");
                }

                break;
            }
        }
        if (wallet.Balance < amount)
        {
            throw new Exception("Balance of your wallet not enough");
        }
        if (amount <= 0)
        {
            throw new Exception("Amount not valid");
        }
        wallet.Balance -= amount;
        wallet.Version += 1;
        wallet.UpdatedAt = DateTimeOffset.UtcNow;
        _dbcontext.Wallets.Update(wallet);
        // var result = await _dbcontext.SaveChangesAsync();
        return true;
    }

    public async Task<string> AdminUpBalanceForUser(Guid userId, decimal amount, string? description)
    {
        // await AddBanlanceToWallet(userId, amount, "Wallet");
        //transsaction
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (wallet == null)
        {
            throw new  Exception("Wallet not found");
        }
        
        var transactionI = new Transaction.Request.CreateTransactionRequest()
        {
            Type = Transaction.Request.TypeList.AdminUp,
            Amount = amount,
            BalanceBefore = wallet.Balance,
            BalanceAfter =  wallet.Balance + amount,
            TransferContent = description,
            Status = "Success",
            WalletId =  wallet.Id,
        };
        if (!await AddBanlanceToWallet(userId, amount, "Payment"))
        {
            throw new Exception("Wallet reject balance failed");
        }
        if (!await _transactionService.CreateTransaction(transactionI))
        {
            throw new Exception("Error creating transaction");
        }
        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success AdminDeduct";
        }
        return "failed";
    }
}