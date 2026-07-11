using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.DTOs.Reviews;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // POST: api/reviews
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Ambil literal "nameid" sesuai setting MapInboundClaims = false
            var userIdClaim = User.FindFirst("nameid")?.Value ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized(new { message = "Token tidak valid atau ID User tidak ditemukan." });
            }

            try
            {
                var response = await _reviewService.CreateReviewAsync(request, userId);
                return StatusCode(201, new { message = "Review berhasil ditambahkan", data = response });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Terjadi kesalahan pada server." });
            }
        }

        // GET: api/events/{eventId}/reviews
        // Tanda '/' di awal route sangat penting untuk keluar dari prefix "api/reviews"
        [HttpGet("/api/events/{eventId}/reviews")]
        [AllowAnonymous] // Karena public, siapa saja boleh melihat review tanpa perlu token
        public async Task<IActionResult> GetEventReviews(long eventId)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsByEventIdAsync(eventId);
                
                // Akan mengembalikan 200 OK dengan format: { "data": [ ... ] }
                // Jika tidak ada ulasan, akan mengembalikan 200 OK: { "data": [] }
                return Ok(new { data = reviews });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Terjadi kesalahan pada server." });
            }
        }
    }
}