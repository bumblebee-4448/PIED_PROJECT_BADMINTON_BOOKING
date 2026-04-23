using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Exception : BaseEntity<Guid>, IAuditableEntity
{
    public Guid SubCourtDetailId { get; set; }
    public SubCourt SubCourtDetail { get; set; }
    
    public DateTimeOffset  Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Reason { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}