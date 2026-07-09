using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketingDbContext _context;

        public TicketRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket?> GetTicketByIdAsync(long id)
        {
            return await _context.Tickets
                .Include(t => t.QrCodes) // Load data QR Code terkait
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(long userId)
        {
            return await _context.Tickets
                .Include(t => t.QrCodes)
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        // ==========================================
        // TAMBAHKAN DUA FUNGSI DI BAWAH INI UNTUK CHECK-IN
        // ==========================================

        public async Task<Ticket?> GetTicketByCodeAsync(string ticketCode)
        {
            // Mencari tiket berdasarkan string kode uniknya
            return await _context.Tickets
                .FirstOrDefaultAsync(t => t.TicketCode == ticketCode);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            // Memperbarui status tiket di database (misal dari 'valid' ke 'Checked In')
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}