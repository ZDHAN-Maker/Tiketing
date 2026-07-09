using System.Threading.Tasks;
using Ticketing.API.Data; 
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketingDbContext _context; // Sesuaikan dengan nama DbContext Anda

        public OrderRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            
            return order;
        }
    }
}