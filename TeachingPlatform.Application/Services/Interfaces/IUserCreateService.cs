using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IUserCreateService
    {
        Task<UserCreateResponse> Create(UserCreateInputModel userCreateViewModel);
    }
}
