using System.Collections.Generic; // Untuk KeyNotFoundException
using System.Threading.Tasks;
using Ticketing.API.DTOs.Dashboard;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IEventRepository _eventRepository; // Tambahkan ini

        public DashboardService(IDashboardRepository dashboardRepository, IEventRepository eventRepository)
        {
            _dashboardRepository = dashboardRepository;
            _eventRepository = eventRepository; // Injeksi
        }

        public async Task<DashboardSummaryDto> GetDashboardStatisticsAsync(long? eventId = null)
        {
            if (eventId.HasValue)
            {
                // Gunakan repository untuk mengecek, bukan _context langsung
                var eventExists = await _eventRepository.ExistsAsync(eventId.Value);
                if (!eventExists)
                {
                    throw new KeyNotFoundException($"Event with ID {eventId} not found.");
                }
                return await _dashboardRepository.GetEventStatisticsAsync(eventId.Value);
            }

            return await _dashboardRepository.GetOverallStatisticsAsync();
        }
    }
}