using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachingPlatform.Api.Common;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Application.ViewModels;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CourseController : ControllerBase
    {
        public IUserService _userService;
        public readonly ICourseService _courseService;
        public CourseController(IUserService userService, ICourseService courseService)
        {
            _userService = userService;
            _courseService = courseService;
        }

        [HttpPost(Endpoints.CreateCourse)]
        [Authorize(Roles = "INSTRUTOR")]
        public async Task<IActionResult> Create(CourseViewModel courseViewModel)
        {
            try
            {
                var result = await _courseService.Create(courseViewModel);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

    }
}
