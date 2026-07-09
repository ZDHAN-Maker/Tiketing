using System;

namespace Ticketing.API.DTOs
{
    public class EventSearchRequest
    {
        public string? Keyword { get; set; }
        public long? CategoryId { get; set; }
        public string? Location { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}