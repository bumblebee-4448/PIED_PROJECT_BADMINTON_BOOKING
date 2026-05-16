namespace Rallyhub.Service.Dashboard;

public class Response
{
    public class DashboardAdminResponse
    {
        public required int TotalUsers { get; set; }
        public required int TotalCourtActive { get; set; }
        public required decimal TotalAmount { get; set; }
        public required decimal TotalCompletedBookingsAmount { get; set; }
        public List<StatPoint> UserTimeline { get; set; } = new();
        public List<StatPoint> CourtTimeline { get; set; } = new();

        public int PendingCourtsCount { get; set; }
        public int PendingPayoutsCount { get; set; }
        public int PendingReportsCount { get; set; }

        public List<Court.Response.SearchCourtResponse> PendingCourts { get; set; } = new();
        public List<Withdrawal.Response.GetWithdrawalResponse> RecentWithdrawals { get; set; } = new();
        public List<SystemReport.Response.GetSystemReportResponse> RecentSystemReports { get; set; } = new();
        public List<TransactionDto> RecentTransactions { get; set; } = new();
    }

    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = null!;
        public string? Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string? UserName { get; set; }
    }

    public class StatPoint
    {
        public required string Date { get; set; }
        public required int Count { get; set; }
    }
}