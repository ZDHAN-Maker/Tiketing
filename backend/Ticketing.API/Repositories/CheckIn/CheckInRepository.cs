using System.Threading.Tasks;
using Ticketing.API.Data;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly TicketingDbContext _context;

        public CheckInRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CheckIn checkIn)
        {
            await _context.CheckIns.AddAsync(checkIn);
            await _context.SaveChangesAsync();
        }
    }
}