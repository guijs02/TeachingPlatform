using Microsoft.AspNetCore.Identity;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;
using TeachingPlatform.Infra.Mapping;

namespace TeachingPlatform.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private SignInManager<UserModel> _signInManager;
        public UserRepository(UserManager<UserModel> userManager,
                             RoleManager<IdentityRole<Guid>> roleManager,
                             SignInManager<UserModel> signInManager,
                             ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Create(User user)
        {
            var model = user.ToModel();
            var result = await _userManager.CreateAsync(model, model.Password);

            return result.Succeeded;
        }

        public async Task<bool> Login(User loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(
              loginUser.UserName,
              loginUser.Password,
              false,
              false
            );

            var user = _signInManager.UserManager.Users.FirstOrDefault(
                user => user.NormalizedUserName == loginUser.UserName.ToUpper()
            );

            return result.Succeeded;
        }
    }
}

