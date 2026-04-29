namespace Rallyhub.Service.MapService;

public class Response
{
    public class CourtMapItem
    {
        public Guid Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class MapSearchResponse
    {
        public List<CourtMapItem> ListCourts { get; set; } = new();
        public int TotalCount { get; set; }
    }
}