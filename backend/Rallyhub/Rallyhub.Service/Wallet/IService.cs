namespace Rallyhub.Service.Wallet;

public interface IService
{
    public Task<bool> CreateWallet(Guid userId);
    public Task<string> AddInforWallet(Request.AddInforWalletRequest request);
    public Task<string> RemoveBankWallet();
    public Task<Response.GetInfoWalletResponse> GetInforWallet();
}