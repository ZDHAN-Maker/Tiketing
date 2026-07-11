using System;

namespace Ticketing.API.DTOs.Reviews
{
    public class ReviewResponseDto
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public byte Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}