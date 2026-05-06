namespace Rallyhub.Service.Admin;

public class Response
{
    public class UserDto
    {
        public Guid  Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "Customer";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public string Status { get; set; } = "Active";
    }
    public class OwnerDto: UserDto
    {
        public Guid  Id { get; set; } 
        public string BusinessName  { get; set; }
        public string TaxCode { get; set; }
        public string BusinessAddress { get; set; }
        public List<CourtDto> Courts { get; set; }
    }
    public class CustomerDto: UserDto
    {
        public Guid  Id { get; set; }
        public List<BookingDto> Bookings { get; set; }
    }

    public class BookingDto
    {
        public Guid  Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? DiscountAmount { get; set; } = 0;
        public decimal FinalPrice { get; set; }
        public string Status { get; set; } = "Pending"; //Pending, Banked, Cancel, Refund, Complete
        public string? CancellationReason { get; set; }
    }

    public class CourtDto
    {
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeOnly OpenTime  { get; set; }
        public TimeOnly CloseTime { get; set; }
        public string Status { get; set; } = "Active";

        public decimal Latitude { get; set; } //vĩ độ (10, 8)
        public decimal Longitude { get; set; } //kinh độ (11, 8)
        public string MapUrl  { get; set; } //link của gg map
    }
    
    public class AdminGetOwnerRequestResponse : UserDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public string? BusinessName { get; set; }
        public string? TaxCode { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public string? IdentityNumber { get; set; } // Số CCCD
        public string? IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public string? IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD

        public string? Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
    public class GetPendingCourtsResponse  
    {  
        public Guid CourtId { get; set; }  
        public Guid OwnerId { get; set; }  
        public string Name { get; set; } = null!;  
        public string Status { get; set; } = null!;  
    }  
    public class RejectPendingCourtsResponse  
    {  
        public Guid CourtId { get; set; }  
        public Guid OwnerId { get; set; }  
        public string Reason { get; set; } = null!;  
    }

    public class RefundResponse
    {
        public string Message { get; set; }
        public string ImageUrl  { get; set; }
    }

    public class GetWalletResponse
    {
        public required string BankName  { get; set; }
        public required string BankAccount { get; set; }
        public decimal Balance { get; set; }
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