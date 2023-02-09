using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddlewares
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddlewares(RequestDelegate next, ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
            _loggerService.Write(message);
            await _next(context);
        }
    }

    public static class CustomExceptionMiddlewaresExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddlewares>();
        }
    }
}