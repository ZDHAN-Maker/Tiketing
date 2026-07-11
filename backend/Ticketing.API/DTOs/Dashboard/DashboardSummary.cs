    using System;

namespace Ticketing.API.DTOs.Dashboard
{
    public class DashboardSummaryDto
    {
        public decimal TotalRevenue { get; set; }
        public int TotalTicketsSold { get; set; }
        public int TotalCheckIns { get; set; }
        public int TotalRefunds { get; set; }
        public int TotalActiveEvents { get; set; }
    }
}