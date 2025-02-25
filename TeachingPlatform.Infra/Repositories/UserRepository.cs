using Microsoft.AspNetCore.Identity;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public UserRepository(UserManager<User> userManager,
                             RoleManager<IdentityRole<Guid>> roleManager,
                             SignInManager<User> signInManager,
                             ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<bool> Create(User createUser)
        {
            var result = await _userManager.CreateAsync(createUser, createUser.Password);

            return result.Succeeded;
        }

        public async Task<string> Login(User loginUser)
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


            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado");
            }

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}

