namespace Rallyhub.Service.Booking;

public class Response
{
    
    public class SlotResponse
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class HoldBookingResponse
    {
        public Guid BookingId {get; set;}
        public decimal TotalPrice { get; set; }
        public DateTimeOffset ExpiredAt { get; set; }
    }

    public class BookingDetailItem
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }

    public class GetBookingResponse
    {
        public Guid BookingId {get; set;}
        public decimal TotalPrice {get; set;}
        public DateTimeOffset ExpiredAt {get; set;}
        public string Status { get; set; } = null!;
        public List<BookingDetailItem> Slots { get; set; } = new();
        public string QrCodeUrl { get; set; } = null!;
    }
}