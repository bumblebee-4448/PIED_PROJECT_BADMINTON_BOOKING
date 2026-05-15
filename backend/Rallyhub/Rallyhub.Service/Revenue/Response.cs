using System;
using System.Collections.Generic;

namespace Rallyhub.Service.Revenue
{
    public class Response
    {
        public class OwnerRevenueResponse
        {
            public decimal TotalRevenue { get; set; }
            public int TotalBookings { get; set; }
            public List<CourtRevenue> Courts { get; set; } = new List<CourtRevenue>();
            public List<RevenueStats> ChartData { get; set; } = new List<RevenueStats>();
        }

        public class CourtRevenue
        {
            public Guid CourtId { get; set; }
            public string CourtName { get; set; } = string.Empty;
            public decimal TotalRevenue { get; set; }
            public int BookingCount { get; set; }
        }

        public class RevenueStats
        {
            public string Date { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public int BookingCount { get; set; }
        }
    }
}
