using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class ScheduledJobRun
{
    public long Id { get; set; }

    public string JobName { get; set; } = null!;

    public DateTime? StartedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public int? RowsAffected { get; set; }

    public string? ErrorMessage { get; set; }
}
