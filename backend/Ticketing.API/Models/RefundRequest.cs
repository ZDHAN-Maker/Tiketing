using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class RefundRequest
{
    public long Id { get; set; }

    public long BookingId { get; set; }

    public long? PaymentId { get; set; }

    public Guid RequestedBy { get; set; }

    public string? Reason { get; set; }

    public decimal Amount { get; set; }

    public Guid? ProcessedBy { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Payment? Payment { get; set; }

    public virtual User? ProcessedByNavigation { get; set; }

    public virtual User RequestedByNavigation { get; set; } = null!;
}
