using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.Data; // Asumsi context ada di sini
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class RefundRepository : IRefundRepository
    {
        private readonly TicketingDbContext _context; 

        public RefundRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<Refund> AddAsync(Refund refund)
        {
            _context.Refunds.Add(refund);
            await _context.SaveChangesAsync();
            return refund;
        }

        public async Task<Refund?> GetByIdAsync(long id)
        {
            return await _context.Refunds
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Refund>> GetAllAsync()
        {
            return await _context.Refunds.ToListAsync();
        }

        public async Task UpdateAsync(Refund refund)
        {
            _context.Refunds.Update(refund);
            await _context.SaveChangesAsync();
        }
    }
}