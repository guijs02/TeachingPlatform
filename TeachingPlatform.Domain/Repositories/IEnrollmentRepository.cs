using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<Guid> Create(Enrollment enrollment);
        Task<string> GetNameByCourseStudentAsync(Guid courseId, Guid studentId);
    }
}
