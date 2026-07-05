using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class TicketHold
{
    public long Id { get; set; }

    public Guid TierId { get; set; }

    public long? BookingId { get; set; }

    public Guid? SeatId { get; set; }

    public int Quantity { get; set; }

    public DateTime? HeldAt { get; set; }

    public DateTime ExpiresAt { get; set; }
    public HoldStatus Status { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual VenueSeat? Seat { get; set; }

    public virtual EventTicketTier Tier { get; set; } = null!;
}
