using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachingPlatform.Infra.Context;

namespace ManageDependencyInjection
{
    public static class AddDatabase
    {
        public static IServiceCollection AddContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSqlServer<TeachingContext>(configuration["ConnectionStrings:Database"]);
            return service;
        }
    }
}
