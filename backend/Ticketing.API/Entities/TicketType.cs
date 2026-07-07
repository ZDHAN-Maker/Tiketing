using System;

namespace Ticketing.API.Entities
{
    public class TicketType
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int TotalQuota { get; set; }
        public DateTime StartSales { get; set; }
        public DateTime EndSales { get; set; }
        public bool IsNumberedSeat { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}