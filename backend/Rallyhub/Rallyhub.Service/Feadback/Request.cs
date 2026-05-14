namespace Rallyhub.Service.Feadback;

public class Request
{
    public class CreateFeedbackRequest
    {
        public required Guid BookingId  { get; set; }
        public required int Rating { get; set; }
        public string? Comment   { get; set; }
    }
    public class GetFeedbackRequest: Base.Request.PagingRequest
    {
        public required Guid CourtId  { get; set; }
    }

    public class DeteteFeedbackRequest
    {
        public required Guid Id  { get; set; }
    }

    public class UpdateFeedbackRequest
    {
        public required Guid Id   { get; set; }
        public required Guid BookingId  { get; set; }
        public required int Rating { get; set; }
        public string? Comment   { get; set; }
    }
}