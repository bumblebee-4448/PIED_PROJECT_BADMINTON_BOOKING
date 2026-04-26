namespace Rallyhub.Service.IdentityService;

public class Request
{
    public class VerifyOtpRequest
    {
        public required string Email { get; set; }
        public required string OtpCode { get; set; }
    }
}