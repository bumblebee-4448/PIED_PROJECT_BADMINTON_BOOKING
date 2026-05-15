namespace Rallyhub.Service.Admin;

public class Request
{
    public class BanAndUnbanUserRequest
    {
        public Guid Id  { get; set; }
        public string Status { get; set; }
    }

    public class AdminRefundRequest
    {
        public required Guid BookingId  { get; set; }
        public string? ImageUrl  { get; set; }
    }
    public class GetWalletRequest
    {
        public required string Email { get; set; }
    }

    public class AddBalanceRequest
    {
        public required Guid UserId { get; set; }
        public required decimal Amount { get; set; }
    }

    public class FilterUserRequest: Base.Request.PagingRequest
    {
        public string? Search  { get; set; }
        public Guid? Id   { get; set; }
        public string? Role  { get; set; }
        public string? Status  { get; set; }
    }

    public class UserDetailRequest
    {
        public Guid Id   { get; set; }
    }
}