using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class ActivityTimelinesDefault
{
    public long Id { get; set; }

    public Guid ReferenceId { get; set; }

    public string ReferenceType { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string? Description { get; set; }

    public Guid? ActorId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual User? Actor { get; set; }
}
