using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Application.Services.User.Create
{
    public class CreateUserService(IUserRepository userRepository) : IUserCreateService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserCreateResponse> Create(UserCreateInputModel userCreateViewModel)
        {
            if (userCreateViewModel == null) return new UserCreateResponse();

            if (!Enum.IsDefined(userCreateViewModel.TypeOfUser)) return new UserCreateResponse();

            var result = await _userRepository.Create(userCreateViewModel.ToModel());

            return new UserCreateResponse(userCreateViewModel.UserName, result, userCreateViewModel.TypeOfUser);
        }
    }
}