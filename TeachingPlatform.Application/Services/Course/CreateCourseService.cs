using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Application.Services.Course
{
    public class CreateCourseService : ICreateCourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CreateCourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Response<CourseCreateResponse>> CreateAsync(CourseInputModel courseViewModel, Guid userId)
        {
            courseViewModel.TeacherId = userId;

            var course = courseViewModel.ToEntity();

            await _courseRepository.CreateAsync(course);

            var response = new CourseCreateResponse(course.Name, course.Description);

            return new Response<CourseCreateResponse>(response);
        }
    }
}
