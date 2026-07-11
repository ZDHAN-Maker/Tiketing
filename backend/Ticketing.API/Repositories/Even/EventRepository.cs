using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data;
using Ticketing.API.DTOs;
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
        public async Task<bool> ExistsAsync(long eventId)
        {
            // Cek keberadaan event dengan performa tinggi
            return await _context.Events.AnyAsync(e => e.Id == eventId);
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

        // KODE BARU TERGABUNG: Implementasi pencarian event
        public async Task<IEnumerable<Event>> SearchEventsAsync(EventSearchRequest searchParams)
        {
            var query = _context.Events
                .Include(e => e.Category)
                .Include(e => e.Venue)
                .Where(e => e.DeletedAt == null && e.Status == "published")
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchParams.Keyword))
            {
                var keyword = searchParams.Keyword.ToLower();
                query = query.Where(e =>
                    e.Title.ToLower().Contains(keyword) ||
                    (e.Description != null && e.Description.ToLower().Contains(keyword)));
            }

            if (searchParams.CategoryId.HasValue)
            {
                query = query.Where(e => e.CategoryId == searchParams.CategoryId.Value);
            }

            if (searchParams.StartDate.HasValue)
            {
                query = query.Where(e => e.StartTime >= searchParams.StartDate.Value);
            }

            if (searchParams.EndDate.HasValue)
            {
                query = query.Where(e => e.StartTime <= searchParams.EndDate.Value);
            }

            // Uncomment & sesuaikan jika Venue memiliki properti Name
            /*
            if (!string.IsNullOrWhiteSpace(searchParams.Location))
            {
                var location = searchParams.Location.ToLower();
                query = query.Where(e => e.Venue.Name.ToLower().Contains(location));
            }
            */

            return await query.OrderBy(e => e.StartTime).ToListAsync();
        }
    }
}