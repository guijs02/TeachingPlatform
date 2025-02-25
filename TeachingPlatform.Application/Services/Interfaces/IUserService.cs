using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponse> Login(UserLoginInputModel userLoginViewModel);
        Task<UserCreateResponse> Create(UserCreateInputModel userCreateViewModel);

    }
}
