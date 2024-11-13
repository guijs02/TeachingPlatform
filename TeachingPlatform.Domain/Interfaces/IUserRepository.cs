using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<string> Login(User createUser);
        Task<bool> Create(User loginUser);
    }
}
