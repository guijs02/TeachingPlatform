using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Application.Services.Course
{
    public class GetAllCourseService(ICourseRepository courseRepository) : IGetAllCoursesService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<PagedResponse<List<CourseGetAllResponse>>> GetAllCoursesAsync(PagedRequest pagedRequest, Guid userId)
        {
            var query = await _courseRepository
                        .GetAllCourses(pagedRequest.PageSize, pagedRequest.PageNumber, userId);

            var courses = query
                .Skip((pagedRequest.PageNumber - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .Select(c => new CourseGetAllResponse(c.Name, c.Description))
                .ToList();

            var count = query.Count();

            return new PagedResponse<List<CourseGetAllResponse>>(
                courses,
                count,
                pagedRequest.PageNumber,
                pagedRequest.PageSize);

        }
    }
}
