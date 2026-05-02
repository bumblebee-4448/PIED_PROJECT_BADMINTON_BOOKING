namespace Rallyhub.Service.IdentityService;

public class Request
{
    public class VerifyOtpRequest
    {
        public required string Email { get; set; }
        public required string OtpCode { get; set; }
    }
    
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string RawPassword { get; set; }
    }
    
    public class ForgotPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
    }
    
    public class ResetPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}