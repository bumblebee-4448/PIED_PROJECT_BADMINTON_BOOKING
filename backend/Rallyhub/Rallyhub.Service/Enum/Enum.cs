namespace Rallyhub.Service.Enum;

public class Enum
{
    public enum Role
    {
        Admin,
        Customer,
        Owner
    }

    public enum StatusUsers
    {
        Active,
        Locked,
        Unverified
    }

    public enum StatusBookings
    {
        Pending, 
        Banked, 
        Cancel, 
        Refund, 
        Complete
    }

    public enum AllStatus
    {
        Active,
        Pending,
        Baning,
        Cancelled,
        Completed
    }
}