using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class SubCourt : BaseEntity<Guid>, IAuditableEntity
{
    public required string Name { get; set; }
    
    public Guid CourseId { get; set; }
    public Court Course { get; set; }
    
    public ICollection<Exception> Exceptions { get; set; } = new List<Exception>();
    public ICollection<ConfigSlot>  ConfigSlots { get; set; } = new List<ConfigSlot>();
    public ICollection<OverideSlot> OverideSlots { get; set; } = new List<OverideSlot>();
    public ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}