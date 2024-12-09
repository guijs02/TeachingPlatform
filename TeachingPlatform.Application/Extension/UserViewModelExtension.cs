using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.ViewModels;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Extension
{
    public static class ViewModelExtension
    {
        public static Course ToModel(this CourseViewModel viewModel) =>
            new()
            {
                Description = viewModel.Description,
                Mudeles = viewModel.Mudeles,
                Name = viewModel.Name,
                TeacherId = viewModel.TeacherId,
            };
        public static User ToModel(this UserCreateViewModel viewModel) =>
            new()
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                TypeOfUser = viewModel.TypeOfUser,
            };
        
        public static User ToModel(this UserLoginViewModel viewModel) =>
            new()
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                TypeOfUser = viewModel.TypeOfUser,
            };
    }
}
