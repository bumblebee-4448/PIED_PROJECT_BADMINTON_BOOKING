using Rallyhub.Repository.Entity;

namespace Rallyhub.Service.Booking;

public class Request
{
    public class SlotRequest
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
    public class CreateBookingRequest
    {
        public DateOnly Date { get; set; }
        public string? Code {get; set;}
        public Guid? CampaignId { get; set; }
        public List<CreateBookingItemRequest> Items { get; set; } = new();
    }

    public class CreateBookingItemRequest
    {
        public Guid SubCourtId { get; set; }
        public List<SlotRequest> Slots { get; set; } = new();
    }
    
}