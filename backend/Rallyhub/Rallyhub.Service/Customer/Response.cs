namespace Rallyhub.Service.Customer;

public class Response
{
    public class GetOwnerRequestResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? OwnerId { get; set; } = null;
        public string? BusinessName { get; set; }
        public string? TaxCode { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public string? IdentityNumber { get; set; } // Số CCCD
        public string? IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public string? IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD

        public string? Status { get; set; }
        public string? RejectionReason { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}