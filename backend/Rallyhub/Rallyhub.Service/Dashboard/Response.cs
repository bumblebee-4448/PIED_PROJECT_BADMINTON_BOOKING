namespace Rallyhub.Service.Dashboard;

public class Response
{
    public class DashboardAdminResponse
    {
        public required int TotalUsers { get; set; }
        public required int TotalCourtActive { get; set; }
        public required decimal TotalAmount { get; set; }
        public required decimal TotalCompletedBookingsAmount { get; set; }
        
    }
}