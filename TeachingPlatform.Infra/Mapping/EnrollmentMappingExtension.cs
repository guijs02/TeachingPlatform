using TeachingPlatform.Domain.Entities;

using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class EnrollmentMappingExtension
    {
        public static Enrollment ToEntity(this EnrollmentModel model)
        {
            return new Enrollment(
                    model.StudentId,
                    model.CourseId);
        }

        public static EnrollmentModel ToModel(this Enrollment entity)
        {
            return new EnrollmentModel
            {
                CourseId = entity.CourseId,
                CreatedAt = DateTime.Now,
                StudentId = entity.StudentId,
            };
        }
    }
}
