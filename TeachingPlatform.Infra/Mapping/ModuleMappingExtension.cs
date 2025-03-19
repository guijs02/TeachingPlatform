using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    internal static class ModuleMappingExtension
    {
        public static Domain.Entities.Module ToEntity(this ModuleModel model)
        {
            return new Domain.Entities.Module
                 (
                    model.Course.ToEntity(),
                    model.CourseId,
                    model.Lessons.ToEntity());
        }

        public static ModuleModel ToModel(this Domain.Entities.Module model)
        {
            return new ModuleModel
            {
                Course = model.Course.ToModel(),
                CourseId = model.Course.Id,
                Lessons = model.Lessons.ToModel(),
            };
        }
    }
}
