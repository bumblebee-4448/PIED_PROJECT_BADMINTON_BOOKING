using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Transaction;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    public  Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
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
                                                  x.Type == "Deposit" || x.Type == "Refund" ? x.Amount : 0)
                                              - (x.Type == "Payment" || x.Type == "Withdraw" ? x.Amount : 0));
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
}