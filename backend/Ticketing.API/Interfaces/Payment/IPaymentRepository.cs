// Interfaces/IPaymentRepository.cs
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(long id);
        Task<Payment?> GetByOrderIdAsync(long orderId);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task<bool> SaveChangesAsync();
    }
}