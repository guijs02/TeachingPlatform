using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeachingPlatform.Api.Common;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Services.Interfaces;

namespace TeachingPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CourseController : ControllerBase
    {
        public readonly ICreateCourseService _courseService;
        public readonly IGetAllCoursesService _getAllCourses;
        public readonly IGetAllContentCourseService _getAllContentCourse;
        public readonly ICompletedLessonService _completedLesson;
        public CourseController(ICreateCourseService courseService,
                                IGetAllCoursesService getAllCourses,
                                IGetAllContentCourseService getAllContentCourse,
                                ICompletedLessonService completedLesson)
        {
            _courseService = courseService;
            _getAllCourses = getAllCourses;
            _getAllContentCourse = getAllContentCourse;
            _completedLesson = completedLesson;
        }

        [HttpPost(Endpoints.CreateCourse)]
        [Authorize(Roles = "TEACHER")]
        public async Task<IActionResult> Create(CourseInputModel courseViewModel)
        {
            try
            {
                var userId = UserInput.GetUserId(User);

                var result = await _courseService.CreateAsync(courseViewModel, userId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] PagedRequest pagedRequest)
        {
            try
            {
                var userId = UserInput.GetUserId(User);
                var result = await _getAllCourses.GetAllCoursesAsync(pagedRequest, userId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

        [HttpGet("get-all-content/{courseId}")]
        [Authorize]
        public async Task<IActionResult> GetAllContentCourse(Guid courseId)
        {
            try
            {
                var userId = UserInput.GetUserId(User);
                var result = await _getAllContentCourse.GetAllContentCourseAsync(courseId, userId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

        [HttpPost(Endpoints.FinishClass)]
        [Authorize(Roles = "STUDENT")]
        public async Task<IActionResult> FinishClass([FromBody] FinishLessonInputModel inputModel)
        {
            try
            {
                var userId = UserInput.GetUserId(User);
                var result = await _completedLesson.FinishLessonAsync(inputModel, userId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

    }
}
