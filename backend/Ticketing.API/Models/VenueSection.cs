using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class VenueSection
{
    public Guid Id { get; set; }

    public Guid VenueId { get; set; }

    public string SectionName { get; set; } = null!;

    public int Capacity { get; set; }

    public int? SortOrder { get; set; }
    public VenueSectionType Type { get; set; }

    public virtual ICollection<EventTicketTier> EventTicketTiers { get; set; } = new List<EventTicketTier>();

    public virtual Venue Venue { get; set; } = null!;

    public virtual ICollection<VenueSeat> VenueSeats { get; set; } = new List<VenueSeat>();
}
