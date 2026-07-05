using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class VenueSeat
{
    public Guid Id { get; set; }

    public Guid SectionId { get; set; }

    public string SeatRow { get; set; } = null!;

    public string SeatNumber { get; set; } = null!;

    public virtual VenueSection Section { get; set; } = null!;

    public virtual ICollection<TicketHold> TicketHolds { get; set; } = new List<TicketHold>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
