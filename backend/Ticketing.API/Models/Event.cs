using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Event
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? VenueId { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public string? BannerUrl { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string EventTimezone { get; set; } = null!;

    public Guid? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public string? RejectionReason { get; set; }

    public bool IsPublished { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Category? Category { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<DiscountVoucher> DiscountVouchers { get; set; } = new List<DiscountVoucher>();

    public virtual ICollection<EventSession> EventSessions { get; set; } = new List<EventSession>();

    public virtual ICollection<EventTicketTier> EventTicketTiers { get; set; } = new List<EventTicketTier>();

    public virtual Organization Organization { get; set; } = null!;

    public virtual ICollection<OrganizationSettlement> OrganizationSettlements { get; set; } = new List<OrganizationSettlement>();

    public virtual Venue? Venue { get; set; }
}
