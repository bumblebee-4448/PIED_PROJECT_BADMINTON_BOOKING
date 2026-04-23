using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Report : BaseEntity<Guid>, IAuditableEntity
{
    public required string Reason { get; set; }
    public string Status { get; set; } = "Pending";
    
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid CourtId { get; set; }
    public Court Court { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}