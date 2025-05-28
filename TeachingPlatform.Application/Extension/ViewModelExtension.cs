using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;

namespace TeachingPlatform.Application.Extension
{
    public static class ViewModelExtension
    {
        public static Course ToEntity(this CourseInputModel viewModel) =>
            CourseFactory.Create(
                viewModel.Name,
                viewModel.Description,
                viewModel.TeacherId,
                viewModel.Modules.Select(m => m.Name),
                viewModel.Modules.SelectMany(m => m.Lessons).Select(l => new LessonDto(l.Description, false)));

        public static User ToEntity(this UserCreateInputModel viewModel) =>
            UserFactory.Create(viewModel.UserName, viewModel.Password, viewModel.TypeOfUser);

        public static User ToEntity(this UserLoginInputModel viewModel) =>
            UserFactory.Create(viewModel.UserName, viewModel.Password, viewModel.TypeOfUser);

        public static Enrollment ToEntity(this EnrollmentInputModel viewModel) =>
            EnrollmentFactory.Create(viewModel.StudentId, viewModel.CourseId);
    }
}
