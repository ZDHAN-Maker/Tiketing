using System.Threading.Tasks;
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task<Ticket?> GetTicketByIdAsync(long id);
        Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(long userId);

        Task<Ticket?> GetTicketByCodeAsync(string ticketCode);
        Task UpdateAsync(Ticket ticket);
    }
}