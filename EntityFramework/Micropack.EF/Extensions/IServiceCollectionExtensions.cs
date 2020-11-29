using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.EF
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterDbContext<TDbContext>(this IServiceCollection services) where TDbContext : DbContext, IDbContext
        {
            // ToDo: add EF second level cash

            services.AddScoped(typeof(TDbContext));
            services.AddScoped(typeof(IDbContext), typeof(TDbContext));
        }
    }
}
