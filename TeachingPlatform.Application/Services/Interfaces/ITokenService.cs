namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Domain.Entities.User user);
    }
}
