namespace Rallyhub.Service.Court;

public class Request
{
    public class SearchByFilterRequest: Base.Request.PagingRequest
    {
        public string? Keyword { get; set; }
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; }
    }
}
 