using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.API.Data;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly TicketingDbContext _context;

        public TicketTypeRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<TicketType> AddAsync(TicketType ticketType)
        {
            await _context.TicketTypes.AddAsync(ticketType);
            return ticketType;
        }

        public async Task<TicketStock> AddStockAsync(TicketStock ticketStock)
        {
            await _context.TicketStocks.AddAsync(ticketStock);
            return ticketStock;
        }

        public async Task<IEnumerable<TicketType>> GetByEventIdAsync(long eventId)
        {
            return await _context.TicketTypes
                .Where(t => t.EventId == eventId)
                .ToListAsync();
        }

        public async Task<TicketType?> GetByIdAsync(long id)
        {
            return await _context.TicketTypes.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}