using System;

namespace Ticketing.API.DTOs
{
    public class CreateRefundRequestDto
    {
        public long OrderId { get; set; }
        public long UserId { get; set; } // Idealnya diambil dari Claim Token JWT (User terautentikasi)
        public decimal Amount { get; set; }
        public string Reason { get; set; } = null!;
    }

    public class UpdateRefundStatusDto
    {
        public string Status { get; set; } = null!; // "processing", "approved", "rejected"
        public long ProcessedBy { get; set; } // ID Finance/CS yang memproses
    }

    public class RefundResponseDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}