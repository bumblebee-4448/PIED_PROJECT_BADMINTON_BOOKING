namespace Rallyhub.Service.Wallet;

public interface IService
{
    public Task<bool> CreateWallet(Guid userId);
    public Task<string> AddInforWallet(Request.AddInforWalletRequest request);
    public Task<string> RemoveBankWallet();
    public Task<Response.GetInfoWalletResponse> GetInforWallet();
    public Task<Response.AddBalanceToWalletFromPaymentResponse> AddBalanceToWalletFromPayment(decimal requestAmount);
    public Task<bool> AddBanlanceToWallet(Guid userId, decimal amount, string type);
    public Task<bool> ApartBanlanceFromWallet(Guid userId, decimal amount, string type);
    public Task<string> AdminUpBalanceForUser(Guid userId, decimal amount, string? description);
}