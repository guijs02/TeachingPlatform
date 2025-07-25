﻿using System.Net;
using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Repositories;

namespace TeachingPlatform.Application.Services.User.Login
{
    public class LoginUserService(IUserRepository userRepository, ITokenService tokenService) : IUserLoginService
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Response<string>> Login(UserLoginInputModel userLoginViewModel)
        {
            if (userLoginViewModel == null) return new Response<string>(null, code: (int)HttpStatusCode.BadRequest);

            var user = userLoginViewModel.ToEntity();

            if (user.Notification.HasErrors())
            {
                return new Response<string>(null,
                                    (int)HttpStatusCode.BadRequest,
                                    user.Notification.GetMessages(nameof(User)));
            }

            var result = await _userRepository.Login(user);

            if (!result)
                return new Response<string>(null,
                                (int)HttpStatusCode.BadRequest,
                                "Dados inválidos ou incorretos!");


            var token = _tokenService.GenerateToken(user);

            return new Response<string>(token);
        }

        public async Task<Response<bool>> LogoutAsync()
        {
            await _userRepository.LogoutAsync();
            return new Response<bool>(true, message: "Logout feito com sucesso");
        }
    }
}
