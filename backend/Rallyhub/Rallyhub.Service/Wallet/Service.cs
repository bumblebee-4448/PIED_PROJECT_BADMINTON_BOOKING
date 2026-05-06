using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Wallet;

public class Service : IService
{
    private readonly AppDbContext _dbcontext;
    private readonly IHttpContextAccessor _httpAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpAccessor)
    {
        _dbcontext = dbContext;
        _httpAccessor = httpAccessor;
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
        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success add infor wallet";
        }
        return "Failed add infor wallet";
    }

    public Task<string> GetInforWallet()
    {
        throw new NotImplementedException();
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
        var result = await _dbcontext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success remove bank wallet";
        }
        return "Failed remove bank wallet";
    }

    
}