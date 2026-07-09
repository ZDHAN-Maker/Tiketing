// DTOs/PaymentDtos.cs
using System.ComponentModel.DataAnnotations;
namespace Ticketing.API.DTOs
{
    public class CreatePaymentDto
    {
        [Required(ErrorMessage = "OrderId wajib diisi.")]
        [Range(1, long.MaxValue, ErrorMessage = "OrderId harus lebih besar dari 0.")]
        public long OrderId { get; set; }

        [Required(ErrorMessage = "PaymentMethodId wajib diisi.")]
        [Range(1, long.MaxValue, ErrorMessage = "PaymentMethodId harus lebih besar dari 0.")]
        public long PaymentMethodId { get; set; }

        [Required(ErrorMessage = "Amount wajib diisi.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount harus lebih besar dari 0.")]
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