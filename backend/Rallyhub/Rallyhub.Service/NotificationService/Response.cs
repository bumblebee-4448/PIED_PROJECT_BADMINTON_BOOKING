namespace Rallyhub.Service.NotificationService;

public class Response
{
    public class GetNotificationResponse
    {
        public Guid Id { get; set; }
        public Guid? BookingId { get; set; } = null;
        public Guid? UserId { get; set; }  = null;
        public string? Title { get; set; } = null;
        public string? Content { get; set; } = null;
        public string? Type { get; set; } = null;
        public bool? IsRead { get; set; } = null;
        public Guid? CourtId { get; set; } = null;
        public Guid? TransactionId { get; set; } = null;
        public Guid? ReportId { get; set; } = null;
        public Guid? SystemReportId { get; set; } = null;
        public Guid? OwnerRequestId { get; set; } = null;
        public Guid? FeedbackId { get; set; } = null;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; } = null;
    }
}