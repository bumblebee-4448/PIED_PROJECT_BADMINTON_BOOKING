using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class OverideSlot : BaseEntity<Guid>, IAuditableEntity
{
    public Guid SubCourtDetailId { get; set; }
    public SubCourt SubCourtDetail { get; set; }
    
    public bool IsRecurring { get; set; } //[default: false, note: 'True = repeat weekly on dayOfWeek; False = one specific date']
    public DayOfWeek DayOfWeek { get; set; } //[null, note: '0=Sun … 6=Sat. Only used when isRecurring = true']
    public DateOnly Date { get; set; } //[null, note: 'Specific date. Only used when isRecurring = false']
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public decimal Price { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}