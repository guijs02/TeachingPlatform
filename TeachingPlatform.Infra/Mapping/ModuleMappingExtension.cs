using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class ModuleMappingExtension
    {
        //public static Domain.Entities.Module ToEntity(this ModuleModel model)
        //{
        //    return new Domain.Entities.Module
        //         (
        //            model.Name,
        //            model.CourseId,
        //            model.Lessons.ToEntity());
        //}

        public static ModuleModel ToModel(this Domain.Entities.Module model)
        {
            return new ModuleModel
            {
                CourseId = model.CourseId,
                Id = model.Id,
                Lessons = model.Lessons.Select(s => s.ToModel()).ToList(),
                Name = model.Name
            };
        }
    }
}
