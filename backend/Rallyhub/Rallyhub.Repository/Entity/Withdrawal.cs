using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Withdrawal : BaseEntity<Guid>, IAuditableEntity
{
    public required decimal Amount { get; set; }
    public required string BankName { get; set; }
    public required string BankAccountNumber { get; set; }
    public required string BankAccountName { get; set; }
    public string Status { get; set; } = "Pending"; 
    public string? RejectionReason { get; set; }
    public string? AdminNote { get; set; }
    
    public Guid? ProcessedByAdminId { get; set; } 
    public User? ProcessedByAdmin { get; set; }
    
    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; }
    
    public Guid? TransactionId { get; set; }
    public Transaction? Transaction { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}