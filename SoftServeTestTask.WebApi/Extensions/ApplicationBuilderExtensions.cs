using SoftServeTestTask.WebApi.Middleware;

namespace SoftServeTestTask.WebApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
