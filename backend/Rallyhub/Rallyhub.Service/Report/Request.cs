namespace Rallyhub.Service.Report;

public class Request
{
    public class CreateReportBookingsRequest
    {
        public required string Reason { get; set; }
        public Guid BookingId { get; set; }
    }
    public class GetReportBookingsRequest: Base.Request.PagingRequest
    {
       // public string? Status { get; set; }
    }

    public class ConfirmReportRequest
    {
        public Guid ReportId { get; set; }
    }
}