using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Notification : BaseEntity<Guid>, IAuditableEntity
{
    public Booking Booking { get; set; }
    public Guid BookingId {get; set;}
    public User User { get; set; }
    public Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Type { get; set; }
    public required bool Isread { get; set; } = false;
    public Court Court { get; set; }
    public Guid CourtId { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}