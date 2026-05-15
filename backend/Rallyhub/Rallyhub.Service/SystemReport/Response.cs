namespace Rallyhub.Service.SystemReport;

public class Response
{
    public class GetSystemReportResponse
    {
        public required Guid Id  { get; set; }
        public required string Title { get; set; }
        public required string Reason { get; set; }
        public required string Status { get; set; } 
    }
}