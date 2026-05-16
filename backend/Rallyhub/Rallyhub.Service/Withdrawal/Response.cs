namespace Rallyhub.Service.Withdrawal;

public class Response
{
    public class GetWithdrawalResponse()
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Email { get; set; } = null;
        public string? Avatar { get; set; } = null;
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public decimal Amount { get; set; }
        public string? BankName { get; set; } = null;
        public string? BankAccountNumber { get; set; } = null;
        public string? BankAccountName { get; set; }      = null;
        public string Status { get; set; }
        public Guid WalletId { get; set; }
        public Guid? TransactionId { get; set; } = null;
        public DateTimeOffset CreatedAt { get; set; }
    }
    
    public class UsergetWithdrawalResponse() : GetWithdrawalResponse
    {
        public string? RejectionReason { get; set; }
        public string? AdminNote { get; set; }
        public Guid? ProcessedByAdminId { get; set; } 
        public DateTimeOffset UpdatedAt { get; set; }
    }
}