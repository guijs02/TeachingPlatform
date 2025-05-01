using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class CourseMappingExtensions
    {
        public static Course ToEntity(this CourseModel model)
        {
            return CourseFactory.Create(
                model.Name,
                model.Description,
                model.TeacherId,
                model.Modules.Select(m => m.Name),
                model.Modules.SelectMany(m => m.Lessons.Select(l => l.Name)));
        }

        public static CourseModel ToModel(this Course model)
        {
            return new CourseModel
            {
                Name = model?.Name,
                Enrollments = [],
                Description = model.Description,
                Progress = "0",
                Modules = model.Modules.Select(s => s.ToModel()).ToList(),
                TeacherId = model.UserId,
            };
        }
    }
}
