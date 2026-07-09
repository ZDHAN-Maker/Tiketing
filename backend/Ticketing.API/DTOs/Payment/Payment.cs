// DTOs/PaymentDtos.cs
namespace Ticketing.API.DTOs
{
    public class CreatePaymentDto
    {
        public long OrderId { get; set; }
        public long PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
    }

    public class VerifyPaymentDto
    {
        public string? TransactionId { get; set; }
        // Status bisa diisi "success" (untuk Paid) atau "failed"
        public string Status { get; set; } = null!; 
    }

    public class PaymentResponseDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string PaymentMethodName { get; set; } = null!;
        public string? TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}