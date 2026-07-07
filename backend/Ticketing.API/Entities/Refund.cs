using System;

namespace Ticketing.API.Entities
{
    public class Refund
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = null!;
        public string Status { get; set; } = "requested"; // requested, processing, approved, rejected
        public long? ProcessedBy { get; set; }
        public User? Processor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}