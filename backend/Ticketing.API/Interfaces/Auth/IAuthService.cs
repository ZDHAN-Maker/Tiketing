using System.Threading.Tasks;
using Ticketing.API.DTOs;

namespace Ticketing.API.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto);
    }
}