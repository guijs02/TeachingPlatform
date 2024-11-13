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
        public Task<bool> Create(UserCreateViewModel userCreateViewModel)
        {
            User user = userCreateViewModel.ToModel();
            return _userRepository.Create(user);
        }

        public Task<string> Login(UserLoginViewModel userLoginViewModel)
        {
            User user = userLoginViewModel.ToModel();
            return _userRepository.Login(user);
        }
    }
}
