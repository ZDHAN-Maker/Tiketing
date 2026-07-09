using System;

namespace Ticketing.API.DTOs
{
    public class CheckInResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? TicketCode { get; set; }
        public DateTime? ScannedAt { get; set; }
    }
}