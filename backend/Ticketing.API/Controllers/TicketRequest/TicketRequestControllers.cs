using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Menerbitkan e-ticket baru setelah pembayaran divalidasi.
        /// Endpoint: POST /api/v1/tickets
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> IssueTicket([FromBody] IssueTicketRequestDto request)
        {
            if (request == null || request.OrderId <= 0 || request.UserId <= 0)
            {
                return BadRequest(new { Message = "Payload data tidak valid atau tidak lengkap." });
            }

            var ticketResponse = await _ticketService.IssueTicketAsync(request);

            // Memicu header rute 'GetTicketById' dengan parameter ID tiket yang baru dibuat
            return CreatedAtAction(nameof(GetTicketById), new { id = ticketResponse.Id }, ticketResponse);
        }

        /// <summary>
        /// Mendapatkan detail e-ticket berdasarkan ID Tiket.
        /// Endpoint: GET /api/v1/tickets/{id}
        /// </summary>
        [HttpGet("{id}", Name = "GetTicketById")]
        public async Task<IActionResult> GetTicketById(long id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            
            if (ticket == null)
            {
                return NotFound(new { Message = $"E-Ticket dengan ID {id} tidak ditemukan." });
            }

            return Ok(ticket);
        }

        /// <summary>
        /// Mendapatkan seluruh daftar e-ticket milik user tertentu.
        /// Endpoint: GET /api/v1/tickets/user/{userId}
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTicketsByUserId(long userId)
        {
            var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);
            return Ok(tickets);
        }
    }
}