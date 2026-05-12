namespace Rallyhub.Service.Booking;

public class Response
{
    
    public class SlotResponse
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? Reason { get; set; }
    }

    public class BookingDetailItem
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateBookingResponse
    {
        public Guid BookingId {get; set;}
        public decimal TotalPrice {get; set;}
        public DateTimeOffset ExpiredAt {get; set;}
        public string Status { get; set; } = null!;
        public List<BookingDetailItem> Slots { get; set; } = new();
        public string QrCodeUrl { get; set; } = null!;
    }
    public class BookingRefundResponse
    {
        public Guid BookingId { get; set; }
        public string Status { get; set; } = null!;
        public decimal RefundAmount { get; set; }
        public string Message { get; set; } = null!;
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
        
    }

    public class SlotsResponse
    {
        public Guid SlotId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}