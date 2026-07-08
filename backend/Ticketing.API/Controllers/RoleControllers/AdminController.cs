using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data;
using Ticketing.API.Entities;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly TicketingDbContext _context;

        public AdminController(TicketingDbContext context)
        {
            _context = context;
        }

        // PERBAIKAN: Mengubah tipe data UserId menjadi long agar cocok dengan Entity User
        public class ChangeRoleDto
        {
            public long UserId { get; set; } // <-- Diubah dari int ke long
            public string NewRoleName { get; set; } = null!;
        }

        [HttpPost("change-user-role")]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeRoleDto dto)
        {
            // 1. Validasi apakah user yang dituju ada di database
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                return NotFound(new { message = "User tidak ditemukan." });
            }

            // 2. Validasi apakah nama role baru yang diminta terdaftar di master data
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == dto.NewRoleName);
            if (role == null)
            {
                return BadRequest(new { message = $"Role '{dto.NewRoleName}' tidak valid." });
            }

            // 3. Hapus role lama si user dari tabel perantara (UserRoles) untuk mencegah duplikasi
            var oldUserRoles = _context.UserRoles.Where(ur => ur.UserId == dto.UserId);
            _context.UserRoles.RemoveRange(oldUserRoles);

            // 4. Pasangkan user dengan role baru
            var newUserRole = new UserRole
            {
                UserId = dto.UserId,
                RoleId = role.Id
            };

            await _context.UserRoles.AddAsync(newUserRole);
            await _context.SaveChangesAsync();

            return Ok(new { 
                message = $"Berhasil mengubah role untuk user '{user.Name}' menjadi '{role.Name}'." 
            });
        }
    }
}