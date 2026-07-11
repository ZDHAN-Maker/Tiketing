using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetReviewsByEventIdAsync(long eventId);
        Task<bool> HasUserReviewedEventAsync(long eventId, long userId);
    }
}