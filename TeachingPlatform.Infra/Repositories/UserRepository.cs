using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.Services;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public UserRepository(UserManager<User> userManager,
                             RoleManager<IdentityRole> roleManager,
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
            IdentityResult result = await _userManager.CreateAsync(createUser, createUser.Password);

            if (!result.Succeeded)
                throw new ApplicationException("Falha ao cadastrar o usúario");

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
