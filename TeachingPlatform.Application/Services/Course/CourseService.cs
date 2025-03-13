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
        public async Task<Response<CourseResponse>> Create(CourseInputModel courseViewModel, Guid userId)
        {

            var course = courseViewModel.ToModel();
            course.TeacherId = userId;

            await _courseRepository.Create(course);

            var response = new CourseResponse(course.Name, course.Description);

            return new Response<CourseResponse>(response);
        }
    }
}
