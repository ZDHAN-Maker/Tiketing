using System;

namespace Ticketing.API.DTOs
{
    public class TicketResponseDto
    {
        public long Id { get; set; }
        public required string TicketCode { get; set; }
        public required string Status { get; set; }
        public required string QrHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}