namespace Ticketing.API.DTOs
{
    public class IssueTicketRequestDto
    {
        public long OrderId { get; set; }
        public long OrderItemId { get; set; }
        public long UserId { get; set; }
        public long? SeatId { get; set; }
    }
}