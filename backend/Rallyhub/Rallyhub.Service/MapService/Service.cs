using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rallyhub.Repository;
using System.Text.Json;
using StatusCourt = Rallyhub.Service.Enum.Enum.StatusCourt;
namespace Rallyhub.Service.MapService;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly MapOptions _mapOptions = new ();

    public Service(AppDbContext dbContext, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _httpClientFactory = httpClientFactory;
        configuration.GetSection(nameof(MapOptions)).Bind(_mapOptions);
    }
    
    public async Task<Response.MapSearchResponse> SearchByBoundingBox(BoundingBoxRequest request, CancellationToken cancellationToken)
    {
        if(request.MinLon >= request.MaxLon || request.MinLat >= request.MaxLat)
        {
            throw new Exception("Bounding boxes are invalid");
        }

        var courts = await _dbContext.Courts
            .Where(x => x.Status == nameof(StatusCourt.Active)
                        && x.Latitude >= request.MinLat && x.Latitude <= request.MaxLat
                        && x.Longitude >= request.MinLon && x.Longitude <= request.MaxLon)
            .Select(x => new Response.CourtMapItem
            {
                Id = x.Id,
                Name = x.Name,
                Address =  x.Address,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Status =  x.Status,
                PictureUrl =  x.PictureUrl,
                OpenTime =   x.OpenTime,
                CloseTime =   x.CloseTime,
            })
            .ToListAsync(cancellationToken);

        if (courts.Count == 0)
        {
            return new Response.MapSearchResponse
            {
                ListCourts =  courts,
                TotalCount =  0
            };
        }
        await ConvertDisPlayVietMap(courts, cancellationToken);
        return new Response.MapSearchResponse
        {
            ListCourts = courts,
            TotalCount = courts.Count
        };
    }

    public async Task<Response.MapSearchResponse> SearchByRadius(RadiusRequest request, CancellationToken cancellationToken)
    {
        if (request.Latitude is < -90 or > 90 || request.Longitude is < -180 or > 180)
        {
            throw new Exception("Tọa độ không hợp lệ");
        }

        if (request.RadiusKm is <= 0 or > 50)
        {
            throw new ArgumentException("RadiusKm phải từ 0 đến 50 ");
        }
        double lat = (double)request.Latitude;
        double lon = (double)request.Longitude;
        double r = request.RadiusKm;
        var courts = await _dbContext.Courts
            .Where(x => x.Status == nameof(StatusCourt.Active))
            .Select(c => new
            {
                Court = c,  
                DistanceKm =  
                    6371 * 2 * Math.Asin(Math.Sqrt(  
                        Math.Pow(Math.Sin(((double)c.Latitude  - lat) * Math.PI / 180 / 2), 2) +  
                        Math.Cos(lat * Math.PI / 180) *  
                        Math.Cos((double)c.Latitude  * Math.PI / 180) *  
                        Math.Pow(Math.Sin(((double)c.Longitude - lon) * Math.PI / 180 / 2), 2)  
                    )) 
            })
            .Where( x=> x.DistanceKm <= r)
            .OrderBy(x => x.DistanceKm)
            .Select(x => new Response.CourtMapItem
            {
                Id = x.Court.Id,
                Name = x.Court.Name,
                Address = x.Court.Address,
                Latitude = x.Court.Latitude,
                Longitude = x.Court.Longitude,
                Status = x.Court.Status,
                PictureUrl = x.Court.PictureUrl,
                OpenTime = x.Court.OpenTime,
                CloseTime = x.Court.CloseTime,
                DistanceKm = Math.Round(x.DistanceKm, 2),
            }).ToListAsync(cancellationToken);
        
        if (courts.Count == 0)
        {
            return new Response.MapSearchResponse
            {
                ListCourts = courts,
                TotalCount = 0
            };
            
        }
        await ConvertDisPlayVietMap(courts, cancellationToken);
        return new Response.MapSearchResponse
        {
            ListCourts = courts,
            TotalCount = courts.Count
        };
    }

    private async Task ConvertDisPlayVietMap(List<Response.CourtMapItem> courts,
        CancellationToken cancellationToken)
    {
       var semaphore = new SemaphoreSlim(_mapOptions.VietMapConcurrency);
       var tasks = courts.Select(async court =>
       {
           await semaphore.WaitAsync(cancellationToken);
           try
           {
               court.VietMapDisplay = await ReverseGeocodeAsync(
                   court.Latitude, court.Longitude, cancellationToken);
           }
           catch
           {
               court.VietMapDisplay = null;
           }
           finally
           {
               semaphore.Release();
           }
       });
       await Task.WhenAll(tasks);
    }

    private async Task<string?> ReverseGeocodeAsync(  
        decimal lat, decimal lon,  
        CancellationToken cancellationToken)  
    {        
        var client = _httpClientFactory.CreateClient("VietMap");  
       
        var url = $"{_mapOptions.BaseUrl}/reverse/v3" +
                  $"?apikey={_mapOptions.ApiKey}&lat={lat}&lng={lon}";  
  
        var response = await client.GetAsync(url, cancellationToken);  
        if (!response.IsSuccessStatusCode) return null;  
  
        var json = await response.Content.ReadAsStringAsync(cancellationToken);  
        using var doc = JsonDocument.Parse(json);  
  
        if (doc.RootElement.ValueKind == JsonValueKind.Array &&  
            doc.RootElement.GetArrayLength() > 0)  
        {            var first = doc.RootElement[0];  
            if (first.TryGetProperty("display", out var display))  
                return display.GetString();  
        }  
        return null;  
    }
    
}
    
