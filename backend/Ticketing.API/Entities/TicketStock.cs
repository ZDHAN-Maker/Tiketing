using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class TicketStock
    {
        public long Id { get; set; }
        public long TicketTypeId { get; set; }
        public TicketType TicketType { get; set; } = null!;
        public uint AvailableStock { get; set; }
        public uint BookedStock { get; set; } = 0;
        public uint SoldStock { get; set; } = 0;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}