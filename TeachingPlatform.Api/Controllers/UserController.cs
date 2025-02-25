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
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(Endpoints.CreateUser)]
        public async Task<IActionResult> CreateUser(UserCreateInputModel userCreateViewModel)
        {
            try
            {

                var result = await _userService.Create(userCreateViewModel);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

        [HttpPost(Endpoints.LoginUser)]
        public async Task<IActionResult> Login(UserLoginInputModel userLoginViewModel)
        {
            try
            {
                var token = await _userService.Login(userLoginViewModel);
                return Ok(token);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

    }
}
