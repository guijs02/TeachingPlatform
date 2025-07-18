using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachingPlatform.Api.Common;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;

namespace TeachingPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        public IUserCreateService _userCreateService;
        public IUserLoginService _userLoginService;
        public UserController(IUserCreateService userCreateService, IUserLoginService userLoginService)
        {
            _userCreateService = userCreateService;
            _userLoginService = userLoginService;
        }

        [HttpPost(Endpoints.CreateUser)]
        public async Task<IActionResult> CreateUser(UserCreateInputModel userCreateViewModel)
        {
            var result = await _userCreateService.Create(userCreateViewModel);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost(Endpoints.LoginUser)]
        public async Task<IActionResult> Login(UserLoginInputModel userLoginViewModel)
        {
            var token = await _userLoginService.Login(userLoginViewModel);
            return StatusCode(token.StatusCode, token);
        }

        [HttpDelete("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userLoginService.LogoutAsync();
            return Ok();
        }
    }
}
