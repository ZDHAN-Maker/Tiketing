using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }

        // Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}