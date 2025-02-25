using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Extension
{
    public static class ViewModelExtension
    {
        public static Course ToModel(this CourseInputModel viewModel)
        {
            Course course = new();

            foreach (var item in viewModel.Mudeles)
            {
                course.Mudules = new List<Module>
                {
                    new Module()
                    {
                        Name = item.Name,
                       Lessons = ToModel(item.Lessons)
                    }
                };
            }

            course.Description = viewModel.Description;
            course.Name = viewModel.Name;

            return course;
        }
        public static List<Lesson> ToModel(List<LessonInputModel> lessons)
        {
            List<Lesson> lessonsEntity = new List<Lesson>();
            foreach (var item in lessons)
            {
                lessonsEntity = new List<Lesson>()
               {
                   new Lesson() { Name = item.Description }
               };
            }

            return lessonsEntity;
        }
        public static User ToModel(this UserCreateInputModel viewModel) =>
            new()
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                TypeOfUser = viewModel.TypeOfUser,
            };

        public static User ToModel(this UserLoginInputModel viewModel) =>
            new()
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                TypeOfUser = viewModel.TypeOfUser,
            };
    }
}
