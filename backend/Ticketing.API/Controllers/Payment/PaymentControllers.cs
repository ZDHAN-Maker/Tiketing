// Controllers/PaymentsController.cs
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")] 
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // POST: api/v1/payments
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDto dto)
        {
            var result = await _paymentService.CreatePaymentAsync(dto);
            if (result == null) return BadRequest("Gagal memproses data pembayaran.");

            return CreatedAtAction(nameof(GetPaymentByOrder), new { orderId = result.OrderId }, result);
        }

        // POST: api/v1/payments/{id}/verify
        [HttpPost("{id}/verify")]
        public async Task<IActionResult> VerifyPayment(long id, [FromBody] VerifyPaymentDto dto)
        {
            var result = await _paymentService.VerifyPaymentAsync(id, dto);
            if (result == null) return NotFound($"Data pembayaran dengan ID {id} tidak ditemukan.");

            return Ok(result);
        }

        // GET: api/v1/payments/order/{orderId}
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetPaymentByOrder(long orderId)
        {
            var result = await _paymentService.GetPaymentByOrderIdAsync(orderId);
            if (result == null) return NotFound($"Pembayaran untuk Order ID {orderId} tidak ditemukan.");

            return Ok(result);
        }
    }
}