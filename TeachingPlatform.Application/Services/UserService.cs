using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserCreateResponse> Create(UserCreateInputModel userCreateViewModel)
        {
            if (userCreateViewModel == null) return new UserCreateResponse();

            if (!Enum.IsDefined(userCreateViewModel.TypeOfUser)) return new UserCreateResponse();

            var result = await _userRepository.Create(userCreateViewModel.ToModel());

            return new UserCreateResponse(userCreateViewModel.UserName, result, userCreateViewModel.TypeOfUser);
        }

        public async Task<UserLoginResponse> Login(UserLoginInputModel userLoginViewModel)
        {
            if (userLoginViewModel == null) return new(string.Empty);
            User user = userLoginViewModel.ToModel();
            var token = await _userRepository.Login(user);
            return new UserLoginResponse(token);
        }
    }
}
