using System; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/events")]
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

            if (createEventDto.EndTime <= createEventDto.StartTime)
            {
                return BadRequest(new { message = "EndTime must be greater than StartTime." });
            }

            var createdEvent = await _eventService.CreateEventAsync(createEventDto);

            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }

        // Route-nya akan menjadi: GET /api/events/search?Keyword=xyz&CategoryId=1
        [HttpGet("search")]
        public async Task<IActionResult> SearchEvents([FromQuery] EventSearchRequest searchParams)
        {
            var result = await _eventService.SearchEventsAsync(searchParams);
            
            return Ok(new 
            {
                Message = "Events retrieved successfully",
                Data = result
            });
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

        [HttpPost("{id}/publish")]
        public async Task<IActionResult> PublishEvent(long id, [FromBody] PublishEventRequestDto request)
        {
            try
            {
                long currentOrganizerId = 1; 

                var result = await _eventService.PublishEventAsync(id, currentOrganizerId, request.Notes);

                if (result)
                {
                    return Ok(new
                    {
                        Message = "Event berhasil dipublikasikan dan sekarang dapat dilihat oleh customer."
                    });
                }

                return BadRequest(new { Message = "Gagal mempublikasikan event." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}