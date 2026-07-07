using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public string OrderNumber { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "pending"; // pending, paid, cancelled, refunded
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Refund> Refunds { get; set; } = new List<Refund>();
    }
}