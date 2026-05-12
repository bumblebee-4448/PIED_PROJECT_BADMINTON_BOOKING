namespace Rallyhub.Service.Feadback;

public class Request
{
    public class CreateFeadbackRequest
    {
        public Guid BookingId  { get; set; }
        public required int Rating { get; set; }
        public string? Comment   { get; set; }
    }
    public class GetFeadbackRequest: Base.Request.PagingRequest
    {
        public Guid CourtId  { get; set; }
    }
}