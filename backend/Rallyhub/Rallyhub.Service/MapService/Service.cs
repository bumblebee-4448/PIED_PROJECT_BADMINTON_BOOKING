using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rallyhub.Repository;
using System.Text.Json;
using StatusCreateCourt = Rallyhub.Service.Enum.Enum.StatusCreateCourt;
namespace Rallyhub.Service.MapService;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly MapOptions _mapOptions = new();

    public Service(AppDbContext dbContext, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _httpClientFactory = httpClientFactory;
        configuration.GetSection(nameof(MapOptions)).Bind(_mapOptions);
    }

    public async Task<Response.MapSearchResponse> SearchByBoundingBox(Request.BoundingBoxRequest request,
        CancellationToken cancellationToken)
    {
        var markers = await _dbContext.Courts
            .Where(x => x.Status == nameof(StatusCreateCourt.Approved)
                        && x.Latitude >= request.MinLat && x.Latitude <= request.MaxLat
                        && x.Longitude >= request.MinLon && x.Longitude <= request.MaxLon)
            .Select(x => new Response.CourtMapItem
            {
                Id = x.Id,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
            }).ToListAsync(cancellationToken);
        return new Response.MapSearchResponse
        {
            ListCourts = markers,
            TotalCount = markers.Count,
        };
    }

    public async Task<Response.MapSearchResponse> SearchByRadius(Request.RadiusRequest request,
        CancellationToken cancellationToken)
    {
        var allCourts = await _dbContext.Courts
            .Where(x => x.Status == nameof(StatusCreateCourt.Approved))
            .Select(x => new Response.CourtMapItem
            {
                Id = x.Id,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
            }).ToListAsync(cancellationToken);
        if (allCourts.Count == 0)
        {
            return new Response.MapSearchResponse
            {
                ListCourts = allCourts,
                TotalCount =  allCourts.Count,
            };
        }
        
        var distances = await GetDistanceFromMatrix(request.Latitude, request.Longitude, allCourts);
        
        var markers = new  List<Response.CourtMapItem>();
        for (int i = 0; i < allCourts.Count; i++)
        {
            if (distances[i] / 1000.0 <= request.RadiusKm)
            {
                markers.Add(allCourts[i]);
            }
        }

        return new Response.MapSearchResponse
        {
            ListCourts = markers,
            TotalCount = markers.Count,
        };
    }

    public async Task<Response.MapSearchResponse> SearchByText(Request.SearchByTextRequest request,
        CancellationToken cancellationToken)
    {
        var coordinate = await GeocodeText(request.Text);
        if (coordinate == null)
        {
            return new Response.MapSearchResponse
            {
                ListCourts = new(),
                TotalCount = 0
            };
        }

        return await SearchByRadius(new Request.RadiusRequest
        {
            Latitude = coordinate.Value.Latitude,
            Longitude = coordinate.Value.Longitude,
            RadiusKm = request.RadiusKm
        }, cancellationToken);
    }

    private async Task<List<double>> GetDistanceFromMatrix(
        decimal userLat, decimal userLon, List<Response.CourtMapItem> courts)
    {
        var client = _httpClientFactory.CreateClient("VietMap");
        var url = $"{_mapOptions.BaseUrl}/matrix?api-version=1.1&apikey={_mapOptions.ApiKey}"
                        + $"&point={userLat},{userLon}";
        foreach (var court in courts)
            url += $"&point={court.Latitude},{court.Longitude}";
        url += "&sources=0";
        url += "&annotation=distance";
        url += $"&destinations={string.Join(";", Enumerable.Range(1, courts.Count))}";
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return Enumerable.Repeat(double.MaxValue, courts.Count).ToList();
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var distancesArray = doc.RootElement.GetProperty("distance")[0];
        var result = new List<double>();
        foreach (var item in distancesArray.EnumerateArray())
            result.Add(item.GetDouble());
        
        return result;
    }

    private async Task<(decimal Latitude, decimal Longitude)?> GeocodeText(
        string text)
    {
        var client = _httpClientFactory.CreateClient("VietMap");
        var url = $"{_mapOptions.BaseUrl}/search?api-version=1.1" +
                  $"&apikey={_mapOptions.ApiKey}" +
                  $"&text={Uri.EscapeDataString(text)}";
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        if (doc.RootElement.ValueKind == JsonValueKind.Array &&
            doc.RootElement.GetArrayLength() > 0)
        {
            var first = doc.RootElement[0];
            if(first.TryGetProperty("lat", out var lat) &&
               first.TryGetProperty("lon", out var lon))
                return ((decimal)lat.GetDouble(), (decimal)lon.GetDouble());
        }
        return null;
    }
}
