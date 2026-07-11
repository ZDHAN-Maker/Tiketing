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
        [Authorize] // Wajib memiliki token JWT yang valid
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Ekstrak UserId dari Token JWT (Biasanya disimpan di claim NameIdentifier)
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized(new { message = "Token tidak valid atau ID User tidak ditemukan." });
            }

            try
            {
                // Lempar request dan userId yang tervalidasi ke service
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
    }
}