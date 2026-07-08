using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly TicketingDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(TicketingDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // TAMBAHAN: Kata kunci 'async' sebelum Task
        public async Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto)
        {
            // 1. Validasi apakah email sudah terdaftar
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email sudah digunakan.");

            // 2. Hash password menggunakan BCrypt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // 3. Buat entitas User baru
            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = hashedPassword,
                Phone = dto.Phone,
                IsActive = true
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // 4. Berikan Role default (Misal: 'Customer' dengan ID 2)
            var defaultRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == "customer");
            if (defaultRole != null)
            {
                _context.UserRoles.Add(new UserRole { UserId = newUser.Id, RoleId = defaultRole.Id });
                await _context.SaveChangesAsync();
            }

            // Ambil ulang user beserta rolenya untuk dibuatkan token
            var userWithRoles = await _context.Users
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .FirstAsync(u => u.Id == newUser.Id);

            return new AuthResponseDto
            {
                Token = _tokenService.GenerateJwtToken(userWithRoles),
                Name = userWithRoles.Name,
                Email = userWithRoles.Email,
                Roles = userWithRoles.UserRoles.Select(ur => ur.Role.Name).ToList()
            };
        }

        // TAMBAHAN: Kata kunci 'async' sebelum Task
        public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            // 1. Cari user berdasarkan email beserta data Role-nya (Eager Loading)
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null) return null;

            // 2. Verifikasi Password BCrypt
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password)) return null;

            // 3. Generate Token jika sukses
            var token = _tokenService.GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Name = user.Name,
                Email = user.Email,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            };
        }
    }
}