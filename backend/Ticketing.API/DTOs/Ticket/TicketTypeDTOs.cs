using System;

namespace Ticketing.API.DTOs
{
    public class CreateTicketTypeDto
    {
        public long EventId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int TotalQuota { get; set; }
        public DateTime StartSales { get; set; }
        public DateTime EndSales { get; set; }
        public bool IsNumberedSeat { get; set; }
    }

    public class TicketTypeResponseDto
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int TotalQuota { get; set; }
        public bool IsNumberedSeat { get; set; }
        public uint AvailableStock { get; set; } // Diambil dari TicketStock
    }
}