namespace Rallyhub.Service.MapService;

public class Request
{
    public class BoundingBoxRequest
    {
        public decimal MinLon { get; set; }
        public decimal MinLat { get; set; }
        public decimal MaxLon { get; set; }
        public decimal MaxLat { get; set; }
    }

    public class RadiusRequest
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public double RadiusKm { get; set; } = 10;
    }
    
    public class SearchByTextRequest
    {
        public string Text { get; set; } = null!;
        public double RadiusKm { get; set; } = 10;
    }
}