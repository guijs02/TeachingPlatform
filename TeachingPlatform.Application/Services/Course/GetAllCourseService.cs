using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Repositories;
using TeachingPlatform.Domain.Responses;

namespace TeachingPlatform.Application.Services.Course
{
    public class GetAllCourseService(ICourseRepository courseRepository) : IGetAllCoursesService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<PagedResponse<List<CourseGetAllResponse>>> GetAllCoursesAsync(PagedRequest pagedRequest, Guid userId)
        {
            var courses = await _courseRepository.GetAllCourses(pagedRequest.PageSize, pagedRequest.PageNumber, userId);

            return new PagedResponse<List<CourseGetAllResponse>>(
                courses,
                courses.Count,
                pagedRequest.PageNumber,
                pagedRequest.PageSize);

        }
    }
}
