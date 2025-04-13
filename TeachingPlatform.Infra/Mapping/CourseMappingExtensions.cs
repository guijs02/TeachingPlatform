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
                model.TeacherId);
        }

        public static CourseModel ToModel(this Course model)
        {
            return new CourseModel
            {
                Name = model?.Name,
                Enrollments = [],
                Description = model.Description,
                Mudules = model.Mudules.Select(s => s.ToModel()).ToList(),
                TeacherId = model.UserId,
            };
        }
    }
}
