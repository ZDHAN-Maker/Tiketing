using Ticketing.API.DTOs;

namespace Ticketing.API.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto?> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<PaymentResponseDto?> VerifyPaymentAsync(long paymentId, VerifyPaymentDto verifyPaymentDto);
        Task<PaymentResponseDto?> GetPaymentByOrderIdAsync(long orderId);
    }
}