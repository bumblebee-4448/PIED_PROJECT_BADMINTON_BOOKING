namespace Rallyhub.Service.Wallet;

public class Request
{
    public class AddInforWalletRequest()
    {
        public required string BankName { get; set; }
        public required string BankAccount { get; set; }
    }
}