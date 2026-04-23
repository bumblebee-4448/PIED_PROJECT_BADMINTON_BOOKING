using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class CampaignCourt : BaseEntity<Guid>, IAuditableEntity
{
    public Guid CourseId { get; set; }
    public Court Course { get; set; }
    public Guid CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}