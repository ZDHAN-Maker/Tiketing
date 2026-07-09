using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> CreateEventAsync(CreateEventDto dto)
        {
            var newEvent = new Event
            {
                OrganizerId = dto.OrganizerId,
                CategoryId = dto.CategoryId,
                VenueId = dto.VenueId,
                Title = dto.Title,
                Slug = GenerateSlug(dto.Title), // Logika bisnis: Generate Slug dari Title
                Description = dto.Description,
                PosterUrl = dto.PosterUrl,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Status = dto.Status,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _eventRepository.AddEventAsync(newEvent);
        }

        public async Task<Event?> GetEventByIdAsync(long id)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }

        // Helper untuk membuat URL-friendly slug
        private string GenerateSlug(string title)
        {
            string slug = title.ToLowerInvariant();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", ""); 
            slug = Regex.Replace(slug, @"\s+", "-").Trim('-'); 
            return $"{slug}-{Guid.NewGuid().ToString().Substring(0, 6)}"; // Unik ID
        }
    }
}