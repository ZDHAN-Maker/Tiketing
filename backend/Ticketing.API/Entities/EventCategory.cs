using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class EventCategory
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}