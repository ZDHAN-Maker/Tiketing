
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data;
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
        public Task UpdateEventAsync(Event eventEntity)
        {
            _context.Events.Update(eventEntity);
            return Task.CompletedTask;
        }

        public async Task AddPublishLogAsync(EventPublishLog log)
        {
            await _context.EventPublishLogs.AddAsync(log);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}