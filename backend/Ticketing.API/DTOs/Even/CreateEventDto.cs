using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketing.API.DTOs
{
    public class CreateEventDto
    {
        [Required]
        public long OrganizerId { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public long VenueId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }
        
        public string? PosterUrl { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [RegularExpression("^(draft|published)$", ErrorMessage = "Status must be either 'draft' or 'published'")]
        public string Status { get; set; } = "draft";
    }
}