using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class User : BaseEntity<Guid>, IAuditableEntity
{
    public required string Email { get; set; }
    public required string  PasswordHash { get; set; }
    public string Role { get; set; } = "Customer";
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AvatarUrl { get; set; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s";
    public string Status {get; set;} = "Active";
    
    public Customer? Customer { get; set; }
    public Owner? Owner { get; set; }
    public Wallet? Wallet { get; set; }
    
    public ICollection<SystemReport> SystemReports { get; set; } = new List<SystemReport>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}