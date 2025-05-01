using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Login(User createUser);
        Task<bool> Create(User loginUser);
        Task LogoutAsync();
    }
}
