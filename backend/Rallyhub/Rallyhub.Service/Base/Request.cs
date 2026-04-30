namespace Rallyhub.Service.Base;

public class Request
{
    public class Pagination
    {
        public Guid? Id { get; set; }
        public string? Search { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
    }
}