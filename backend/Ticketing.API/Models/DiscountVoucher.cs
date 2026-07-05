using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class DiscountVoucher
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public Guid? EventId { get; set; }

    public string Code { get; set; } = null!;

    public decimal DiscountValue { get; set; }

    public int MaxUsage { get; set; }

    public int UsedCount { get; set; }

    public decimal? MinTransactionAmount { get; set; }
    public DiscountType Type { get; set; }
    public DateTime ValidFrom { get; set; }

    public DateTime ValidUntil { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Event? Event { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
