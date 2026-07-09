using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto createEventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Aturan bisnis tambahan, misal EndTime harus setelah StartTime
            if (createEventDto.EndTime <= createEventDto.StartTime)
            {
                return BadRequest(new { message = "EndTime must be greater than StartTime." });
            }

            var createdEvent = await _eventService.CreateEventAsync(createEventDto);

            // Mengikuti kaidah RESTful, mengembalikan 201 Created beserta data
            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(long id)
        {
            var eventData = await _eventService.GetEventByIdAsync(id);
            if (eventData == null)
            {
                return NotFound(new { message = "Event not found" });
            }

            return Ok(eventData);
        }
    }
}