using Microsoft.AspNetCore.Mvc;
using TeachingPlatform.Application.Services;
using TeachingPlatform.Application.ViewModels;

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

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(UserCreateViewModel userCreateViewModel)
        {
            try
            {
                await _userService.Create(userCreateViewModel);
                return Ok("Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            try
            {
                string token = await _userService.Login(userLoginViewModel);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest("Usuario não encontrado");
            }
        }

    }
}
