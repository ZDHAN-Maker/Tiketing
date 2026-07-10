using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; // Tambahan untuk proteksi Role
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundsController : ControllerBase
    {
        private readonly IRefundService _refundService;

        public RefundsController(IRefundService refundService)
        {
            _refundService = refundService;
        }

        // GET: api/refunds
        // Endpoint untuk SuperAdmin & EventOrganizer melihat daftar pengajuan
        [HttpGet]
        [Authorize(Roles = "SuperAdmin,EventOrganizer")]
        public async Task<IActionResult> GetAllRefunds()
        {
            var refunds = await _refundService.GetAllRefundsAsync();
            return Ok(refunds);
        }

        // GET: api/refunds/{id}
        // Endpoint untuk pihak internal atau Customer terkait melihat detail refund
        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin,EventOrganizer,Customer")]
        public async Task<IActionResult> GetRefundById(long id)
        {
            var refund = await _refundService.GetRefundByIdAsync(id);
            if (refund == null) return NotFound(new { Message = "Refund request not found." });
            
            return Ok(refund);
        }

        // POST: api/refunds
        // Endpoint khusus Customer untuk mengajukan refund
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateRefundRequest([FromBody] CreateRefundRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _refundService.CreateRefundRequestAsync(request);
                return CreatedAtAction(nameof(GetRefundById), new { id = result.Id }, result);
            }
            catch (KeyNotFoundException ex)
            {
                // Mencegah error 500 akibat foreign key constraint jika OrderId/UserId ngawur
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PATCH: api/refunds/{id}/status
        // Endpoint untuk SuperAdmin & EventOrganizer mengupdate status (approved/rejected)
        [HttpPatch("{id}/status")]
        [Authorize(Roles = "SuperAdmin,EventOrganizer")]
        public async Task<IActionResult> UpdateRefundStatus(long id, [FromBody] UpdateRefundStatusDto request)
        {
            try
            {
                var result = await _refundService.ProcessRefundStatusAsync(id, request);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}