using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.Services.Course;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Application.Services.Token;
using TeachingPlatform.Application.Services.User.Create;
using TeachingPlatform.Application.Services.User.Login;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Application.DIP
{
    public static class Build
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserCreateService, CreateUserService>();
            service.AddScoped<IUserLoginService, LoginUserService>();
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<ICreateCourseService, CreateCourseService>();
            service.AddScoped<IEnrollCreateService, CreateEnrollService>();
            service.AddScoped<IGetAllCoursesService, GetAllCourseService>();
            service.AddScoped<IGetAllContentCourseService, GetAllContentCourseService>();

            return service;
        }
    }
}
