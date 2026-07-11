using System.Threading.Tasks;
using Ticketing.API.DTOs.Dashboard;

namespace Ticketing.API.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardSummaryDto> GetOverallStatisticsAsync();
        Task<DashboardSummaryDto> GetEventStatisticsAsync(long eventId);
    }
}