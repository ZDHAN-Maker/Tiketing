using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public long PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public string? TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "pending"; // pending, success, failed, expired
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}