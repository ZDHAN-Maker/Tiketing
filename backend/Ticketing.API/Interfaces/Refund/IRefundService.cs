using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.DTOs;

namespace Ticketing.API.Interfaces
{
    public interface IRefundService
    {
        Task<RefundResponseDto> CreateRefundRequestAsync(CreateRefundRequestDto request);
        Task<RefundResponseDto?> GetRefundByIdAsync(long id);
        Task<IEnumerable<RefundResponseDto>> GetAllRefundsAsync();
        Task<RefundResponseDto> ProcessRefundStatusAsync(long id, UpdateRefundStatusDto request);
    }
}