using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class OrganizationMember
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public Guid? InvitedBy { get; set; }

    public DateTime? JoinedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? InvitedByNavigation { get; set; }

    public virtual Organization Organization { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
