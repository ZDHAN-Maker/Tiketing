using System.Threading.Tasks;
using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface ICheckInRepository
    {
        Task AddAsync(CheckIn checkIn);
    }
}