using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class CollectionsExtensions
    {
        #region Enrollment
        public static List<Enrollment> ToEntity(this List<EnrollmentModel> model)
        {
            var enrollments = new List<Enrollment>();

            foreach (var entity in model)
            {
                enrollments.Add(new Enrollment(
                    entity.StudentId,
                    entity.CourseId)
                );
            }
            return enrollments;
        }
        public static List<EnrollmentModel> ToModel(this List<Enrollment> model)
        {
            var enrollments = new List<EnrollmentModel>();

            foreach (var entity in model)
            {
                enrollments.Add(new EnrollmentModel
                {
                    CourseId = entity.CourseId,
                    CreatedAt = entity.CreatedAt,
                    StudentId = entity.StudentId,
                });
            }
            return enrollments;
        }
        #endregion

        #region Lesson

        public static List<Lesson> ToEntity(this List<LessonModel> model)
        {
            var lessons = new List<Lesson>();

            foreach (var entity in model)
            {
                lessons.Add(new Lesson(entity.Name));
            }

            return lessons;
        }

        public static LessonModel ToModel(this Lesson model)
        {
            return new LessonModel
            {
                Name = model.Name,
            };
        }
        #endregion


        public static List<Module> ToEntity(this List<ModuleModel> model)
        {
            var modules = new List<Module>();

            foreach (var entity in model)
            {
                modules.Add(new Module(
                    entity.Name,
                    entity.CourseId));
            }
            return modules;

        }

        //public static ModuleModel ToModel(this Module model)
        //{
        //    return new ModuleModel
        //    {
        //        CourseId = model.CourseId,
        //        Lessons = model.Lessons.Select(s => s.ToModel()).ToList(),
        //    };
        //}
    }
}
