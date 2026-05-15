using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Withdrawal;

public class Service : IService
{
    private readonly AppDbContext _dbcontext;
    private readonly IHttpContextAccessor _httpAccessor;
    private readonly Wallet.IService _walletService;
    private readonly Transaction.IService _transactionService;
    private readonly Notification.IService _notificationService;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpAccessor,  Wallet.IService walletService,  Transaction.IService transactionService, Notification.IService notificationService)
    {
        _dbcontext = dbContext;
        _httpAccessor = httpAccessor;
        _walletService = walletService;
        _transactionService = transactionService;
        _notificationService = notificationService;
    }
    
    public async Task<string> CreateWithdrawalRequest(Request.CreateWithdrawalRequest request)
    {
        var userId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
        var userIdGuild = Guid.Parse(userId);
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == userIdGuild);
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.UserId == userIdGuild);
        if (wallet == null)
        {
            throw new UnauthorizedAccessException("Wallet not found");
        }

        if (string.IsNullOrEmpty(wallet.BankName) || 
            string.IsNullOrEmpty(wallet.BankAccount) || 
            string.IsNullOrEmpty(wallet.BankAccountName))
        {
            throw new ArgumentException("Vui lòng liên kết tài khoản ngân hàng trước khi rút tiền");
        }

        if (request.Amount < 0)
        {
            throw new ArgumentException("Số dư không thể là số âm");
        }

        if (wallet.Balance < request.Amount)
        {
            throw new ArgumentException("Số dư không đủ để thực hiện yêu cầu này");
        }

        if (request.Amount < 50000)
        {
            throw new ArgumentException("phair rut toi thieu 50k");
        }
        var newWithdrawal = new Repository.Entity.Withdrawal()
        {
            Amount = request.Amount,
            BankName = wallet.BankName,
            BankAccountNumber = wallet.BankAccount,
            BankAccountName = wallet.BankAccountName,
            WalletId = wallet.Id,
            CreatedAt = DateTimeOffset.UtcNow
        };
        _dbcontext.Withdrawals.Add(newWithdrawal);
        var transactionI = new Transaction.Request.CreateTransactionRequest()
        {
            Type = Transaction.Request.TypeList.Withdrawal,
            Amount = request.Amount,
            BalanceBefore = wallet.Balance,
            BalanceAfter =  wallet.Balance - request.Amount,
            Status = "Success",
            WalletId =  wallet.Id,
        };
        
        if (!await _walletService.ApartBanlanceFromWallet(userIdGuild, request.Amount, "Wallet"))
        {
            throw new Exception("Wallet apart balance failed");
        }
        if (!await _transactionService.CreateTransaction(transactionI))
        {
            throw new Exception("Error creating transaction");
        }

        _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
        {
            UserId = userIdGuild,
            Title = "Yêu cầu rút tiền mới",
            Content = $"Người dùng {user.FirstName} {user.LastName} vừa tạo yêu cầu rút {request.Amount:N0}đ.",
            Type = Notification.Request.TypeNotification.WithdrawalRequested,
            WithdrawalId = newWithdrawal.Id
        });

        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success create withdrawal";
        }
        return "failed";
    }

    public async Task<Base.Response.PageResult<Response.GetWithdrawalResponse>> AdminGetWithdrawalRequest(Guid? userId, Base.Request.PagingDay pagination)
    {
        var withdrawals = _dbcontext.Withdrawals.AsQueryable();
        if (pagination.Id != null)
        {
            withdrawals = withdrawals.Where(x => x.Id ==  pagination.Id);
        }
        if(pagination.Search != null)
        {
            withdrawals = withdrawals.Where(x => x.Wallet.User.Email.Contains(pagination.Search));
        }
        if (userId != null)
        {
            withdrawals = withdrawals.Where(x => x.Wallet.UserId ==  userId);
        }
        if (pagination.Date != null)
        {
            withdrawals = withdrawals.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) == pagination.Date);
        }
        var total = await withdrawals.CountAsync();
        withdrawals = withdrawals
            .OrderBy(x => x.Status != "Pending")
            .ThenByDescending(x => x.CreatedAt);
        withdrawals = withdrawals
            .Skip((pagination.PageIndex - 1) * pagination.PageSize)
            .Take(pagination.PageSize);

        var selectWithdrawal = withdrawals.Select(x => new Response.GetWithdrawalResponse()
        {
            Id = x.Id,
            UserId = x.Wallet.UserId,
            Email = x.Wallet.User.Email,
            Avatar = x.Wallet.User.AvatarUrl,
            FirstName = x.Wallet.User.FirstName,
            LastName = x.Wallet.User.LastName,
            Amount = x.Amount,
            BankName = x.BankName,
            BankAccountNumber = x.BankAccountNumber,
            BankAccountName = x.BankAccountName,
            WalletId = x.WalletId,
            TransactionId = x.TransactionId,
            Status = x.Status,
            CreatedAt = x.CreatedAt,
        });

        var listWithdrawal = await selectWithdrawal.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetWithdrawalResponse>()
        {
            Items = listWithdrawal,
            PageIndex = pagination.PageIndex,
            PageSize = pagination.PageSize,
            TotalItems = total
        };
        return result;
    }

    public async Task<string> AdminApprovedWithdrawalRequest(Guid withdrawalRequestId)
    {
        var withdrawalRrquest = await _dbcontext.Withdrawals.FirstOrDefaultAsync(x => x.Id == withdrawalRequestId);
        if (withdrawalRrquest == null)
        {
            throw new Exception("Withdrawal not found");
        }
        if (withdrawalRrquest.Status != "Pending")
        {
            throw new Exception("Withdrawal was rejected");
        }
        withdrawalRrquest.Status = "Approved";
        withdrawalRrquest.UpdatedAt = DateTimeOffset.UtcNow;
        _dbcontext.Update(withdrawalRrquest);

        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.Id == withdrawalRrquest.WalletId);
        if (wallet != null)
        {
            _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
            {
                UserId = wallet.UserId,
                Title = "Yêu cầu rút tiền được duyệt",
                Content = $"Yêu cầu rút {withdrawalRrquest.Amount:N0}đ của bạn đã được duyệt và đang được xử lý chuyển khoản.",
                Type = Notification.Request.TypeNotification.WithdrawalApproved,
                WithdrawalId = withdrawalRrquest.Id
            });
        }

        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success approved withdrawal";
        }
        return "Failure approved withdrawal";
    }

    public async Task<string> AdminRejectWithdrawalRequest(Guid withdrawalRequestId, string reason, string? note)
    {
        var withdrawalRequest = await _dbcontext.Withdrawals
            .Include(x => x.Wallet)
            .FirstOrDefaultAsync(x => 
                x.Id == withdrawalRequestId);
        if (withdrawalRequest == null)
        {
            throw new Exception("Withdrawal not found");
        }
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.Id == withdrawalRequest.WalletId);
        if (wallet == null)
        {
            throw new Exception("Wallet not found");
        }
        if (withdrawalRequest.Status != "Pending")
        {
            throw new Exception("Withdrawal was approved");
        }
        withdrawalRequest.Status = "Rejected";
        withdrawalRequest.RejectionReason = reason;
        withdrawalRequest.AdminNote = note;
        withdrawalRequest.UpdatedAt = DateTimeOffset.UtcNow;
        _dbcontext.Update(withdrawalRequest);
        
        var transactionI = new Transaction.Request.CreateTransactionRequest()
        {
            Type = Transaction.Request.TypeList.Withdrawal,
            Amount = withdrawalRequest.Amount,
            BalanceBefore = wallet.Balance,
            BalanceAfter =  wallet.Balance + withdrawalRequest.Amount,
            Status = "Success",
            WalletId =  wallet.Id,
        };
        if (!await _walletService.AddBanlanceToWallet(withdrawalRequest.Wallet.UserId, withdrawalRequest.Amount, "Payment"))
        {
            throw new Exception("Wallet reject balance failed");
        }
        if (!await _transactionService.CreateTransaction(transactionI))
        {
            throw new Exception("Error creating transaction");
        }

        _notificationService.CreateNotification(new Notification.Request.CreateNotificationRequest
        {
            UserId = wallet.UserId,
            Title = "Yêu cầu rút tiền bị từ chối",
            Content = $"Yêu cầu rút {withdrawalRequest.Amount:N0}đ của bạn đã bị từ chối. Lý do: {reason}",
            Type = Notification.Request.TypeNotification.WithdrawalRejected,
            WithdrawalId = withdrawalRequest.Id
        });

        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success rejected withdrawal";
        }
        return "Failure rejected withdrawal";
    }

    public async Task<Base.Response.PageResult<Response.UsergetWithdrawalResponse>> GetWithdrawalRequest(Base.Request.PagingDay pagination)
    {
        var userId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
        var userIdGuild = Guid.Parse(userId);
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == userIdGuild);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var wallet = await _dbcontext.Wallets.FirstOrDefaultAsync(x => x.UserId == userIdGuild);
        if (wallet == null)
        {
            throw new Exception("Wallet not found");
        }
        var withdrawalRequest = _dbcontext.Withdrawals.Where(x => x.WalletId == wallet.Id);
        if (withdrawalRequest == null)
        {
            throw new Exception("Withdrawal not found");
        }
        if (pagination.Date != null)
        {
            withdrawalRequest = withdrawalRequest.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) == pagination.Date);
        }
        withdrawalRequest = withdrawalRequest
            .OrderBy(x => x.Status != "Pending")
            .ThenByDescending(x => x.CreatedAt);
            
        var total = await withdrawalRequest.CountAsync();
        
        withdrawalRequest = withdrawalRequest
            .Skip((pagination.PageIndex - 1) * pagination.PageSize)
            .Take(pagination.PageSize);
        var selectWithdrawalRequest = withdrawalRequest.Select(x => new Response.UsergetWithdrawalResponse()
        {
            Id = x.Id,
            UserId = x.Wallet.UserId,
            Amount = x.Amount,
            Status =  x.Status,
            RejectionReason = x.RejectionReason,
            AdminNote = x.AdminNote,
            TransactionId =  x.TransactionId,
            Email = x.Wallet.User.Email,
            Avatar = x.Wallet.User.AvatarUrl,
            FirstName = x.Wallet.User.FirstName,
            LastName = x.Wallet.User.LastName,
            WalletId = x.WalletId,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
        });
        var listWithdrawal = await selectWithdrawalRequest.ToListAsync();
        var result = new Base.Response.PageResult<Response.UsergetWithdrawalResponse>()
        {
            Items = listWithdrawal,
            PageIndex = pagination.PageIndex,
            PageSize = pagination.PageSize,
            TotalItems = total,
        };
        return result;
    }
}