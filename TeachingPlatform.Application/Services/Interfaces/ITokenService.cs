using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
