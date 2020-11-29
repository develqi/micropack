using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.AspNetCore.Versioning
{
    public static class IServiceCollectionExtensions
    {
        public static void AddVersioning(this IServiceCollection services, string name = "api-version")
        {
            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            
            services.AddVersionedApiExplorer();

            services.AddVersionedApiExplorer(options =>
            {
                ////The format of the version added to the route URL  
                //options.GroupNameFormat = "'v'VVV";
                ////Tells swagger to replace the version in the controller route  
                //options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                //options.ApiVersionReader = new HeaderApiVersionReader(name);
                //options.ApiVersionReader = new QueryStringOrHeaderApiVersionReader(name);

                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }
    }
}
