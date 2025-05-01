using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IUserLoginService
    {
        Task<Response<string>> Login(UserLoginInputModel userLoginViewModel);
        Task<Response<bool>> LogoutAsync();
    }
}
