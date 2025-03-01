using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> Create(Course courseViewModel);
    }
}
