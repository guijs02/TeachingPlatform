using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<CourseResponse> Create(CourseInputModel courseViewModel, Guid userId)
        {

            Course course = courseViewModel.ToModel();
            course.TeacherId = userId;

            await _courseRepository.Create(course);

            return new CourseResponse(course.Name, course.Description);
        }
    }
}
