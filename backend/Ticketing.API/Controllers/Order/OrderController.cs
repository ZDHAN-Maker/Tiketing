using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/v1/orders
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _orderService.CreateOrderAsync(request);

            // Mengembalikan status 201 Created sesuai standar REST, beserta lokasi endpoint untuk mengambil detailnya
            return CreatedAtAction(nameof(GetOrderById), new { id = response.Id }, response);
        }

        // GET: api/v1/orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderById(long id)
        {
            // TODO: Implementasi logika untuk mengambil data order berdasarkan ID
            return Ok(new { Message = $"Mengambil data order dengan ID: {id}" });
        }
    }
}