using TeachingPlatform.Application.Services;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Infra.Repositories;

namespace TeachingPlatform.Api.Common
{
    public static class AppExtension
    {
        public static WebApplication AddSwaggerUI(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }

    }
}
