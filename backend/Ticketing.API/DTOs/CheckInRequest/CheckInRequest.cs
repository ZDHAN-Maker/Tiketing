namespace Ticketing.API.DTOs
{
    public class CheckInRequestDto
    {
        public string TicketCode { get; set; } = string.Empty;
        public string? GateNumber { get; set; }
    }
}