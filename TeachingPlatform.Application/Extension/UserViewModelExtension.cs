using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Application.Extension
{
    public static class ViewModelExtension
    {
        public static Course ToEntity(this CourseInputModel viewModel)
        {
            var course = new Course(viewModel.Name, viewModel.Description, viewModel.TeacherId);
            viewModel.Mudeles.ForEach(module =>
            {
                var moduleEntity = new Module(module.Name, course.Id);

                module.Lessons.ForEach(lesson =>
                {
                    moduleEntity.AddLesson(new Lesson(lesson.Description, moduleEntity.Id));
                });

                course.AddModule(moduleEntity);
            });

            return course;
        }
        
        public static User ToEntity(this UserCreateInputModel viewModel) =>
            new(
                Guid.NewGuid(),
                viewModel.UserName,
                viewModel.Password,
                viewModel.TypeOfUser);

        public static User ToEntity(this UserLoginInputModel viewModel) =>
             new(Guid.NewGuid(),
                 viewModel.UserName,
                viewModel.Password,
                viewModel.TypeOfUser);

        public static Enrollment ToEntity(this EnrollmentInputModel viewModel)
        {
            return new Enrollment(viewModel.StudentId, viewModel.CourseId);
        }
    }
}
