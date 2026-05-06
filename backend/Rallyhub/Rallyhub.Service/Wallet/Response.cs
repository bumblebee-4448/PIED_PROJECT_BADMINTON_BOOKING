namespace Rallyhub.Service.Wallet;

public class Response
{
    public class GetInfoWalletResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string? BankName { get; set; } = null;
        public string? BankAccount { get; set; } = null;
        public string? BankAccountName { get; set; } = null;
        public decimal Balance { get; set; }
    }
    
}