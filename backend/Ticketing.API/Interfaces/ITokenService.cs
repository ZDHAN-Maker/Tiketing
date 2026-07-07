using Ticketing.API.Entities;

namespace Ticketing.API.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}