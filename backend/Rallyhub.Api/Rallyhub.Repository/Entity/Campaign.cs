using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Campaign : BaseEntity<Guid>, IAuditableEntity
{
    public required string Code { get; set; } //unique
    public bool IsGlobal { get; set; } = false;
    public required decimal DiscountPercent  { get; set; }
    public decimal MaxDiscountAmount { get; set; }
    public decimal? MinBookingAmount { get; set; }
    public int UsageLimit { get; set; }
    public int UsedCount { get; set; } = 0;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid OwnerId  { get; set; }
    public Owner Owner { get; set; }
    
    public ICollection<Booking>  Bookings { get; set; } = new List<Booking>();
    public ICollection<CampaignCourt> Courts { get; set; } = new List<CampaignCourt>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}