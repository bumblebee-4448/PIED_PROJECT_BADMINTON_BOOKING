namespace Rallyhub.Service.Owner;

public class Request
{
    public class CreateOwnerRequest
    {
        public required string BusinessName  { get; set; }
        public required string TaxCode { get; set; }
        public required string BusinessAddress { get; set; }
        public string? BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public string? IdentityNumber { get; set; } // Số CCCD
        public string? IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public string? IdentityCardBackUrl { get; set; }
    }
}