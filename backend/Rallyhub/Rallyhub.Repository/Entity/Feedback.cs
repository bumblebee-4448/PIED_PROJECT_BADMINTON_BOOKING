using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Feedback : BaseEntity<Guid>, IAuditableEntity
{
    public required int Rating { get; set; } //1-5
    public string? Comment { get; set; }
    
    public Guid CourtId { get; set; }
    public Court Court { get; set; }
    public Guid CustomerId  { get; set; }
    public Customer Customer { get; set; }
    public Guid BookingId { get; set; }
    public Booking Booking { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}