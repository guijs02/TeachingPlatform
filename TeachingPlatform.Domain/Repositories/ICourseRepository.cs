using System.Text;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Responses;

namespace TeachingPlatform.Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> CreateAsync(Course courseViewModel);
        Task<Course?> GetCourseWithLessonCompleted(Guid courseId, Guid userId, Guid moduleId, Guid lessonId);
        Task<bool> FinishLessonAsync(Guid courseId, Guid moduleId, Guid lessonId, Guid studentId);
        Task<GetAllContentCourseResponse?> GetAllContentCourseAsync(Guid courseId, Guid userId);
        Task<List<CourseGetAllResponse>> GetAllCourses(int pageSize, int pageNumber, Guid userId);
        Task<bool> ChangeProgressAsync(Course course);
        Task<bool> VerifyEnrollmentStudentActive(Guid courseId, Guid studentId);
    }
}
