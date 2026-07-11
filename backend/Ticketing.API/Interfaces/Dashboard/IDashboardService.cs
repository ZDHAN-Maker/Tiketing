using System.Threading.Tasks;
using Ticketing.API.DTOs.Dashboard;

namespace Ticketing.API.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetDashboardStatisticsAsync(long? eventId = null);
    }
}