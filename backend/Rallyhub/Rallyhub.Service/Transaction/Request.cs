namespace Rallyhub.Service.Transaction;

public class Request
{
    public class CreateTransactionRequest
    {
        public string Type { get; set; }//kiểu
        public decimal Amount { get; set; }//decimal TransferAmount
        public decimal BalanceBefore { get; set; }
        public decimal BalanceAfter  { get; set; }
        public string Status { get; set; }
        public string? SePayId { get; set; }//long Id
        public string? BankRefCode { get; set; }//ReferenceCode
        public string? BankAccountNumber { get; set; }//AccountNumber
        public string? TransferContent { get; set; }//Content
        public string? ActionCode { get; set; }//Code
        public string? Signature { get; set; }//Description
        
        public Guid? BookingId { get; set; }
        public Guid WalletId { get; set; }
        
        // public string Gateway { get; set; }
        // public string TransactionDate { get; set; }
        // public string AccountNumber { get; set; }
        // public string SubAccount { get; set; }
        // public string Code { get; set; }
        // public string Content { get; set; }
        // public string TransferType { get; set; }
        // public string Description { get; set; }
        // public decimal TransferAmount { get; set; }
        // public string ReferenceCode { get; set; }
        // public decimal Accumulated { get; set; }
        // public long Id { get; set; }
        
    }
    public class TypeList()
    {
        public const string Deposit = "Deposit";
        public const string Refund = "Refund";
        public const string AdminUp = "AdminUp";
        public const string Receive = "Receive";
        public const string Payment = "Payment";
        public const string Withdrawal = "Withdrawal";
        public const string AdminDeduct = "AdminDeduct";
    }
}
