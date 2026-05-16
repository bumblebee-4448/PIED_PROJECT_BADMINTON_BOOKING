namespace Rallyhub.Service.SystemReport;

public class Request
{
    public class CreateSystemReportRequest
    {
        public required string Title { get; set; }
        public required string Reason { get; set; }
    }
    public class GetSystemReportRequest: Base.Request.PagingRequest
    {
        // public string? Status { get; set; }
    }

    public class SubmitReportReplyRequest
    {
        public required Guid Id { get; set; } 
    }
}