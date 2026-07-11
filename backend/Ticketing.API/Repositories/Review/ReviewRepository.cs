using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data; // Sesuaikan dengan namespace DbContext Anda
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly TicketingDbContext _context;

        public ReviewRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewsByEventIdAsync(long eventId)
        {
            return await _context.Reviews
                .Include(r => r.User) // Join ke tabel User untuk mengambil nama
                .Where(r => r.EventId == eventId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> HasUserReviewedEventAsync(long eventId, long userId)
        {
            return await _context.Reviews
                .AnyAsync(r => r.EventId == eventId && r.UserId == userId);
        }
    }
}