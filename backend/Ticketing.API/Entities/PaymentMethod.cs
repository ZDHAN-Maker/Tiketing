using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class PaymentMethod
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!; // bank_transfer, ewallet, credit_card, retail
        public bool IsActive { get; set; } = true;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}