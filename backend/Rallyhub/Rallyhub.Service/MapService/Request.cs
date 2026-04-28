namespace Rallyhub.Service.MapService;

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
    public double RadiusKm { get; set; } = 5;
}