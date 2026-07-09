using System;

namespace Ticketing.API.DTOs
{
    public class EventResponse
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Description { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CategoryName { get; set; } = null!;
        public string VenueName { get; set; } = null!; 
    }
}