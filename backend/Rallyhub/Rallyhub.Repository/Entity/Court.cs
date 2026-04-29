using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Court : BaseEntity<Guid>, IAuditableEntity
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required TimeOnly OpenTime  { get; set; }
    public required TimeOnly CloseTime { get; set; }
    public string Status { get; set; } = "Approved";//"Pending", "Rejected"
    
    public required decimal Latitude { get; set; } //vĩ độ (10, 8)
    public required decimal Longitude { get; set; } //kinh độ (11, 8)
    public required string MapUrl  { get; set; } //link của gg map
    
    public required string PictureUrl { get; set; }
    public  string? Description { get; set; }
    
    public Guid OwnerId  { get; set; }
    public Owner Owner { get; set; }

    public ICollection<SubCourt> SubCourts { get; set; } = new List<SubCourt>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<CampaignCourt> CampaignCourts { get; set; } = new List<CampaignCourt>();
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public ICollection<Report> Reports { get; set; } = new List<Report>();
    public ICollection<LikeListDetail> LikeListDetails { get; set; } = new List<LikeListDetail>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}