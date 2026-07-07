using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
   public class SeatMap
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; } = null!;
        public string? LayoutImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}