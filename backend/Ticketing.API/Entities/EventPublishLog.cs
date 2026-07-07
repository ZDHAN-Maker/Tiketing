using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class EventPublishLog
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; } = null!;
        public long PublishedBy { get; set; }
        public User Publisher { get; set; } = null!;
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}