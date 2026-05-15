using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;

namespace Rallyhub.Service.Revenue
{
    public class RevenueService : IRevenueService
    {
        private readonly AppDbContext _dbContext;

        public RevenueService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response.OwnerRevenueResponse> GetOwnerRevenue(Guid ownerId, DateTime? startDate, DateTime? endDate, Guid? courtId)
        {
            // Base query for completed bookings linked to the owner
            var query = _dbContext.BookingDetails
                .Include(bd => bd.SubCourt)
                .ThenInclude(sc => sc.Court)
                .Where(bd => bd.SubCourt.Court.OwnerId == ownerId && bd.Booking.Status == "Complete");

            // Apply filters
            if (courtId.HasValue)
            {
                query = query.Where(bd => bd.SubCourt.CourtId == courtId.Value);
            }

            if (startDate.HasValue)
            {
                var startUtc = new DateTimeOffset(startDate.Value, TimeSpan.Zero);
                query = query.Where(bd => bd.Date >= startUtc);
            }

            if (endDate.HasValue)
            {
                var endUtc = new DateTimeOffset(endDate.Value.AddDays(1).AddTicks(-1), TimeSpan.Zero);
                query = query.Where(bd => bd.Date <= endUtc);
            }

            var results = await query.Select(bd => new
            {
                bd.Price,
                bd.Date,
                bd.SubCourt.CourtId,
                CourtName = bd.SubCourt.Court.Name,
                bd.BookingId
            }).ToListAsync();

            var totalRevenue = results.Sum(r => r.Price);
            var totalBookings = results.Select(r => r.BookingId).Distinct().Count();

            // Group by court
            var courtStats = results
                .GroupBy(r => new { r.CourtId, r.CourtName })
                .Select(g => new Response.CourtRevenue
                {
                    CourtId = g.Key.CourtId,
                    CourtName = g.Key.CourtName,
                    TotalRevenue = g.Sum(r => r.Price),
                    BookingCount = g.Select(r => r.BookingId).Distinct().Count()
                })
                .ToList();

            // Group by date for chart data
            var chartData = results
                .GroupBy(r => r.Date.Date)
                .OrderBy(g => g.Key)
                .Select(g => new Response.RevenueStats
                {
                    Date = g.Key.ToString("yyyy-MM-dd"),
                    Amount = g.Sum(r => r.Price),
                    BookingCount = g.Select(r => r.BookingId).Distinct().Count()
                })
                .ToList();

            return new Response.OwnerRevenueResponse
            {
                TotalRevenue = totalRevenue,
                TotalBookings = totalBookings,
                Courts = courtStats,
                ChartData = chartData
            };
        }
    }
}
