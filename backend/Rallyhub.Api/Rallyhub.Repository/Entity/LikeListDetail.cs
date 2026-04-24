using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class LikeListDetail : BaseEntity<Guid>, IAuditableEntity
{
    public Guid CourseId { get; set; }
    public Court Course { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}