using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Repositories;
using TeachingPlatform.Domain.Responses;

namespace TeachingPlatform.Application.Services.Course
{
    public class GetAllContentCourseService(ICourseRepository courseRepository) : IGetAllContentCourseService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<Response<GetAllContentCourseResponse?>> GetAllContentCourseAsync(Guid courseId, Guid userId)
        {
            var contents = await _courseRepository.GetAllContentCourseAsync(courseId, userId);

            return new Response<GetAllContentCourseResponse?>(contents);
        }
    }
}
