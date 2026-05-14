namespace Rallyhub.Service.Withdrawal;

public class Request
{
    public class CreateWithdrawalRequest()
    {
        public required decimal Amount { get; set; }
    }
    
    public class GetWithdrawalRequest()
    {
        public Guid? UserId { get; set; } = null;
    }

    public class RejectWithdrawalRequest
    {
        public Guid WithdrawalRequestId { get; set; }
        public required string Reason { get; set; }
        public string? Note { get; set; }
    }
    
}