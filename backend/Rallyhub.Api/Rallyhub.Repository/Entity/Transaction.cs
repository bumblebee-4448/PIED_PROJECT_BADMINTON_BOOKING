using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Transaction : BaseEntity<Guid>, IAuditableEntity
{
    public required string Type { get; set; }
    public decimal Amount { get; set; }
    public decimal BalanceBefore { get; set; }
    public decimal BalanceAfter  { get; set; }
    
    public required string SePayId { get; set; } //unique
    public required string BankRefCode { get; set; } //unique
    public required string BankAccountNumber { get; set; }
    public required string TransferContent { get; set; }
  
    public required string ActionCode { get; set; } //unique
    public required string Signature { get; set; }
    public string Status { get; set; } = "Success";
    
    public Guid BookingId { get; set; }
    public Booking Booking { get; set; }
    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}