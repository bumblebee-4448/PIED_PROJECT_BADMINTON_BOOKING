using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Transaction;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpAccessor;
    public  Service(AppDbContext dbContext, IHttpContextAccessor  httpAccessor)
    {
        _dbContext = dbContext;
        _httpAccessor = httpAccessor;
    }

    public async Task<bool> CheckTotalTransactions(Guid userId)
    {
        var wallet =  await _dbContext.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
        if (wallet == null)
        {
            throw new Exception("Wallet not found");
        }

        if (wallet.Balance < 0)
        {
            throw new Exception("Balance is less than 0!!!waring");
        }
        
        var query = _dbContext.Transactions.Where(x => x.Wallet.UserId == userId && x.Status == "Success");
        var total = await query.SumAsync(x => (
                                                  x.Type == "Deposit" || x.Type == "Refund" || x.Type == "AdminUp" || x.Type == "Receive" ? x.Amount : 0)
                                              - (x.Type == "Payment" || x.Type == "Withdrawal" || x.Type == "AdminDeduct" ? x.Amount : 0));
        if (total < 0)
        {
            throw new Exception("Total amount of transaction is less than 0!!!waring");
        }
        if (total != wallet.Balance)
        {
            throw new Exception("!!!Waring, các giao dịch ko khớp với số dư ví");
        }
        return true;
    }

    public async Task<bool> CreateTransaction(Request.CreateTransactionRequest request)
    {
        var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.Id == request.WalletId);
        if (wallet == null)
        {
            throw new Exception("Wallet not found");
        }
        var userId = wallet.UserId;
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var newTransaction = new Repository.Entity.Transaction()
        {
            Type = request.Type,
            Amount = request.Amount,
            BalanceBefore = request.BalanceBefore,
            BalanceAfter = request.BalanceAfter,
            SePayId = request.SePayId,
            BankRefCode = request.BankRefCode,
            BankAccountNumber = request.BankAccountNumber,
            TransferContent = request.TransferContent,
            ActionCode = request.ActionCode,
            Signature =  request.Signature,
            Status = request.Status,
            BookingId = request.BookingId,
            WalletId = request.WalletId,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        };
        _dbContext.Transactions.Add(newTransaction);
        
        switch (request.Type)
        {
            case Request.TypeList.Deposit: //nạp tiền
            {
                newTransaction.Amount = request.Amount;
                break;   
            }
            case Request.TypeList.Refund: //hoàn tiền
            {
                newTransaction.Amount = request.Amount;
                break;   
            }
            case Request.TypeList.AdminUp: //admin cộng tiền
            {
                newTransaction.Amount = request.Amount;
                break;   
            }
            case Request.TypeList.Payment: //trả cho ..
            {
                newTransaction.Amount = -request.Amount;
                break;   
            }
            case Request.TypeList.Withdrawal: //rút tiền tiền
            {
                newTransaction.Amount = -request.Amount;
                break;   
            }
            case Request.TypeList.AdminDeduct: //admin trừ tiền
            {
                newTransaction.Amount = -request.Amount;
                break;   
            }
        }
        // var result = await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Base.Response.PageResult<Response.GetTransactionResponse>> GetTransaction(Base.Request.PagingDay paginDay)
    {
        var userId = _httpAccessor.HttpContext.User.Claims.Where(x => x.Type == "UserId").FirstOrDefault()?.Value;
        var userIdGGuild = Guid.Parse(userId!);
        var user =  await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userIdGGuild);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var query =  _dbContext.Transactions.Where(x => x.Wallet.UserId == userIdGGuild && x.Status == "Success");
        if (paginDay.Date != null)
        {
            query = query.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) == paginDay.Date);
        }
        var total = await query.CountAsync();
        query = query.OrderBy(x => x.CreatedAt);
        query = query
            .Skip((paginDay.PageIndex - 1) * paginDay.PageSize)
            .Take(paginDay.PageSize);

        var selectQuery = query.Select(x => new Response.GetTransactionResponse()
        {
            Id = x.Id,
            Type = x.Type,
            Amount = x.Amount,
            BankRefCode = x.BankRefCode,
            BankAccountNumber = x.BankAccountNumber,
            Status = x.Status,
            BookingId = x.BookingId,
            CreatedAt = x.CreatedAt,
            UpdatedAt =  x.UpdatedAt,
        });
        var listTransaction = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetTransactionResponse>()
        {
            Items = listTransaction,
            PageIndex = paginDay.PageIndex,
            PageSize = paginDay.PageSize,
            TotalItems = total,
        };
        return result;
    }

    public async Task<Base.Response.PageResult<Response.AdminGetTransactionResponse>> AdminGetTransaction(Guid? userId, Base.Request.PagingDay paginDay)
    {
        var query =  _dbContext.Transactions.Where(x => true);
        if (userId != null)
        {
            query = _dbContext.Transactions.Where(x => x.Wallet.UserId == userId);
        }

        if (paginDay.Id != null)
        {
            query = _dbContext.Transactions.Where(x => x.Id == paginDay.Id);
        }
        if (paginDay.Search != null)
        {
            query = _dbContext.Transactions.Where(x => x.Wallet.User.Email == paginDay.Search);
        }
        if (paginDay.Date != null)
        {
            query = query.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) == paginDay.Date);
        }
        var total = await query.CountAsync();
        query = query.OrderBy(x => x.Status == "Pending").ThenBy(x => x.CreatedAt);
        query = query
            .Skip((paginDay.PageIndex - 1) * paginDay.PageSize)
            .Take(paginDay.PageSize);

        var selectQuery = query.Select(x => new Response.AdminGetTransactionResponse()
        {
            Id = x.Id,
            Type = x.Type,
            Amount = x.Amount,
            Mail = x.Wallet.User.Email,
            FirstName = x.Wallet.User.FirstName,
            LastName = x.Wallet.User.LastName,
            AvatarUrl =  x.Wallet.User.AvatarUrl,
            BalanceBefore =  x.BalanceBefore,
            BalanceAfter =  x.BalanceAfter,
            SePayId =  x.SePayId,
            BankRefCode = x.BankRefCode,
            BankAccountNumber = x.BankAccountNumber,
            TransferContent = x.TransferContent,
            Status = x.Status,
            ActionCode =  x.ActionCode,
            Signature =  x.Signature,
            BookingId = x.BookingId,
            WalletId =  x.WalletId,
            CreatedAt =  x.CreatedAt,
            UpdatedAt =  x.UpdatedAt,
        });
        var listTransaction = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.AdminGetTransactionResponse>()
        {
            Items = listTransaction,
            PageIndex = paginDay.PageIndex,
            PageSize = paginDay.PageSize,
            TotalItems = total,
        };
        return result;
    }
}