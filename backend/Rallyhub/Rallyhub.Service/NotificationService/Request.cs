namespace Rallyhub.Service.NotificationService;

public class Request
{
    public class CreateNotificationRequest
    {
        public Guid? BookingId {get; set;}
        public Guid UserId { get; set; } //
        public string Title { get; set; } //
        public string Content { get; set; } //
        public string Type { get; set; } //
        public Guid? CourtId { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? ReportId { get; set; }
        public Guid? SystemReportId { get; set; }
        public Guid? OwnerRequestId { get; set; }
        public Guid? FeedbackId { get; set; }
    }
    
}