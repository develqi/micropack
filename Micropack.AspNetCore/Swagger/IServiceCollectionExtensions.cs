using System;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.AspNetCore.Swagger
{

    public static class IServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services, string title)
        {
            services.AddSwaggerGen(options =>
            {
                //Add Lockout icon on top of swagger ui page to authenticate
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    //In = "header"
                });

                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = $"{title} API`s", Description = $"{title} API`s Swagger surface" });
            });
        }

        public static void AddVersioningSwagger(this IServiceCollection services, string title, OpenApiContact contact)
        {
            services.AddSwaggerGen(options =>
            {
                #region Add Jwt Authentication

                       //In Swashbuckle.AspNetCore.SwaggerGen - 5.0.0 - rc3, the DescribeAllEnumsAsStrings method is marked obsolete and to - be - deprecated because it will automatically be applied if that convention is present in the serializer. However, the functionality is only present if Newtonsoft.Json is used as the serializer.If using the new default Json serializer in .NET Core 3, the StringEnumConverter is not respected.
                       //options.DescribeAllEnumsAsStrings();

                       //options.DescribeAllParametersInCamelCase();
                       //options.DescribeStringEnumsInCamelCase()
                       //options.UseReferencedDefinitionsForEnums()
                       //options.IgnoreObsoleteActions();

                       //options.IgnoreObsoleteProperties();
                       //Add Lockout icon on top of swagger ui page to authenticate
                       options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    //In = "header"
                });

                //Add 401 response and security requirements (Lock icon) to actions that need authorization
                options.OperationFilter<UnauthorizedResponsesOperationFilter>(true, "Bearer");

                #endregion Jwt Authentication

                #region Add Versioning

                // resolve the IApiVersionDescriptionProvider service
                // note: that we have to build a temporary service provider here because one has not been created yet
                using (var serviceProvider = services.BuildServiceProvider())
                {
                    var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

                    // add a swagger document for each discovered API version
                    // note: you might choose to skip or document deprecated API versions differently
                    foreach (var description in provider.ApiVersionDescriptions)
                        options.SwaggerDoc($"{description.GroupName}", CreateInfoForApiVersion(description, title, contact));

                    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                    xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
                }

                options.OperationFilter<VersionOperationFilter>();

                #endregion Add Versioning
            });
        }

        // ---------------------------------------- Private-------------------------------------- //

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription apiVersionDescription, string title, OpenApiContact contact)
        {
            var info = new OpenApiInfo()
            {
                Description = $"{title} Swagger surface",
                Contact = contact,
            };

            info.Version = $"{apiVersionDescription.ApiVersion}";
            info.Title = $"{title} API`s version {apiVersionDescription.ApiVersion}";

            if (apiVersionDescription.IsDeprecated)
                info.Description += " This API`s version has been deprecated.";

            return info;
        }

        public class UnauthorizedResponsesOperationFilter : IOperationFilter
        {
            private readonly bool _includeUnauthorizedAndForbiddenResponses;
            private readonly string _schemeName;

            public UnauthorizedResponsesOperationFilter(bool includeUnauthorizedAndForbiddenResponses, string schemeName)
            {
                this._includeUnauthorizedAndForbiddenResponses = includeUnauthorizedAndForbiddenResponses;
                this._schemeName = schemeName;
            }

            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var filters = context.ApiDescription.ActionDescriptor.FilterDescriptors;

                var hasAnonymous = filters.Any(p => p.Filter is AllowAnonymousFilter);
                if (hasAnonymous) return;

                var hasAuthorize = filters.Any(p => p.Filter is AuthorizeFilter);
                if (!hasAuthorize) return;

                if (_includeUnauthorizedAndForbiddenResponses)
                {
                    //operation.Responses.Add("401", new Response { Description = "خطای احراز حویت" });
                    //operation.Responses.Add("403", new Response { Description = "اجرای درخواست ممنوع است" });
                    //operation.Responses.Add("404", new Response { Description = "در صورتی که شناسه مسابقه یا شناسه بسته معتبر نباشند" });
                }

                //operation.Security = new List<IDictionary<string, IEnumerable<string>>>
                //{
                //    new Dictionary<string, IEnumerable<string>> { { schemeName, new string[] { } } }
                //};
            }
        }

        public class VersionOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var version = context.ApiDescription.GetApiVersion().MajorVersion;

                //((NonBodyParameter)operation.Parameters.FirstOrDefault(x => x.Name == "api-version")).Default = version;
            }
        }
    }
}
