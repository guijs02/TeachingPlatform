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
                    entity.CourseId,
                    entity.Student.ToEntity(),
                    entity.Course.ToEntity())
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
                    Course = entity.Course.ToModel(),
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
                lessons.Add(new Lesson(entity.Name, entity.Module.ToEntity()));
            }

            return lessons;
        }

        public static List<LessonModel> ToModel(this List<Lesson> model)
        {
            var lessons = new List<LessonModel>();

            foreach (var entity in model)
            {
                lessons.Add(new LessonModel
                {
                    Module = entity.Module.ToModel(),
                    Name = entity.Name,
                });
            }
            return lessons;
        }
        #endregion


        public static List<Module> ToEntity(this List<ModuleModel> model)
        {
            var modules = new List<Module>();

            foreach (var entity in model)
            {
                modules.Add(new Module(
                    entity.Course.ToEntity(),
                    entity.CourseId,
                    entity.Lessons.ToEntity()));
            }
            return modules;

        }

        public static List<ModuleModel> ToModel(this List<Module> model)
        {
            var modules = new List<ModuleModel>();

            foreach (var entity in model)
            {
                modules.Add(new ModuleModel
                {
                    Course = entity.Course.ToModel(),
                    CourseId = entity.Course.Id,
                    Lessons = entity.Lessons.ToModel()
                });
            }
            return modules;
        }
    }
}
