using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.API.DTOs.Reviews;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewResponseDto> CreateReviewAsync(CreateReviewDto request, long userId)
        {
            // Gunakan parameter userId untuk validasi
            var hasReviewed = await _reviewRepository.HasUserReviewedEventAsync(request.EventId, userId);
            if (hasReviewed)
            {
                throw new InvalidOperationException("User sudah memberikan ulasan untuk event ini.");
            }

            var reviewEntity = new Review
            {
                EventId = request.EventId,
                UserId = userId, // Masukkan userId dari token ke entitas database
                Rating = request.Rating,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow
            };

            var savedReview = await _reviewRepository.AddReviewAsync(reviewEntity);

            return new ReviewResponseDto
            {
                Id = savedReview.Id,
                EventId = savedReview.EventId,
                UserId = savedReview.UserId,
                Rating = savedReview.Rating,
                Comment = savedReview.Comment,
                CreatedAt = savedReview.CreatedAt
            };
        }

        public async Task<IEnumerable<ReviewResponseDto>> GetReviewsByEventIdAsync(long eventId)
        {
            var reviews = await _reviewRepository.GetReviewsByEventIdAsync(eventId);

            return reviews.Select(r => new ReviewResponseDto
            {
                Id = r.Id,
                EventId = r.EventId,
                UserId = r.UserId,
                UserName = r.User?.Name ?? "Anonymous", // Asumsi entity User memiliki properti 'Name'
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            });
        }
    }
}