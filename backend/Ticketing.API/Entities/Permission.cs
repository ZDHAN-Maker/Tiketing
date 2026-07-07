using System;
using System.Collections.Generic;

namespace Ticketing.API.Entities
{
    public class Permission
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}