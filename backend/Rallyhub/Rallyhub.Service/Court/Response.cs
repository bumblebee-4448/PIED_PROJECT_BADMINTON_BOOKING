namespace Rallyhub.Service.Court;

public class Response
{
    public class CreateCourtResponse
    {
        public Guid CourtId { get; set; }
        public string Status { get; set; } = null!;
    }
    
    public class SearchCourtResponse
    {
        public Guid CourtId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Status { get; set; } = null!;
        public double AverageRating { get; set; }
    }
}