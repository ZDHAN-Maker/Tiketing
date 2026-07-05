using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class EventSession
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public string SessionName { get; set; } = null!;

    public DateTime SessionStart { get; set; }

    public DateTime SessionEnd { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<EventTicketTier> EventTicketTiers { get; set; } = new List<EventTicketTier>();
}
