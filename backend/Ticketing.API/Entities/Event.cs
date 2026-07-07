using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Event
    {
        public long Id { get; set; }
        public long OrganizerId { get; set; }
        public long CategoryId { get; set; }
        public long VenueId { get; set; }
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Description { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = "draft";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public Organizer Organizer { get; set; } = null!;
        public EventCategory Category { get; set; } = null!;
        public Venue Venue { get; set; } = null!;

        // Relasi ke tipe tiket
        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
    }
}