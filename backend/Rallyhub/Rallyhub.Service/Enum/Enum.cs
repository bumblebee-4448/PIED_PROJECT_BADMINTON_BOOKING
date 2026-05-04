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
        Banned,
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
    
    public enum StatusCreateCourt
    {
        Approved,
        Rejected,
        Pending,
        Active
    }

    public enum StatusBookingDetails
    {
        Pending,
        Cancelled,
        Refunded,
        RefundPending
    }
}