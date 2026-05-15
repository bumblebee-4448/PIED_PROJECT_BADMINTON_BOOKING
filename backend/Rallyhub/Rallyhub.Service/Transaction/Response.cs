namespace Rallyhub.Service.Transaction;

public class Response
{
    public class GetTransactionResponse
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public decimal Amount { get; set; }
        public string? BankRefCode { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? Status { get; set; }
        public Guid? BookingId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        // public Guid WalletId { get; set; }
    }
    public class AdminGetTransactionResponse : GetTransactionResponse
    {
        public string? Mail { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal BalanceBefore { get; set; }
        public decimal BalanceAfter  { get; set; }
        public string? SePayId { get; set; } //unique
        public string? TransferContent { get; set; }
        public string? ActionCode { get; set; } //unique
        public string? Signature { get; set; }
        public Guid WalletId { get; set; }
    }
}
