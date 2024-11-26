using TeachingPlatform.Application.ViewModels;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(UserLoginViewModel userLoginViewModel);
        Task<bool> Create(UserCreateViewModel userCreateViewModel);

    }
}
