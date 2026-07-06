using Microsoft.EntityFrameworkCore;
using Ticketing.API.Models;
using Ticketing.API.DTOs.Auth;
using Ticketing.API.Interfaces;
using BCrypt.Net;

namespace Ticketing.API.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context; 
    private readonly ITokenService _tokenService;

    public AuthService(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken = default)
    {
        // 1. Validasi Email Unik
        if (await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken))
            throw new Exception("Email already exists."); 
        // 2. Hash Password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // 3. Buat User Baru
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = passwordHash,
            Status = UserStatus.Active, // Enum status
            CreatedAt = DateTime.UtcNow
        };

        // 4. Assign Default Role (Misal: "Customer")
        var defaultRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Customer", cancellationToken);
        if (defaultRole != null)
        {
            var userRole = new UserPlatformRole
            {
                UserId = user.Id,
                RoleId = defaultRole.Id,
                AssignedAt = DateTime.UtcNow
            };
            _context.UserPlatformRoles.Add(userRole);
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        // 5. Generate Response (Bisa langsung login setelah register)
        return await GenerateAuthResponseAsync(user, ipAddress: null, deviceInfo: null, cancellationToken);
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request, string? ipAddress, string? deviceInfo, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .Include(u => u.UserPlatformRoleUsers)
                .ThenInclude(upr => upr.Role)
            .FirstOrDefaultAsync(u => u.Email == request.Email && !u.IsDeleted, cancellationToken);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password.");

        user.LastLoginAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);

        return await GenerateAuthResponseAsync(user, ipAddress, deviceInfo, cancellationToken);
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(string token, string? ipAddress, string? deviceInfo, CancellationToken cancellationToken = default)
    {
        var refreshToken = await _context.RefreshTokens
            .Include(rt => rt.User)
                .ThenInclude(u => u.UserPlatformRoleUsers)
                    .ThenInclude(upr => upr.Role)
            .FirstOrDefaultAsync(rt => rt.TokenHash == token, cancellationToken);

        if (refreshToken == null || refreshToken.RevokedAt != null || refreshToken.ExpiresAt < DateTime.UtcNow)
            throw new UnauthorizedAccessException("Invalid or expired refresh token.");

        // Revoke token lama
        refreshToken.RevokedAt = DateTime.UtcNow;

        return await GenerateAuthResponseAsync(refreshToken.User, ipAddress, deviceInfo, cancellationToken);
    }

    private async Task<AuthResponseDto> GenerateAuthResponseAsync(User user, string? ipAddress, string? deviceInfo, CancellationToken cancellationToken)
    {
        var roles = user.UserPlatformRoleUsers.Select(ur => ur.Role.RoleName).ToList();
        
        var accessToken = _tokenService.GenerateAccessToken(user, roles);
        var refreshTokenString = _tokenService.GenerateRefreshToken();

        var refreshToken = new RefreshToken
        {
            UserId = user.Id,
            TokenHash = refreshTokenString,
            ExpiresAt = DateTime.UtcNow.AddDays(7), // Tergantung konfigurasi
            CreatedAt = DateTime.UtcNow,
            IpAddress = ipAddress != null ? System.Net.IPAddress.Parse(ipAddress) : null,
            DeviceInfo = deviceInfo
        };

        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshTokenString,
            User = new UserProfileDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Roles = roles
            }
        };
    }
}