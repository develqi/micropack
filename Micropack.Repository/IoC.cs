//using System;

//namespace Micropack.Repository
//{
//    public static class IoC
//    {
//        public static void AddRepositoryServices(this IServiceCollection services)
//        {

//            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

//            services.AddScoped<JwtDataProvider>().AddTransient(serviceProvider => new Lazy<JwtDataProvider>(() => serviceProvider.GetRequiredService<JwtDataProvider>()));
//            services.AddScoped<AccessibilityService>().AddTransient(serviceProvider => new Lazy<AccessibilityService>(() => serviceProvider.GetRequiredService<AccessibilityService>()));
//        }
//    }
//}
