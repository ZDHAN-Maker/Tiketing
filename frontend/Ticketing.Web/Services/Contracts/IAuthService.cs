using BlazorTicketingApp.Models;

namespace BlazorTicketingApp.Services.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task LogoutAsync();
    }
}