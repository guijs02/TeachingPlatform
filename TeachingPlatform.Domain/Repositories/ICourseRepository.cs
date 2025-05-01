using System.Text;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Responses;

namespace TeachingPlatform.Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> CreateAsync(Course courseViewModel);
        Task<List<GetAllContentCourseResponse>> GetAllContentCourseAsync(Guid courseId, Guid userId);
        Task<List<CourseGetAllResponse>> GetAllCourses(int pageSize, int pageNumber, Guid userId);

    }
}
