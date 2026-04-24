using Rallyhub.Repository.Abtraction;

namespace Rallyhub.Repository.Entity;

public class Wallet : BaseEntity<Guid>, IAuditableEntity
{
    public required string BankName { get; set; }
    public required string BankAccount { get; set; }
    public required decimal Balance { get; set; } = 0;
    public int Version { get; set; } //Optimistic Locking, chặn clic nhiều lần
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}