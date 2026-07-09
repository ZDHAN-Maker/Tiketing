using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface ITicketTypeRepository
    {
        Task<TicketType> AddAsync(TicketType ticketType);
        Task<TicketStock> AddStockAsync(TicketStock ticketStock);
        Task<IEnumerable<TicketType>> GetByEventIdAsync(long eventId);
        Task<TicketType?> GetByIdAsync(long id);
        Task SaveChangesAsync();
    }
}