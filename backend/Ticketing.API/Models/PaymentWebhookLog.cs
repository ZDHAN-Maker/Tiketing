using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class PaymentWebhookLog
{
    public long Id { get; set; }

    public string PaymentGateway { get; set; } = null!;

    public string? EventType { get; set; }

    public string Payload { get; set; } = null!;

    public bool SignatureVerified { get; set; }

    public bool Processed { get; set; }

    public DateTime? ReceivedAt { get; set; }
}
