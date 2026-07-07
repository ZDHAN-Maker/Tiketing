using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Venue
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public uint? Capacity { get; set; }
        public string? GoogleMapsUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}