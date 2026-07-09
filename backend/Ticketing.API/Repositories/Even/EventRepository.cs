
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data; // Asumsikan ApplicationDbContext ada di sini
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketingDbContext _context;

        public EventRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<Event> AddEventAsync(Event newEvent)
        {
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<Event?> GetEventByIdAsync(long id)
        {
            return await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Venue)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}