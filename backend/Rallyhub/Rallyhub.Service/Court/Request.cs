namespace Rallyhub.Service.Court;

public class Request
{
    public class SearchByFilterRequest
    {
        public string? Keyword { get; set; }
        public int PageIndex { get; set; } = 1; 
        public int PageSize { get; set; } = 10;
        
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; }
    }
    public class GetAvailableSlotsRequest
    {
        public Guid SubCourtId { get; set; }
        public DateOnly Date { get; set; }
    }
}
 