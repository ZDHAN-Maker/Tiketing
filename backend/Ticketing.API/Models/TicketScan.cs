using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class TicketScan
{
    public long Id { get; set; }

    public long TicketId { get; set; }

    public Guid ScannedBy { get; set; }

    public DateTime? ScanTime { get; set; }

    public string? LocationScanned { get; set; }

    public string? DeviceInfo { get; set; }

    public virtual User ScannedByNavigation { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
