using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class SystemReport : BaseEntity<Guid>, IAuditableEntity
{
    public required string Title { get; set; }
    public required string Reason { get; set; }
    public string Status { get; set; } = "Pending";
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}