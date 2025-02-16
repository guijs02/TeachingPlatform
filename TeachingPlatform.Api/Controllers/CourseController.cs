using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost(Endpoints.CreateCourse)]
        [Authorize(Roles = "TEACHER")]
        public async Task<IActionResult> Create(CourseViewModel courseViewModel)
        {
            try
            {
                var userId = User.FindFirstValue("id");
                var result = await _courseService.Create(courseViewModel, Guid.Parse(userId));
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

    }
}
