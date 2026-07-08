using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ticketing.API.DTOs;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerService _organizerService;

        public OrganizerController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        // GET: api/Organizer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _organizerService.GetAllOrganizersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/Organizer/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _organizerService.GetOrganizerByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { Message = "Organizer tidak ditemukan." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // POST: api/Organizer
        // PERBAIKAN: Menambahkan EventOrganizer agar Budi bisa membuat organizer baru
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,User,EventOrganizer")]
        public async Task<IActionResult> Create([FromBody] CreateOrganizerDto dto)
        {
            try
            {
                var result = await _organizerService.CreateOrganizerAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/Organizer/{id}
        // PERBAIKAN: Menambahkan SuperAdmin agar Admin Besar juga bisa update data profil
        [HttpPut("{id:long}")]
        [Authorize(Roles = "SuperAdmin,EventOrganizer")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateOrganizerDto dto)
        {
            try
            {
                var updated = await _organizerService.UpdateOrganizerAsync(id, dto);
                if (!updated)
                {
                    return NotFound(new { Message = "Organizer tidak ditemukan." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PATCH: api/Organizer/{id}/verify
        [HttpPatch("{id:long}/verify")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Verify(long id, [FromBody] VerifyOrganizerDto dto)
        {
            try
            {
                var verified = await _organizerService.VerifyOrganizerAsync(id, dto.IsVerified);
                if (!verified)
                {
                    return NotFound(new { Message = "Organizer tidak ditemukan." });
                }
                return Ok(new { Message = "Status verifikasi berhasil diperbarui." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/Organizer/{id}/staffs
        [HttpGet("{id:long}/staffs")]
        [Authorize(Roles = "SuperAdmin,EventOrganizer")]
        public async Task<IActionResult> GetStaffs(long id)
        {
            try
            {
                var result = await _organizerService.GetStaffsByOrganizerIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // POST: api/Organizer/{id}/staffs
        [HttpPost("{id:long}/staffs")]
        [Authorize(Roles = "SuperAdmin,EventOrganizer")]
        public async Task<IActionResult> AddStaff(long id, [FromBody] AddStaffDto dto)
        {
            try
            {
                var result = await _organizerService.AddStaffAsync(id, dto);
                if (result == null)
                {
                    return BadRequest(new { Message = "Gagal menambahkan staff. Pastikan Organizer ada atau User belum terdaftar sebagai staff." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // DELETE: api/Organizer/{id}/staffs/{staffId}
        [HttpDelete("{id:long}/staffs/{staffId:long}")]
        [Authorize(Roles = "SuperAdmin,EventOrganizer")]
        public async Task<IActionResult> RemoveStaff(long id, long staffId)
        {
            try
            {
                var removed = await _organizerService.RemoveStaffAsync(id, staffId);
                if (!removed)
                {
                    return NotFound(new { Message = "Staff tidak ditemukan pada organizer ini." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}