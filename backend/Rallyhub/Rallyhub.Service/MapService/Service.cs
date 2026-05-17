using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rallyhub.Repository;
using System.Text.Json;
using System.Globalization;
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
            .Where(x => x.Status == "Active"
                        && x.Latitude != null && x.Latitude >= request.MinLat && x.Latitude <= request.MaxLat
                        && x.Longitude != null && x.Longitude >= request.MinLon && x.Longitude <= request.MaxLon)
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
            .Where(x => x.Status == "Active" && x.Latitude != null && x.Longitude != null)
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
                SearchCenterLatitude = request.Latitude,
                SearchCenterLongitude = request.Longitude
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
            SearchCenterLatitude = request.Latitude,
            SearchCenterLongitude = request.Longitude
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
        //Thịnh fixbug lỗi dấu câu
        var client = _httpClientFactory.CreateClient("VietMap");
        var url = $"{_mapOptions.BaseUrl}/matrix?api-version=1.1&apikey={_mapOptions.ApiKey}"
                        + $"&point={userLat.ToString(CultureInfo.InvariantCulture)},{userLon.ToString(CultureInfo.InvariantCulture)}";
        foreach (var court in courts)
            //Thịnh fixbug lỗi dấu câu
            url += $"&point={court.Latitude?.ToString(CultureInfo.InvariantCulture)},{court.Longitude?.ToString(CultureInfo.InvariantCulture)}";
        url += "&sources=0";
        url += "&annotation=distance";
        url += $"&destinations={string.Join(";", Enumerable.Range(1, courts.Count))}";
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return Enumerable.Repeat(double.MaxValue, courts.Count).ToList();
        var json = await response.Content.ReadAsStringAsync();
        //Console.WriteLine(json);
        using var doc = JsonDocument.Parse(json);
        //Thịnh fixbug lỗi dấu câu
        if (!doc.RootElement.TryGetProperty("distances", out var distancesProp) || 
            distancesProp.ValueKind != JsonValueKind.Array || 
            distancesProp.GetArrayLength() == 0)
        {
            return Enumerable.Repeat(double.MaxValue, courts.Count).ToList();
        }

        var distancesArray = distancesProp[0];
        if (distancesArray.ValueKind != JsonValueKind.Array)
        {
            return Enumerable.Repeat(double.MaxValue, courts.Count).ToList();
        }

        var result = new List<double>();
     
        foreach (var item in distancesArray.EnumerateArray())
        { 
            //Thịnh fixbug lỗi dấu câu
            if (item.ValueKind == JsonValueKind.Number)
                result.Add(item.GetDouble());
            else
                result.Add(double.MaxValue);
        }
        
        // Ensure the result has the same count as courts to avoid IndexOutOfRangeException in SearchByRadius
        while (result.Count < courts.Count)
        {
            result.Add(double.MaxValue);
        }
        //Thịnh fixbug lỗi dấu câu
        return result;
    }

    public async Task<(decimal Latitude, decimal Longitude)?> GeocodeText(
        string text)
    {
        var client = _httpClientFactory.CreateClient("VietMap");
        var searchUrl = 
                         $"{_mapOptions.BaseUrl}/search/v3" +
                         $"?api-version=1.1" +
                         $"&apikey={_mapOptions.ApiKey}" +
                         $"&text={Uri.EscapeDataString(text)}";
        var searchResponse  = await client.GetAsync(searchUrl);
        if (!searchResponse.IsSuccessStatusCode) 
                return null;
        var searchJson  = await searchResponse.Content.ReadAsStringAsync();
        using var searchDoc  = JsonDocument.Parse(searchJson);
        if (searchDoc.RootElement.ValueKind != JsonValueKind.Array ||
            searchDoc.RootElement.GetArrayLength() == 0)
        {
            return null;
        }
        var firstResult = searchDoc.RootElement[0];
        if (!firstResult.TryGetProperty("ref_id", out var refIdElement))
        {
            return null;
        }
        var refId = refIdElement.GetString();
        if (string.IsNullOrWhiteSpace(refId))
        {
            return null;
        }
        var placeUrl =
            $"{_mapOptions.BaseUrl}/place/v3" +
            $"?apikey={_mapOptions.ApiKey}" +
            $"&refid={Uri.EscapeDataString(refId)}";
        var placeResponse = await client.GetAsync(placeUrl);
        if (!placeResponse.IsSuccessStatusCode)
            return null;
        var placeJson = await placeResponse.Content.ReadAsStringAsync();
        using var placeDoc = JsonDocument.Parse(placeJson);
        var root = placeDoc.RootElement;

        if (root.TryGetProperty("lat", out var latElement) &&
            root.TryGetProperty("lng", out var lngElement))
        {
            return (
                (decimal)latElement.GetDouble(),
                (decimal)lngElement.GetDouble()
            );
        }

        return null;
    }
}