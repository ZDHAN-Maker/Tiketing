using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data;
using Ticketing.API.DTOs.Dashboard;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly TicketingDbContext _context;

        public DashboardRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardSummaryDto> GetOverallStatisticsAsync()
        {
            // Statistik keseluruhan tetap sama
            var totalRevenue = await _context.Payments
                .Where(p => p.Status == "success")
                .SumAsync(p => p.Amount);

            var totalTicketsSold = await _context.Orders
                .Where(o => o.Status == "paid")
                .SelectMany(o => o.OrderItems)
                .SumAsync(oi => (int)oi.Quantity);

            var totalCheckIns = await _context.CheckIns
                .Where(c => c.Status == "success")
                .CountAsync();

            var totalRefunds = await _context.Refunds
                .Where(r => r.Status == "approved" || r.Status == "success")
                .CountAsync();

            var totalActiveEvents = await _context.Events
                .Where(e => e.Status == "active" || e.Status == "published")
                .CountAsync();

            return new DashboardSummaryDto
            {
                TotalRevenue = totalRevenue,
                TotalTicketsSold = totalTicketsSold,
                TotalCheckIns = totalCheckIns,
                TotalRefunds = totalRefunds,
                TotalActiveEvents = totalActiveEvents
            };
        }

        public async Task<DashboardSummaryDto> GetEventStatisticsAsync(long eventId)
        {
            // Menggunakan relasi: Order -> OrderItem -> TicketType -> Event
            
            // 1. Total Revenue per Event
            var totalRevenue = await _context.Payments
                .Include(p => p.Order)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.TicketType)
                .Where(p => p.Status == "success" && 
                            p.Order.OrderItems.Any(oi => oi.TicketType.EventId == eventId))
                .SumAsync(p => p.Amount);

            // 2. Total Tiket Terjual per Event
            var totalTicketsSold = await _context.OrderItems
                .Include(oi => oi.TicketType)
                .Include(oi => oi.Order)
                .Where(oi => oi.TicketType.EventId == eventId && oi.Order.Status == "paid")
                .SumAsync(oi => (int)oi.Quantity);

            // 3. Total Check-In per Event
            var totalCheckIns = await _context.CheckIns
                .Include(c => c.Ticket)
                .ThenInclude(t => t.OrderItem)
                .ThenInclude(oi => oi.TicketType)
                .Where(c => c.Status == "success" && 
                            c.Ticket.OrderItem.TicketType.EventId == eventId)
                .CountAsync();

            // 4. Total Refund per Event
            var totalRefunds = await _context.Refunds
                .Include(r => r.Order)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.TicketType)
                .Where(r => (r.Status == "approved" || r.Status == "success") && 
                            r.Order.OrderItems.Any(oi => oi.TicketType.EventId == eventId))
                .CountAsync();

            return new DashboardSummaryDto
            {
                TotalRevenue = totalRevenue,
                TotalTicketsSold = totalTicketsSold,
                TotalCheckIns = totalCheckIns,
                TotalRefunds = totalRefunds,
                TotalActiveEvents = 1
            };
        }
    }
}