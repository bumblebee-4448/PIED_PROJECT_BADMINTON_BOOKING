namespace Rallyhub.Service.UserService;

public class Request
{
    public class RegisterRequest
    {
        public required string Email { get; set; }
        public required string  PasswordHash { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}