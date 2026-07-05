using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class OrganizationSettlement
{
    public long Id { get; set; }

    public Guid OrganizationId { get; set; }

    public Guid? EventId { get; set; }

    public decimal GrossAmount { get; set; }

    public decimal CommissionAmount { get; set; }

    public decimal NetAmount { get; set; }

    public DateTime PeriodStart { get; set; }

    public DateTime PeriodEnd { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
