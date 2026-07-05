using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class EventTicketTier
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public Guid? SessionId { get; set; }

    public Guid? SectionId { get; set; }

    public string TierName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Currency { get; set; } = null!;

    public int Quota { get; set; }

    public int HeldCount { get; set; }

    public int SoldCount { get; set; }

    public int MinPurchasePerTxn { get; set; }

    public int MaxPurchasePerTxn { get; set; }

    public DateTime? SalesStartAt { get; set; }

    public DateTime? SalesEndAt { get; set; }

    public int Version { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<BookingItem> BookingItems { get; set; } = new List<BookingItem>();

    public virtual Event Event { get; set; } = null!;

    public virtual VenueSection? Section { get; set; }

    public virtual EventSession? Session { get; set; }

    public virtual ICollection<TicketHold> TicketHolds { get; set; } = new List<TicketHold>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
