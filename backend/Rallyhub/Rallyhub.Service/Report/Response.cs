namespace Rallyhub.Service.Report;

public class Response
{
    public class GetReportBookingsRequest
    {
        public string Reason { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BookingId { get; set; }
        public Guid CourtId { get; set; }
    }
}