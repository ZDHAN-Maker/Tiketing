using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ticketing.API.DTOs.Dashboard;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Hapus spasi pada "Super Admin" menjadi "SuperAdmin"
    [Authorize(Roles = "SuperAdmin,Organizer")] 
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        /// <summary>
        /// Mengambil ringkasan statistik. Jika eventId diberikan, mengambil statistik spesifik.
        /// </summary>
        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics([FromQuery] long? eventId)
        {
            try
            {
                var summary = await _dashboardService.GetDashboardStatisticsAsync(eventId);
                return Ok(new { Success = true, Data = summary });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }
    }
}