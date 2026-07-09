// Repositories/PaymentRepository.cs
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Entities;
using Ticketing.API.Data;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly TicketingDbContext _context; // Ganti dengan class DbContext spesifik Anda jika ada

        public PaymentRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<Payment?> GetByIdAsync(long id)
        {
            return await _context.Set<Payment>()
                .Include(p => p.PaymentMethod)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment?> GetByOrderIdAsync(long orderId)
        {
            return await _context.Set<Payment>()
                .Include(p => p.PaymentMethod)
                .FirstOrDefaultAsync(p => p.OrderId == orderId);
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Set<Payment>().AddAsync(payment);
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Set<Payment>().Update(payment);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}