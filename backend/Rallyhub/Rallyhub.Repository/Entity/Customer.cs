using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Customer : BaseEntity<Guid>, IAuditableEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public ICollection<OwnerRequest> OwnerRequests { get; set; } = new List<OwnerRequest>();
    public ICollection<LikeListDetail> LikeListDetails { get; set; } = new List<LikeListDetail>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Report> Reports { get; set; } = new List<Report>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}