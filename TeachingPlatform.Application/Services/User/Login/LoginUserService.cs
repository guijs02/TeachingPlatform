using System.Net;
using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Application.Services.User.Login
{
    public class LoginUserService(IUserRepository userRepository, ITokenService tokenService) : IUserLoginService
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Response<string>>  Login(UserLoginInputModel userLoginViewModel)
        {
            if (userLoginViewModel == null) return new Response<string>(null, code: (int)HttpStatusCode.BadRequest);
            var user = userLoginViewModel.ToModel();

            var result = await _userRepository.Login(user);

            var token = _tokenService.GenerateToken(user);

            
            return result 
                ? new Response<string>(token)
                : new Response<string>(null, message:"Dados inválidos ou incorretos!");
        }
    }
}
