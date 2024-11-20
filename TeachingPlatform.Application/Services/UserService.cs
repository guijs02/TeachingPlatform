using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.ViewModels;
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
        public async Task<bool> Create(UserCreateViewModel userCreateViewModel)
        {
            if (userCreateViewModel == null) return false;
            User user = userCreateViewModel.ToModel();
            return await _userRepository.Create(user);
        }

        public async Task<string> Login(UserLoginViewModel userLoginViewModel)
        {
            if (userLoginViewModel == null) return string.Empty;
            User user = userLoginViewModel.ToModel();
            return await _userRepository.Login(user);
        }
    }
}
