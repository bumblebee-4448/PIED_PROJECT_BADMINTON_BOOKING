using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Wallet : BaseEntity<Guid>, IAuditableEntity
{
    public string? BankName { get; set; }
    public string? BankAccount { get; set; }
    public string? BankAccountName { get; set; }
    public required decimal Balance { get; set; } = 0;
    public int Version { get; set; } = 1; //Optimistic Locking, chặn click nhiều lần
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public ICollection<Withdrawal> Withdrawals { get; set; } = new List<Withdrawal>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}