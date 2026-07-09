using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/events/{eventId}/ticket-types")]
    public class TicketTypesController : ControllerBase
    {
        private readonly ITicketTypeService _service;

        public TicketTypesController(ITicketTypeService service)
        {
            _service = service;
        }

        // POST: api/events/5/ticket-types
        [HttpPost]
        public async Task<IActionResult> CreateTicketType(long eventId, [FromBody] CreateTicketTypeDto request)
        {
            if (eventId != request.EventId)
            {
                return BadRequest("Event ID pada URL tidak cocok dengan body request.");
            }

            var result = await _service.CreateTicketTypeAsync(request);
            
            // RESTful standard: Kembalikan 201 Created
            return Created($"/api/events/{eventId}/ticket-types/{result.Id}", result);
        }

        // GET: api/events/5/ticket-types
        [HttpGet]
        public async Task<IActionResult> GetTicketTypes(long eventId)
        {
            var results = await _service.GetTicketTypesByEventAsync(eventId);
            return Ok(results);
        }
    }
}