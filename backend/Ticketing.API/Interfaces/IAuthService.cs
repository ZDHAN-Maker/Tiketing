using Ticketing.API.DTOs.Auth;

namespace Ticketing.API.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken = default);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request, string? ipAddress, string? deviceInfo, CancellationToken cancellationToken = default);
    Task<AuthResponseDto> RefreshTokenAsync(string token, string? ipAddress, string? deviceInfo, CancellationToken cancellationToken = default);
}