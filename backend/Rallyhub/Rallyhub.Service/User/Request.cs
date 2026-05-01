using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.User;

public class Request
{
    public class UserRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class RegisterRequest : UserRequest
    {
        public required string Email { get; set; }
        public required string  RawPassword { get; set; }
    }
    
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
    
}