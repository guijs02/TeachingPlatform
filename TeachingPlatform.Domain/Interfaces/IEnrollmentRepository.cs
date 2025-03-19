using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> Create(Enrollment enrollment);
    }
}
