using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Ticket
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; } = null!;
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public long? SeatId { get; set; }
        public Seat? Seat { get; set; }
        public string TicketCode { get; set; } = null!;
        public string Status { get; set; } = "valid"; // valid, used, cancelled, refunded
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<QrCode> QrCodes { get; set; } = new List<QrCode>();
        public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
    }

}