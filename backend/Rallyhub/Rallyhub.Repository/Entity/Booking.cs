using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Booking : BaseEntity<Guid>, IAuditableEntity
{
    public required decimal TotalPrice { get; set; }
    public decimal? DiscountAmount { get; set; } = 0;
    public required decimal FinalPrice { get; set; }
    public string Status { get; set; } = "Pending"; //Pending, Banked, Cancel, Refund, Complete
    public string? CancellationReason { get; set; }
    //Hùng thêm vào
    public DateTimeOffset ExpiresAt { get; set; } 
    //
    public Guid? CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public ICollection<Report> Reports { get; set; } = new List<Report>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}