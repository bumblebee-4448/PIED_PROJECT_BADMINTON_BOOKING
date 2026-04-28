namespace Rallyhub.Service.MapService;

public class Response
{
    public class CourtMapItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Status { get; set; }
        public string PictureUrl { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
        public double? DistanceKm { get; set; }
        public string? VietMapDisplay { get; set; }
    }

    public class MapSearchResponse
    {
        public List<CourtMapItem> ListCourts { get; set; } = new();
        public int TotalCount { get; set; }
    }
}