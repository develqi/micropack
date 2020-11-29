using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.AspNetCore.Swagger
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseSwaggerDocumentUI(this IApplicationBuilder app, string title, string baseUrl = "")
        {
            var url = "/swagger/v1/swagger.json";

            if (!string.IsNullOrEmpty(baseUrl))
                url = $"/{baseUrl}{url}";

            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint(url, $"{title} API`s"));
        }

        public static void UseVersioningSwaggerDocumentUI(this IApplicationBuilder app, string title, string baseUrl = "")
        {
            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    var url = $"/swagger/{description.GroupName}/swagger.json";

                    if (!string.IsNullOrEmpty(baseUrl))
                        url = $"/{baseUrl}{url}";

                    options.SwaggerEndpoint(url, $"{title} version {description.GroupName}");
                }
            });
        }
    }
}
