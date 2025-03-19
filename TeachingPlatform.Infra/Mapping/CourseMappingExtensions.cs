using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class CourseMappingExtensions
    {
        public static Course ToEntity(this CourseModel model)
        {
            return new Course(
                model.Name,
                model.Description,
                model.TeacherId,
                model.Mudules.ToEntity());
        }

        public static CourseModel ToModel(this Course model)
        {
            return new CourseModel
            {
                Name = model?.Name,
                Enrollments = [],
                Description = model.Description,
                Mudules = model.Mudules.ToModel(),
                TeacherId = model.TeacherId,
            };
        }
    }
}
