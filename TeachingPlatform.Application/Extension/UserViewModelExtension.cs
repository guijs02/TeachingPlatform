using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Application.Extension
{
    public static class ViewModelExtension
    {
        public static Course ToEntity(this CourseInputModel viewModel)
        {
            var modules = new List<Module>();

            foreach (var item in viewModel.Mudeles)
            {
                modules.Add(new Module(item.Name, Guid.NewGuid()));
            }

            return new Course(viewModel.Name, viewModel.Description, viewModel.TeacherId);
        }
        public static List<Lesson> ToEntity(List<LessonInputModel> lessons)
        {
            List<Lesson> lessonsEntity = new List<Lesson>();
            foreach (var item in lessons)
            {
                lessonsEntity = new List<Lesson>()
                {
                   new (item.Description)
                };
            }

            return lessonsEntity;
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
