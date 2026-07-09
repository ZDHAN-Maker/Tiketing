using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> AddEventAsync(Event newEvent);
        Task<Event?> GetEventByIdAsync(long id);
        Task UpdateEventAsync(Event eventEntity);
        Task AddPublishLogAsync(EventPublishLog log);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Event>> SearchEventsAsync(EventSearchRequest searchParams);
    }
}