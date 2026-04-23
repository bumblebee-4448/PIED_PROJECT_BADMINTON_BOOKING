using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Notification : BaseEntity<Guid>, IAuditableEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}