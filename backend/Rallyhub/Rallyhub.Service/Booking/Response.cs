namespace Rallyhub.Service.Booking;

public class Response
{
    

    public class BookingDetailItem
    {
        public Guid SubCourtId { get; set; }
        public string SubCourtName { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class CreateBookingResponse
    {
        public Guid BookingId {get; set;}
        public string BankName { get; set; } = null!;
        public string BankAccount { get; set; } = null!;
        public decimal TotalPrice {get; set;}
        public DateTimeOffset ExpiredAt {get; set;}
        public string Status { get; set; } = null!;
        public List<BookingDetailItem> Items { get; set; } = new();
        public string QrCodeUrl { get; set; } = null!;
        public int TotalSlots { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
    public class BookingRefundResponse
    {
        public Guid BookingId { get; set; }
        public string Status { get; set; } = null!;
        public decimal RefundAmount { get; set; }
        public string Message { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
    }
    public class GetBookingResponse
    {
        public Guid BookingId { get; set; }
        public decimal FinalPrice { get; set; }
        public string Status { get; set; } = null!;
        public string CourtName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public List<SlotsResponse> SlotsResponses { get; set; } = new();
        public string PhoneNumber { get; set; } = null!;
        public string UrlMap { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public Guid? CourtId { get; set; }
        public Guid? FeedbackId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
    }

    public class SlotsResponse
    {
        public Guid SlotId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class GetBookingDetailResponse
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string Gmail { get; set; } = null!;
        public string SubCourtName { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
