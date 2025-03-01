using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Login(User createUser);
        Task<bool> Create(User loginUser);
    }
}
