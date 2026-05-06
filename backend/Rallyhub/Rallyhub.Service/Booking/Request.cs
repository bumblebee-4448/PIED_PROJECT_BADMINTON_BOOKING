namespace Rallyhub.Service.Booking;

public class Request
{
    public class GetAvailableSlotsRequest
    {
        public Guid SubCourtId { get; set; }
        public DateOnly Date { get; set; }
    }
    public class SlotRequest
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
    public class HoldBookingRequest
    {
        public Guid SubCourtId { get; set; }
        public DateOnly Date { get; set; }
        public List<SlotRequest> Slots { get; set; } = new();
    }
}