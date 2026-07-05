using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class InternalNote
{
    public long Id { get; set; }

    public Guid ReferenceId { get; set; }

    public string ReferenceType { get; set; } = null!;

    public Guid StaffId { get; set; }

    public string Note { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User Staff { get; set; } = null!;
}
