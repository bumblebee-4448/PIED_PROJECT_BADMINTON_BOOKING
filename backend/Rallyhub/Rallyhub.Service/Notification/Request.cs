namespace Rallyhub.Service.Notification;

public class Request
{
    public class TypeNotification
    {
        public const string CourtHasBooking = "CourtHasBooking";
        public const string BookingPaid = "BookingPaid";
        public const string BookingRefunded = "BookingRefunded";
        public const string BookingCancelled = "BookingCancelled";
        public const string BookingCompleted = "BookingCompleted";
        public const string OwnerRequestSubmitted = "OwnerRequestSubmitted";
        public const string OwnerRequestApproved = "OwnerRequestApproved";
        public const string OwnerRequestRejected = "OwnerRequestRejected";
        public const string FeedbackCreated = "FeedbackCreated";
        public const string ReportCreated = "ReportCreated";
        public const string SystemReportCreated = "SystemReportCreated";
        public const string WalletDepositSuccess = "WalletDepositSuccess";
    }

    public class CreateNotificationRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; } //feedback, report, systemReport, courtHasBooking
        
        public Guid? BookingId { get; set; }
        public Guid? CourtId { get; set; }
        public Guid? ReportId { get; set; }
        public Guid? SystemReportId { get; set; }
        public Guid? OwnerRequestId { get; set; }
        public Guid? FeedbackId { get; set; }
    }
}