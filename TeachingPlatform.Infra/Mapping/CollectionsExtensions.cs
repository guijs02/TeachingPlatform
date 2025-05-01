using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class CollectionsExtensions
    {
        #region Enrollment
        public static List<Enrollment> ToEntity(this List<EnrollmentModel> model)
        {
            return model.Select(entity =>
                EnrollmentFactory.Create(
                    entity.StudentId,
                    entity.CourseId
                )).ToList();
        }

        public static List<EnrollmentModel> ToModel(this List<Enrollment> model)
        {
            return model.Select(entity => new EnrollmentModel
            {
                CourseId = entity.CourseId,
                CreatedAt = entity.CreatedAt,
                StudentId = entity.StudentId,
            }).ToList();
        }
        #endregion

        #region Lesson

        //public static List<Lesson> ToEntity(this List<LessonModel> model)
        //{
        //    return model.Select(s =>
        //        new Module(
        //            s.Id
        //            s.Name,
        //            s.ModuleId,
        //        )).ToList();
        //}

        public static LessonModel ToModel(this Lesson model)
        {
            return new LessonModel
            {
                Name = model.Name,
                ModuleId = model.ModuleId
            };
        }
        #endregion

        #region Module

        //public static List<Module> ToEntity(this List<ModuleModel> model)
        //{
        //    return model.Select(s =>
        //        ModuleFactory.Create(
        //            s.Name,
        //            s.CourseId,
        //            s.Lessons.Select(l => l.Name).ToList()
        //        )).ToList();
        //}

        #endregion
    }
}
