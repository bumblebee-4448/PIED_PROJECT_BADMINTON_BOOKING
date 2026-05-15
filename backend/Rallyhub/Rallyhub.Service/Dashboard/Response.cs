namespace Rallyhub.Service.Dashboard;

public class Response
{
    public class DashboardAdminResponse
    {
        public required int TotalUsers { get; set; }
        public required int TotalCourtActive { get; set; }
        public required decimal TotalAmount { get; set; }
    }
    // public class DashboardOwnerResponse
    // {
    //     public required decimal TotalAmount { get; set; }
    //     public required int TotalBookings  { get; set; }
    //     public required int TotalBookingsToday  { get; set; }
    //     public required decimal AvgRating  { get; set; }
    // }
}