using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Permission
{
    public Guid Id { get; set; }

    public string PermissionCode { get; set; } = null!;

    public string Module { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
