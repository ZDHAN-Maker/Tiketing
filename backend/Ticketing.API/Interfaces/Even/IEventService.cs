using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface IEventService
    {
        Task<Event> CreateEventAsync(CreateEventDto createEventDto);
        Task<Event?> GetEventByIdAsync(long id);
    }
}