namespace Rallyhub.Service.Admin.UserManagement;

public class Response
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Role { get; set; } = "Customer";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Status { get; set; } = "Active";
    }
    public class OwnerDto: UserDto
    {
        public string BusinessName  { get; set; }
        public string TaxCode { get; set; }
        public string BusinessAddress { get; set; }
        public List<CourtDto> Courts { get; set; }
    }
    public class CustomerDto: UserDto
    {
        public List<BookingDto> Bookings { get; set; }
    }

    public class BookingDto
    {
        public decimal TotalPrice { get; set; }
        public decimal? DiscountAmount { get; set; } = 0;
        public decimal FinalPrice { get; set; }
        public string Status { get; set; } = "Pending"; //Pending, Banked, Cancel, Refund, Complete
        public string? CancellationReason { get; set; }
    }

    public class CourtDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeOnly OpenTime  { get; set; }
        public TimeOnly CloseTime { get; set; }
        public string Status { get; set; } = "Active";

        public decimal Latitude { get; set; } //vĩ độ (10, 8)
        public decimal Longitude { get; set; } //kinh độ (11, 8)
        public string MapUrl  { get; set; } //link của gg map
    }
    
    public class AdminGetOwnerRequestResponse
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
}