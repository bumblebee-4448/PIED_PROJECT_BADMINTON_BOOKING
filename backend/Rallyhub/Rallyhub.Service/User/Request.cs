using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.User;

public class Request
{
    public class UserRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class RegisterRequest : UserRequest
    {
        public required string Email { get; set; }
        public required string  RawPassword { get; set; }
    }
    
    public class OwnerRequestRequest :UserRequest
    {
        public required string BusinessName { get; set; }
        public required string TaxCode { get; set; }
        public required string BusinessAddress { get; set; }
        public required IFormFile BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public required string IdentityNumber { get; set; } // Số CCCD
        public required IFormFile IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public required IFormFile IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD
    }

    public class GetOwnerRequest
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
    }
    
}