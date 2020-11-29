using Microsoft.AspNetCore.Builder;

namespace Micropack.AspNetCore.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAntiforgeryToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AntiforgeryTokenMiddleware>();
        }

        //public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        //{
        //    app.UseMiddleware<ExceptionHandlerMiddleware>();
        //    return app;
        //}
    }
}
