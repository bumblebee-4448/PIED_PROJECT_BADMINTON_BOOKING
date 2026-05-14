using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Notification : BaseEntity<Guid>, IAuditableEntity
{
    public Booking? Booking { get; set; }
    public Guid? BookingId {get; set;}
    public User User { get; set; }
    public Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Type { get; set; } //booking, feedback, report, ownerRequeset, courtHasBooking, withdrawal
    public required bool IsRead { get; set; } = false;
    public Court? Court { get; set; }
    public Guid? CourtId { get; set; }
    // public Transaction? Transaction { get; set; }
    // public Guid? TransactionId { get; set; }
    public Report? Report { get; set; }
    public Guid? ReportId { get; set; }
    public SystemReport? SystemReport { get; set; }
    public Guid? SystemReportId { get; set; }
    public OwnerRequest? OwnerRequest { get; set; }
    public Guid? OwnerRequestId { get; set; }
    public Feedback? Feedback { get; set; }
    public Guid? FeedbackId { get; set; }
    public Withdrawal? Withdrawal { get; set; }
    public Guid? WithdrawalId { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}