using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Review
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; } = null!;
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public byte Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}