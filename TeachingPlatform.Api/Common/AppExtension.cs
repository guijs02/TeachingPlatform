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
