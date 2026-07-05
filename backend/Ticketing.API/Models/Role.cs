using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public RoleScope Scope { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<OrganizationMember> OrganizationMembers { get; set; } = new List<OrganizationMember>();

    public virtual ICollection<UserPlatformRole> UserPlatformRoles { get; set; } = new List<UserPlatformRole>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
