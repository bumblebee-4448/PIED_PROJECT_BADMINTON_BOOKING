using Rallyhub.Service.User;

namespace Rallyhub.Service.IdentityService;

public interface IService
{
    public Task<string> RegisterTask(User.Request.RegisterRequest request);
    public Task<Response.IdentityResponse> VerifyOtp(string email, string inputOtp);
    public Task<Response.IdentityResponse> Login(Request.LoginRequest request);
    // public Task<string> Logout(string token);
    public Task<string> ForgotPassword(Request.ForgotPasswordRequest request);
    public Task<string> ResetPassword(Request.ResetPasswordRequest request);
}