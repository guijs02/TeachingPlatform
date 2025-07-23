using System.Net;
using System.Text.Json;
using TeachingPlatform.Domain.Exceptions;

namespace TeachingPlatform.Api
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                switch (ex)
                {
                    case DomainException _:
                        await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest);
                        break;
                    default:
                        await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError);
                        break;
                }

                _logger.LogError(ex, "An unhandled exception occurred..");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
        {
            var response = new
            {
                Message = "An unexpected error occurred while processing the request.",
                Detail = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
