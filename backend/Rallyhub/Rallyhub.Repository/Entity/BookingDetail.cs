using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class BookingDetail : BaseEntity<Guid>, IAuditableEntity
{
    public Guid SubCourtId { get; set; }
    public SubCourt SubCourt { get; set; }
    public Guid BookingId { get; set; }
    public Booking Booking { get; set; }
    
    public DateTimeOffset Date { get; set; } //[null, note: 'Specific date. Only used when isRecurring = false']
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; } = "Pending";
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}