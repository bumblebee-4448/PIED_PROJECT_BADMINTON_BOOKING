namespace Rallyhub.Service.Report;

public class Response
{
    public class GetReportBookingsRequest
    {
        public Guid ReportBookingId { get; set; }
        public string Reason { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BookingId { get; set; }
        public Guid CourtId { get; set; }
        public string Status { get; set; } = null!;
    }
}