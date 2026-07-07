using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long TicketTypeId { get; set; }
        public TicketType TicketType { get; set; } = null!;
        public uint Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}