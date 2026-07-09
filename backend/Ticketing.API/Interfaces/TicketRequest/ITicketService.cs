using System.Threading.Tasks;
using Ticketing.API.DTOs;

namespace Ticketing.API.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponseDto> IssueTicketAsync(IssueTicketRequestDto request);
        Task<TicketResponseDto?> GetTicketByIdAsync(long id); 
        Task<IEnumerable<TicketResponseDto>> GetTicketsByUserIdAsync(long userId);
    }
}