using System.Text.Json.Serialization;
using Rallyhub.Repository.Entity;

namespace Rallyhub.Service.Court;

public class Response
{
    public class SearchCourtResponse
    {
        public Guid CourtId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Status { get; set; } = null!;
        public double AverageRating { get; set; }
        public string PictureUrl { get; set; } = null!;
        public decimal? DefaultPrice { get; set; }
        public string PhoneNumber { get; set; } = null!;
        [JsonIgnore]
        public int TotalBooked { get; set; }
        [JsonIgnore]
        public int TotalFeedbacks { get; set; }

    }
    public class SearchCourtByIdResponse : SearchCourtResponse
    {
        public TimeOnly OpenTime  { get; set; }
        public TimeOnly CloseTime { get; set; }
        public  string? Description { get; set; } = null!;
        public string MapUrl { get; set; } = null!;
    }

    
    public class SubCourtResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ListSubCourtResponse
    {
        public List<SubCourtResponse> SubCourts { get; set; } = new();
        public int TotalSubCount { get; set; }
    }

}