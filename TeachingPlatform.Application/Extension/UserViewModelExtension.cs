using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.ViewModels;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Extension
{
    public static class UserViewModelExtension
    {
        public static User ToModel(this UserCreateViewModel viewModel) =>
            new()
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
            };
        
        public static User ToModel(this UserLoginViewModel viewModel) =>
            new()
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
            };
    }
}
