using System;
using System.Collections.Generic;
using System.Net;

namespace Ticketing.API.Models;

public partial class AuditLogsDefault
{
    public long Id { get; set; }

    public Guid? UserId { get; set; }

    public string Action { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public Guid? RecordId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public IPAddress? IpAddress { get; set; }

    public DateTime Timestamp { get; set; }
}
