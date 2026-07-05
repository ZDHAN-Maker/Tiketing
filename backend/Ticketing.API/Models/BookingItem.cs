using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class BookingItem
{
    public long Id { get; set; }

    public long BookingId { get; set; }

    public Guid TierId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual EventTicketTier Tier { get; set; } = null!;
}
