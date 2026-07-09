using System.Threading.Tasks;
using Ticketing.API.DTOs;

namespace Ticketing.API.Interfaces
{
    public interface ICheckInService
    {
        Task<CheckInResponseDto> ProcessCheckInAsync(CheckInRequestDto request, long gateOfficerId);
    }
}