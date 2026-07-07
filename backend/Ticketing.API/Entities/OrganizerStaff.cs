using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class OrganizerStaff
    {
        public long Id { get; set; }
        public long OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public string? Position { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}