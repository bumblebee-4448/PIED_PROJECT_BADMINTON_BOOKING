namespace Rallyhub.Service.Feedback;

public class Response
{
    public class GetFeedbackResponse
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public Guid CourtId { get; set; }
        public Guid CustomerId { get; set; }
        public string NameCustomer { get; set; }
        public string? Comment {get; set;}
        public int Rating {get; set;}
        public DateTimeOffset CreatedAt {get; set;}
    }
}
