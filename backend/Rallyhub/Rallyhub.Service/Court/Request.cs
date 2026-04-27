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
        public required string PictureUrl { get; set; }
    }
    
    public class SearchByFilterRequest
    {
        public string? Keyword { get; set; }
        public int PageIndex { get; set; } = 1; // current page
        public int PageSize { get; set; } = 10; // each page 10 courts
    }

    public class SearchByMapRequest
    {
        // can combine when open map
        public string? Keyword { get; set; }

        //Bounding Box
        public double? NeLatitude { get; set; }
        public double? NeLongitude { get; set; }
        public double? SwLatitude { get; set; }
        public double? SwLongitude { get; set; }

        //Search nearby
        public double? UserLatitude { get; set; }
        public double? UserLongitude { get; set; }
        public double? Radius { get; set; }

        //Limit the amount of marker
        public int Limit { get; set; } = 50;

        public bool IsBoundingBoxSearch =>
            NeLatitude.HasValue && NeLongitude.HasValue &&
            SwLatitude.HasValue && SwLongitude.HasValue;

        public bool IsNearbySearch =>
            UserLatitude.HasValue && UserLongitude.HasValue &&
            Radius.HasValue;
    }

}
 