using System.Threading.Tasks;
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
    }

}