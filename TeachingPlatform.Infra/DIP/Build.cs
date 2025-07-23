using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
using TeachingPlatform.Domain.Repositories;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Models;
using TeachingPlatform.Infra.Repositories;

namespace TeachingPlatform.Infra.DIP
{
    public static class Build
    {
        public static IServiceCollection AddContext(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            service.AddDbContext<TeachingContext>(opts => opts.UseNpgsql(connectionString));
            return service;
        }
        public static IdentityBuilder AddIdentityRole(this IServiceCollection service)
        {
            return service
                .AddIdentity<UserModel, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<TeachingContext>()
                .AddDefaultTokenProviders();
        }

        public static IServiceCollection AddInfraDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICourseRepository, CourseRepository>();
            service.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            return service;
        }
    
    }
}
