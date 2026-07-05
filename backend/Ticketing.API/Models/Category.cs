using System;
using System.Collections.Generic;

namespace Ticketing.API.Models;

public partial class Category
{
    public Guid Id { get; set; }

    public Guid? ParentCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? IconUrl { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }
}
