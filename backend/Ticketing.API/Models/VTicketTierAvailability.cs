using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class VTicketTierAvailability
{
    public Guid? TierId { get; set; }

    public Guid? EventId { get; set; }

    public string? TierName { get; set; }

    public int? Quota { get; set; }

    public int? HeldCount { get; set; }

    public int? SoldCount { get; set; }

    public int? AvailableQuota { get; set; }
}
