// Services/PaymentService.cs
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentResponseDto?> CreatePaymentAsync(CreatePaymentDto dto)
        {
            // Skenario: Customer memilih metode pembayaran dan membuat transaksi
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                PaymentMethodId = dto.PaymentMethodId,
                Amount = dto.Amount,
                Status = "pending" // Default awal sesuai property entitas
            };

            await _paymentRepository.AddAsync(payment);
            var success = await _paymentRepository.SaveChangesAsync();

            if (!success) return null;

            var savedPayment = await _paymentRepository.GetByIdAsync(payment.Id);
            return MapToResponseDto(savedPayment ?? payment);
        }

        public async Task<PaymentResponseDto?> VerifyPaymentAsync(long paymentId, VerifyPaymentDto dto)
        {
            // Skenario: Verifikasi Otomatis (Webhook) atau Manual (oleh tim Finance)
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null) return null;

            if (dto.Status.Equals("success", StringComparison.OrdinalIgnoreCase))
            {
                payment.Status = "success"; // Sesuai comment opsi Anda, ini merepresentasikan status 'Paid'
                payment.PaidAt = DateTime.UtcNow;
            }
            else
            {
                payment.Status = "failed";
            }

            payment.TransactionId = dto.TransactionId;

            await _paymentRepository.UpdateAsync(payment);
            await _paymentRepository.SaveChangesAsync();

            return MapToResponseDto(payment);
        }

        public async Task<PaymentResponseDto?> GetPaymentByOrderIdAsync(long orderId)
        {
            var payment = await _paymentRepository.GetByOrderIdAsync(orderId);
            if (payment == null) return null;
            return MapToResponseDto(payment);
        }

        // Helper untuk mapping Entity ke DTO
        private static PaymentResponseDto MapToResponseDto(Payment payment)
        {
            return new PaymentResponseDto
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                PaymentMethodName = payment.PaymentMethod?.Name ?? "Unknown Method",
                TransactionId = payment.TransactionId,
                Amount = payment.Amount,
                Status = payment.Status,
                PaidAt = payment.PaidAt,
                CreatedAt = payment.CreatedAt
            };
        }
    }
}