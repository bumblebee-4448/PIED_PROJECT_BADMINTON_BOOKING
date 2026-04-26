using Rallyhub.Service.User;

namespace Rallyhub.Service.IdentityService;

public interface IService
{
    public Task<string> RegisterTask(User.Request.RegisterRequest request);
    public Task<bool> VerifyOtp(string email, string inputOtp);
}