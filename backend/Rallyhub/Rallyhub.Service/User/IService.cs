namespace Rallyhub.Service.User;

public interface IService
{
    public Task UpdateProfile(Request.UpdateProfile request);
    public Task<string> ChangePassword(Request.ChangePasswordRequest request);
    public Task<Response.UserDto> GetMe();
    // public Task CreateWallet(Request.CreateAndUpdateWalletRequest request);
    // public Task UpdateWallet(Request.CreateAndUpdateWalletRequest request);
}