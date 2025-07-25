﻿using Microsoft.AspNetCore.Identity;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Repositories;
using TeachingPlatform.Infra.Mapping;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private SignInManager<UserModel> _signInManager;
        public UserRepository(UserManager<UserModel> userManager,
                             RoleManager<IdentityRole<Guid>> roleManager,
                             SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Create(User user)
        {
            try
            {

                var model = user.ToModel();
                var result = await _userManager.CreateAsync(model, model.Password);

                return result.Succeeded;
            }
            catch (Exception e)
            {

                throw;
            }
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
                u => u.NormalizedUserName == loginUser.UserName.ToUpper()
            );

            if (user is null)
                return false;

            loginUser.Id = user.Id;

            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

