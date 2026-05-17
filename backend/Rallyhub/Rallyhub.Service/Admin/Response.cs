namespace Rallyhub.Service.Admin;

public class Response
{
    public class UserDto
    {
        public Guid  Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public string Status { get; set; } 
    }
    public class OwnerDto: UserDto
    {
        public string BusinessName  { get; set; }
        public string TaxCode { get; set; }
        public string BusinessAddress { get; set; }
        public string? BusinessLicenseUrl { get; set; } 
        public string? IdentityNumber { get; set; } 
        public string? IdentityCardFrontUrl { get; set; } 
        public string? IdentityCardBackUrl { get; set; } 
        public List<CourtDto> Courts { get; set; }
    }
    public class CustomerDto: UserDto
    {
        public List<BookingDto> Bookings { get; set; }
    }

    public class BookingDto
    {
        public Guid  Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public string Status { get; set; }  
        public string? CancellationReason { get; set; }
    }

    public class CourtDto
    {
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeOnly OpenTime  { get; set; }
        public TimeOnly CloseTime { get; set; }
        public string Status { get; set; }

        public decimal? Latitude { get; set; } //vĩ độ (10, 8)
        public decimal? Longitude { get; set; } //kinh độ (11, 8)
        public string MapUrl  { get; set; } //link của gg map
    }
    
    public class AdminGetOwnerRequestResponse : UserDto
    {
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public string? BusinessName { get; set; }
        public string? TaxCode { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public string? IdentityNumber { get; set; } // Số CCCD
        public string? IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public string? IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD

        public DateTimeOffset CreatedAt { get; set; }
    }
    public class AdminGetPendingCourtsResponse  
    {  
        public Guid OwnerId { get; set; }  
        public Guid CourtId { get; set; }  
        public string OwnerName { get; set; } = null!;
        public string Name { get; set; } = null!;  
        public string Status { get; set; } = null!;  
        public string Address { get; set; } = null!;
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
        public string PictureUrl { get; set; } = null!;
        public string? Description { get; set; }
        public string? MapUrl { get; set; }
    }  

    public class AdminRefundResponse
    {
        public Guid BookingId { get; set; }
        public string Status { get; set; } = null!;
        public decimal RefundAmount { get; set; }
        public string Message { get; set; } = null!;
    }

    public class GetWalletResponse
    {
        public string? BankName  { get; set; }
        public string? BankAccount { get; set; }
        public required decimal Balance { get; set; }
        public string? BankAccountName { get; set; }
    }

    public class GetBookingDetailStatusRefundPendingResponse
    {
        public Guid BookingDetailId  { get; set; }
        public Guid CustomerId  { get; set; }
        public string Email   { get; set; }
        public string Status  { get; set; }
        public decimal Price  { get; set; }
    }
}