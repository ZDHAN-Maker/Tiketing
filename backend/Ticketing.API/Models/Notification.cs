using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Notification
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public string TemplateCode { get; set; } = null!;

    public string? Payload { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
