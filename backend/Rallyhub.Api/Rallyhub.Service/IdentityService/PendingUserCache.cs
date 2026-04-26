namespace Rallyhub.Service.IdentityService;

public class PendingUserCache
{
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string OtpCode { get; set; }
    public required string Role { get; set; }
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
}