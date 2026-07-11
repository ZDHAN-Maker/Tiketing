using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.DTOs.Reviews;

namespace Ticketing.API.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewResponseDto> CreateReviewAsync(CreateReviewDto request, long userId);
        Task<IEnumerable<ReviewResponseDto>> GetReviewsByEventIdAsync(long eventId);
    }
}