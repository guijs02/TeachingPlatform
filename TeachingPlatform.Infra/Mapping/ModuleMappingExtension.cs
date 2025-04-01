using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    internal static class ModuleMappingExtension
    {
        public static Domain.Entities.Module ToEntity(this ModuleModel model)
        {
            return new Domain.Entities.Module
                 (
                    model.Name,
                    model.CourseId);
        }

        public static ModuleModel ToModel(this Domain.Entities.Module model)
        {
            return new ModuleModel
            {
                CourseId = model.CourseId,
                Name = model.Name
            };
        }
    }
}
