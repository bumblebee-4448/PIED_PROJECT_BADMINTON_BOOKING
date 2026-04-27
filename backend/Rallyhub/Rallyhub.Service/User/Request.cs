namespace Rallyhub.Service.User;

public class Request
{
    public class RegisterRequest
    {
        public required string Email { get; set; }
        public required string  RawPassword { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}