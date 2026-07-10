using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface IRefundRepository
    {
        Task<Refund> AddAsync(Refund refund);
        Task<Refund?> GetByIdAsync(long id);
        Task<IEnumerable<Refund>> GetAllAsync();
        Task UpdateAsync(Refund refund);
    }
}