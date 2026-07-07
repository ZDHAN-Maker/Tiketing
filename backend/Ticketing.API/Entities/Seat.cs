using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Seat
    {
        public long Id { get; set; }
        public long SeatMapId { get; set; }
        public SeatMap SeatMap { get; set; } = null!;
        public long TicketTypeId { get; set; }
        public TicketType TicketType { get; set; } = null!;
        public string SeatNumber { get; set; } = null!;
        public string Status { get; set; } = "available"; // available, booked, sold

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}