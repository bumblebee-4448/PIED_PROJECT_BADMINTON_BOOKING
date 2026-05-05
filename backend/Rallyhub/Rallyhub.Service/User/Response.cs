namespace Rallyhub.Service.User;

public class Response
{
    public class OwnerRequestResponse
    {
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
    public class UserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string AvatarUrl { get; set; } =
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s";
    }

    public class CustomerDto : UserDto
    {
        
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