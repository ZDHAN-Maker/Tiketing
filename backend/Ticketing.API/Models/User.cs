using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime? EmailVerifiedAt { get; set; }

    public DateTime? PhoneVerifiedAt { get; set; }

    public string? LanguagePreference { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ActivityTimelines202607> ActivityTimelines202607s { get; set; } = new List<ActivityTimelines202607>();

    public virtual ICollection<ActivityTimelinesDefault> ActivityTimelinesDefaults { get; set; } = new List<ActivityTimelinesDefault>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Event> EventApprovedByNavigations { get; set; } = new List<Event>();

    public virtual ICollection<Event> EventCreatedByNavigations { get; set; } = new List<Event>();

    public virtual ICollection<ExternalLogin> ExternalLogins { get; set; } = new List<ExternalLogin>();

    public virtual ICollection<InternalNote> InternalNotes { get; set; } = new List<InternalNote>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<OrganizationMember> OrganizationMemberInvitedByNavigations { get; set; } = new List<OrganizationMember>();

    public virtual ICollection<OrganizationMember> OrganizationMemberUsers { get; set; } = new List<OrganizationMember>();

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<PayoutRequest> PayoutRequests { get; set; } = new List<PayoutRequest>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<RefundRequest> RefundRequestProcessedByNavigations { get; set; } = new List<RefundRequest>();

    public virtual ICollection<RefundRequest> RefundRequestRequestedByNavigations { get; set; } = new List<RefundRequest>();

    public virtual ICollection<SystemSetting> SystemSettings { get; set; } = new List<SystemSetting>();

    public virtual ICollection<TicketScan> TicketScans { get; set; } = new List<TicketScan>();

    public virtual ICollection<UserPlatformRole> UserPlatformRoleAssignedByNavigations { get; set; } = new List<UserPlatformRole>();

    public virtual ICollection<UserPlatformRole> UserPlatformRoleUsers { get; set; } = new List<UserPlatformRole>();
}
