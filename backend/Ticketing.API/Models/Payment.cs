using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Payment
{
    public long Id { get; set; }

    public Guid PublicId { get; set; }

    public long BookingId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentGateway { get; set; }

    public string? PaymentGatewayRef { get; set; }

    public string? IdempotencyKey { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;

    public DateTime? PaymentTime { get; set; }

    public string? RawGatewayResponse { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<RefundRequest> RefundRequests { get; set; } = new List<RefundRequest>();
}
