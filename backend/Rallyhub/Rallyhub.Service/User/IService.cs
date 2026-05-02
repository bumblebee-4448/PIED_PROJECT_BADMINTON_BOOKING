namespace Rallyhub.Service.User;

public interface IService
{
    public Task UpdateProfile(Request.UpdateProfile request);
    public Task<string> ChangePassword(Request.ChangePasswordRequest request);
}