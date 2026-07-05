using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Venue
{
    public Guid Id { get; set; }

    public Guid? OrganizationId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Province { get; set; }

    public string Country { get; set; } = null!;

    public string? PostalCode { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public int Capacity { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<VenueSection> VenueSections { get; set; } = new List<VenueSection>();
}
