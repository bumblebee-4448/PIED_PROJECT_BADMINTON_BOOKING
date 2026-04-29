using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.Court;

public class Request
{
    public class CreateCourtRequest
    {
        public required string Name { get; set; } 
        public required TimeOnly OpenTime  { get; set; }
        public required TimeOnly CloseTime { get; set; }
        public required string Address { get; set; }
        public required decimal Latitude { get; set; } 
        public required decimal Longitude { get; set; }
        public required string MapUrl  { get; set; } 
        public required IFormFile PictureUrl { get; set; }
    }
    
    public class SearchByFilterRequest
    {
        public string? Keyword { get; set; }
        public int PageIndex { get; set; } = 1; 
        public int PageSize { get; set; } = 10;
        
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; }
    }

}
 