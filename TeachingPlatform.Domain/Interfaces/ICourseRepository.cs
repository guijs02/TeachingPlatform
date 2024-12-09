using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> Create(Course courseViewModel);
    }
}
