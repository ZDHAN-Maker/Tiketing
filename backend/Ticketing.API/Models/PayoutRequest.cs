using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class PayoutRequest
{
    public long Id { get; set; }

    public Guid PublicId { get; set; }

    public Guid OrganizationId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? RequestedAt { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public Guid? ProcessedBy { get; set; }

    public string? BankReference { get; set; }
    public PayoutStatus Status { get; set; }

    public string? Notes { get; set; }

    public virtual Organization Organization { get; set; } = null!;

    public virtual User? ProcessedByNavigation { get; set; }
}
