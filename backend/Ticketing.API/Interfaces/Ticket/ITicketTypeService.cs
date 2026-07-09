using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.DTOs;

namespace Ticketing.API.Interfaces
{
    public interface ITicketTypeService
    {
        Task<TicketTypeResponseDto> CreateTicketTypeAsync(CreateTicketTypeDto dto);
        Task<IEnumerable<TicketTypeResponseDto>> GetTicketTypesByEventAsync(long eventId);
    }
}