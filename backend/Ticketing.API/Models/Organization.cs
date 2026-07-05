using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Organization
{
    public Guid Id { get; set; }

    public Guid OwnerUserId { get; set; }

    public string Name { get; set; } = null!;

    public string? LegalName { get; set; }

    public string? TaxId { get; set; }

    public string? BusinessType { get; set; }

    public string? LogoUrl { get; set; }

    public string? Description { get; set; }

    public decimal CommissionRatePercent { get; set; }

    public string? BankName { get; set; }

    public string? BankAccountHolder { get; set; }

    public string? BankAccountNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<DiscountVoucher> DiscountVouchers { get; set; } = new List<DiscountVoucher>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<OrganizationMember> OrganizationMembers { get; set; } = new List<OrganizationMember>();

    public virtual ICollection<OrganizationSettlement> OrganizationSettlements { get; set; } = new List<OrganizationSettlement>();

    public virtual User OwnerUser { get; set; } = null!;

    public virtual ICollection<PayoutRequest> PayoutRequests { get; set; } = new List<PayoutRequest>();

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
}
