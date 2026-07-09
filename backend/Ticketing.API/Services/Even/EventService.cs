using System;
using System.Collections.Generic;
using System.Linq;
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
                Slug = GenerateSlug(dto.Title),
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

        private string GenerateSlug(string title)
        {
            string slug = title.ToLowerInvariant();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", "-").Trim('-');
            return $"{slug}-{Guid.NewGuid().ToString().Substring(0, 6)}";
        }

        public async Task<bool> PublishEventAsync(long eventId, long organizerId, string? notes)
        {
            var eventEntity = await _eventRepository.GetEventByIdAsync(eventId);
            if (eventEntity == null)
            {
                throw new Exception("Event tidak ditemukan.");
            }

            eventEntity.Status = "published"; 
            eventEntity.UpdatedAt = DateTime.UtcNow;

            var publishLog = new EventPublishLog
            {
                EventId = eventId,
                PublishedBy = organizerId,
                Notes = notes,
                PublishedAt = DateTime.UtcNow
            };

            await _eventRepository.UpdateEventAsync(eventEntity);
            await _eventRepository.AddPublishLogAsync(publishLog);

            return await _eventRepository.SaveChangesAsync();
        }

        // KODE BARU TERGABUNG: Mapping hasil pencarian ke DTO
        public async Task<IEnumerable<EventResponse>> SearchEventsAsync(EventSearchRequest searchParams)
        {
            var events = await _eventRepository.SearchEventsAsync(searchParams);

            return events.Select(e => new EventResponse
            {
                Id = e.Id,
                Title = e.Title,
                Slug = e.Slug,
                Description = e.Description,
                PosterUrl = e.PosterUrl,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                CategoryName = e.Category.Name,
                // VenueName = e.Venue.Name // Sesuaikan dengan entity Venue
            });
        }
    }
}