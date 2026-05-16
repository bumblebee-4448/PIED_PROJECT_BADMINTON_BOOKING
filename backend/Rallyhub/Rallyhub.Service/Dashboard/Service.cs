using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Dashboard;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<Response.DashboardAdminResponse> DashboardAdmin(string period = "Day")
    {
        var now = DateTimeOffset.UtcNow;
        
        var response = new Response.DashboardAdminResponse()
        {
            TotalAmount = (await _dbContext.Bookings.Where(x => x.Status == "Completed" && x.CreatedAt.Month == now.Month)
                                                        .SumAsync(y => (decimal?)y.FinalPrice) ?? 0) * 0.05m,
            TotalCompletedBookingsAmount = (await _dbContext.Bookings.Where(x => x.Status == "Completed" && x.CreatedAt.Month == now.Month)
                .SumAsync(y => (decimal?)y.FinalPrice) ?? 0),
            TotalUsers = await _dbContext.Users.CountAsync(x => !x.IsDeleted),
            TotalCourtActive = await _dbContext.Courts.CountAsync(x => x.Status == "Active"),
            
            PendingCourtsCount = await _dbContext.Courts.CountAsync(x => x.Status == "Pending"),
            PendingPayoutsCount = await _dbContext.Withdrawals.CountAsync(x => x.Status == "Pending"),
            PendingReportsCount = await _dbContext.SystemReports.CountAsync(x => x.Status == "Pending"),
        };

        // Fetch recent pending data
        response.PendingCourts = await _dbContext.Courts
            .Where(x => x.Status == "Pending")
            .OrderByDescending(x => x.CreatedAt)
            .Take(5)
            .Select(x => new Court.Response.SearchCourtResponse
            {
                CourtId = x.Id,
                Name = x.Name,
                Address = x.Address,
                Status = x.Status,
                PictureUrl = x.PictureUrl
            }).ToListAsync();

        response.RecentWithdrawals = await _dbContext.Withdrawals
            .Include(x => x.Wallet).ThenInclude(w => w.User)
            .OrderByDescending(x => x.CreatedAt)
            .Take(5)
            .Select(x => new Withdrawal.Response.GetWithdrawalResponse
            {
                Id = x.Id,
                UserId = x.Wallet.UserId,
                Email = x.Wallet.User.Email,
                FirstName = x.Wallet.User.FirstName,
                LastName = x.Wallet.User.LastName,
                Amount = x.Amount,
                Status = x.Status,
                CreatedAt = x.CreatedAt
            }).ToListAsync();

        response.RecentSystemReports = await _dbContext.SystemReports
            .OrderByDescending(x => x.CreatedAt)
            .Take(5)
            .Select(x => new SystemReport.Response.GetSystemReportResponse
            {
                Id = x.Id,
                Title = x.Title,
                Reason = x.Reason,
                Status = x.Status
            }).ToListAsync();

        response.RecentTransactions = await _dbContext.Transactions
            .Include(x => x.Wallet).ThenInclude(w => w.User)
            .OrderByDescending(x => x.CreatedAt)
            .Take(10)
            .Select(x => new Response.TransactionDto
            {
                Id = x.Id,
                Type = x.Type,
                Amount = x.Amount,
                Status = x.Status,
                Description = x.TransferContent,
                CreatedAt = x.CreatedAt,
                UserName = x.Wallet.User.FirstName + " " + x.Wallet.User.LastName
            }).ToListAsync();

        // Fetch data for timeline calculation
        var users = await _dbContext.Users.Where(x => !x.IsDeleted).Select(x => x.CreatedAt).ToListAsync();
        var courts = await _dbContext.Courts.Where(x => x.Status == "Active").Select(x => x.CreatedAt).ToListAsync();

        if (period.ToLower() == "month")
        {
            for (int i = 11; i >= 0; i--)
            {
                var d = now.AddMonths(-i);
                var label = d.ToString("MM/yyyy");
                var endOfMonth = new DateTimeOffset(d.Year, d.Month, DateTime.DaysInMonth(d.Year, d.Month), 23, 59, 59, TimeSpan.Zero);
                response.UserTimeline.Add(new Response.StatPoint { Date = label, Count = users.Count(u => u <= endOfMonth) });
                response.CourtTimeline.Add(new Response.StatPoint { Date = label, Count = courts.Count(c => c <= endOfMonth) });
            }
        }
        else if (period.ToLower() == "year")
        {
            for (int i = 4; i >= 0; i--)
            {
                var d = now.AddYears(-i);
                var label = d.ToString("yyyy");
                var endOfYear = new DateTimeOffset(d.Year, 12, 31, 23, 59, 59, TimeSpan.Zero);
                response.UserTimeline.Add(new Response.StatPoint { Date = label, Count = users.Count(u => u <= endOfYear) });
                response.CourtTimeline.Add(new Response.StatPoint { Date = label, Count = courts.Count(c => c <= endOfYear) });
            }
        }
        else // Day
        {
            for (int i = 29; i >= 0; i--)
            {
                var d = now.AddDays(-i);
                var label = d.ToString("dd/MM");
                var endOfDay = new DateTimeOffset(d.Year, d.Month, d.Day, 23, 59, 59, TimeSpan.Zero);
                response.UserTimeline.Add(new Response.StatPoint { Date = label, Count = users.Count(u => u <= endOfDay) });
                response.CourtTimeline.Add(new Response.StatPoint { Date = label, Count = courts.Count(c => c <= endOfDay) });
            }
        }

        return response;
    }
}