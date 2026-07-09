using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Pastikan hanya Gate Officer yang memiliki token yang bisa mengakses
    public class CheckInController : ControllerBase
    {
        private readonly ICheckInService _checkInService;

        public CheckInController(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        [HttpPost("scan")]
        public async Task<IActionResult> ScanTicket([FromBody] CheckInRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Mencari dengan berbagai kemungkinan nama claim yang di-generate oleh AuthController
            var officerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? User.FindFirst("nameid")?.Value
                              ?? User.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(officerIdClaim) || !long.TryParse(officerIdClaim, out long gateOfficerId))
            {
                return Unauthorized(new { Message = "Sesi tidak valid atau pengguna tidak teridentifikasi." });
            }

            var result = await _checkInService.ProcessCheckInAsync(request, gateOfficerId);

            if (!result.IsSuccess)
            {
                // Mengembalikan 400 Bad Request jika tiket tidak valid atau sudah digunakan
                return BadRequest(result);
            }

            // Mengembalikan 200 OK dengan detail check-in jika berhasil
            return Ok(result);
        }
    }
}