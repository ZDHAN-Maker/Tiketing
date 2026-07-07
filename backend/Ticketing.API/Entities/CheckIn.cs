using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class CheckIn
    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        public long GateOfficerId { get; set; }
        public User GateOfficer { get; set; } = null!;
        public string? GateNumber { get; set; }
        public DateTime ScannedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "success";
    }
}