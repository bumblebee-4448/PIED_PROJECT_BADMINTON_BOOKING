namespace Rallyhub.Service.User;

public class Response
{
    public class UserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; } 
    }

    public class OwnerDto : UserDto
    {
        public required string BusinessName  { get; set; }
        public required string TaxCode { get; set; }
        public required string BusinessAddress { get; set; }
        public string BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public string IdentityNumber { get; set; } // Số CCCD
        public string IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public string IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD
    }
    
    
}