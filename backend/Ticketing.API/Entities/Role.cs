using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}