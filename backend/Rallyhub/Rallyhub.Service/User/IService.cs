namespace Rallyhub.Service.User;

public interface IService
{
    public Task<string> ChangePassword(Request.ChangePasswordRequest request);
}