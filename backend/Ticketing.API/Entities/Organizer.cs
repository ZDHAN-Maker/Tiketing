using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Organizer
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrganizerStaff> Staffs { get; set; } = new List<OrganizerStaff>();
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}