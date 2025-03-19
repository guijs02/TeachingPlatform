using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachingPlatform.Application.Services.Course;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Application.Services.Token;
using TeachingPlatform.Application.Services.User.Create;
using TeachingPlatform.Application.Services.User.Login;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Models;
using TeachingPlatform.Infra.Repositories;

namespace ManageDependencyInjection.Api
{
    public static class Build
    {
        public static IServiceCollection AddContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<TeachingContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("Database")));
            return service;
        }
        public static IServiceCollection AddDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserCreateService, CreateUserService>();
            service.AddScoped<IUserLoginService, LoginUserService>();
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<ICreateCourseService, CreateCourseService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICourseRepository, CourseRepository>();
            return service;
        }
        public static IdentityBuilder AddIdentityRole(this IServiceCollection service)
        {
            return service
                .AddIdentity<UserModel, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<TeachingContext>()
                .AddDefaultTokenProviders();
        }
    }
}
