namespace Rallyhub.Service.Admin;

public class Request
{
    public class GetPendingCourtsRequest
    {
        public string? Name { get; set; }
        public int PageIndex { get; set; } = 1; 
        public int PageSize { get; set; } = 10;
    }
}