using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Ticket
{
    public long Id { get; set; }

    public Guid PublicId { get; set; }

    public long BookingItemId { get; set; }

    public Guid TierId { get; set; }

    public Guid? SeatId { get; set; }

    public TicketStatus Status { get; set; }
    public string TicketNumber { get; set; } = null!;

    public string QrCodePayload { get; set; } = null!;

    public string? PdfAttachmentUrl { get; set; }

    public DateTime? IssuedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual BookingItem BookingItem { get; set; } = null!;

    public virtual VenueSeat? Seat { get; set; }

    public virtual ICollection<TicketScan> TicketScans { get; set; } = new List<TicketScan>();

    public virtual EventTicketTier Tier { get; set; } = null!;
}
