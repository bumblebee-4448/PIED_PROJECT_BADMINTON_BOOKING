using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Transaction : BaseEntity<Guid>, IAuditableEntity
{
    public required string Type { get; set; }
    public decimal Amount { get; set; }
    public decimal BalanceBefore { get; set; }
    public decimal BalanceAfter  { get; set; }
    
    public string? SePayId { get; set; } //unique
    public string? BankRefCode { get; set; } //unique
    public string? BankAccountNumber { get; set; }
    public string? TransferContent { get; set; }
    public string? ActionCode { get; set; } //unique
    public string? Signature { get; set; }
    public string Status { get; set; } = "Success";
    
    public Guid? BookingId { get; set; }
    public Booking? Booking { get; set; }
    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; }
    // public Notification? Notification { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}