using System.Collections.Generic;
using System.Threading.Tasks;
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
        // Endpoint untuk Finance & CS melihat daftar pengajuan
        [HttpGet]
        public async Task<IActionResult> GetAllRefunds()
        {
            var refunds = await _refundService.GetAllRefundsAsync();
            return Ok(refunds);
        }

        // GET: api/refunds/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRefundById(long id)
        {
            var refund = await _refundService.GetRefundByIdAsync(id);
            if (refund == null) return NotFound(new { Message = "Refund request not found." });
            
            return Ok(refund);
        }

        // POST: api/refunds
        // Endpoint untuk Customer mengajukan refund
        [HttpPost]
        public async Task<IActionResult> CreateRefundRequest([FromBody] CreateRefundRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _refundService.CreateRefundRequestAsync(request);
            
            return CreatedAtAction(nameof(GetRefundById), new { id = result.Id }, result);
        }

        // PATCH: api/refunds/{id}/status
        // Endpoint untuk Finance mengupdate status (approved/rejected/processing)
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateRefundStatus(long id, [FromBody] UpdateRefundStatusDto request)
        {
            try
            {
                var result = await _refundService.ProcessRefundStatusAsync(id, request);
                return Ok(result);
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}