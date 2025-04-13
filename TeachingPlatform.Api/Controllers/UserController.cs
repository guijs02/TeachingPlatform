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
            try
            {

                var result = await _userCreateService.Create(userCreateViewModel);
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
                var token = await _userLoginService.Login(userLoginViewModel);
                return Ok(token);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }  

        //[HttpPost("logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    try
        //    {
        //        User.Identity.lo
        //        return Ok(token);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message.ToString());
        //    }
        //}
    }
}
