using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Factories
{
    public static class EnrollmentFactory
    {
        public static Enrollment Create(Guid studentId, Guid courseId)
        {
            return new Enrollment(Guid.NewGuid(), studentId, courseId);
        }
    }
}
