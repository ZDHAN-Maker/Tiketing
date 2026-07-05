using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Booking
{
    public long Id { get; set; }

    public Guid PublicId { get; set; }

    public string BookingNumber { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public BookingStatus Status { get; set; }
    public Guid EventId { get; set; }

    public Guid? VoucherId { get; set; }

    public decimal SubtotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? SlaPaymentDueDate { get; set; }

    public DateTime? PaidAt { get; set; }

    public DateTime? CancelledAt { get; set; }

    public string? CancellationReason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<BookingItem> BookingItems { get; set; } = new List<BookingItem>();

    public virtual User Customer { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<RefundRequest> RefundRequests { get; set; } = new List<RefundRequest>();

    public virtual ICollection<TicketHold> TicketHolds { get; set; } = new List<TicketHold>();

    public virtual DiscountVoucher? Voucher { get; set; }
}
