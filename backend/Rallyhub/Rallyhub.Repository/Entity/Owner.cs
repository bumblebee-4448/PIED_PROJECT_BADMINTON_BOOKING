using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Owner : BaseEntity<Guid>, IAuditableEntity
{
    public required string BusinessName  { get; set; }
    public required string TaxCode { get; set; }
    public required string BusinessAddress { get; set; }
    public string? BusinessLicenseUrl { get; set; } // Ảnh giấy phép

    public string? IdentityNumber { get; set; } // Số CCCD
    public string? IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
    public string? IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD
    public OwnerRequest? OwnerRequest { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<Court> Courts { get; set; } = new List<Court>();
    public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}