using System.Text;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> CreateAsync(Course courseViewModel);
        Task<IQueryable<Course>> GetAllCourses(int pageSize, int pageNumber, Guid userId);
    }
}
