using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IUserCreateService
    {
        Task<Response<UserCreateResponse>> Create(UserCreateInputModel userCreateViewModel);
    }
}
