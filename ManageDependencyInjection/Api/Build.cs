using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachingPlatform.Application.Services;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;
using TeachingPlatform.Infra.Context;
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
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ITokenService, TokenService>();
            return service;
        }
        public static IdentityBuilder AddIdentityRole(this IServiceCollection service)
        {
            return service
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TeachingContext>()
                .AddDefaultTokenProviders();
        }

    }
}
