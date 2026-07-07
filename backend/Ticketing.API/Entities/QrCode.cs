using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class QrCode
    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        public string QrHash { get; set; } = null!;
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }

}