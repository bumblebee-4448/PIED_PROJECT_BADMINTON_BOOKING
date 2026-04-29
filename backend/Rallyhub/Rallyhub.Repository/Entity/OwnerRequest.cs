using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class OwnerRequest : BaseEntity<Guid>, IAuditableEntity
{
    public required string BusinessName { get; set; }
    public required string TaxCode { get; set; }
    public required string BusinessAddress { get; set; }
    public required string BusinessLicenseUrl { get; set; } // Ảnh giấy phép

    public required string IdentityNumber { get; set; } // Số CCCD
    public required string IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
    public required string IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD

    public string Status { get; set; } = "Pending";
    public string? RejectionReason { get; set; }
    
    public Guid? OwnerId { get; set; }
    public Owner? Owner { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}