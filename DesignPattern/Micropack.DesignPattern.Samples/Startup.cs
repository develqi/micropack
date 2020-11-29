using Micropack.DesignPattern.Strategy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Micropack.DesignPattern.Samples
{
    public class SampleProfile : StrategyProfile
    {
        public SampleProfile()
        {
            CreateEnumStrategy<LoyaltyLevels, PointCalculatorStrategy>();

            CreateStrategy<Customer, IRoundingMethodStrategy>()
              .ForCondition<Customer>(model => model.LoyaltyLevel == LoyaltyLevels.Gold, config => config.UseStrategy<GoldPointCalculatorStrategy>())
              .ForCondition<Customer>(model => model.LoyaltyLevel == LoyaltyLevels.Silver, config => config.UseStrategy<SilverPointCalculatorStrategy>())
              .ForCondition<Customer>(model => model.LoyaltyLevel == LoyaltyLevels.Bronze, config => config.UseStrategy<BronzePointCalculatorStrategy>());

            //CreateStrategy<Purchase, IRoundingMethodStrategy>()
            //    .ForCondition<Purchase>(model => model.PurchaseAmount > 100, config => config.UseStrategy<MoreThan100DollarPurchaseAmountStrategy>())
            //    .ForCondition<Purchase>(model => model.PurchaseAmount > 500, config => config.UseStrategy<MoreThan500DollarPurchaseAmountStrategy>())
            //    .ForCondition<Purchase>(model => model.PurchaseAmount > 1000, config => config.UseStrategy<MoreThan1000DollarPurchaseAmountStrategy>());
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var aaa = new SampleProfile();

            Strategies.AddStrategyProfile<SampleProfile>();

            //services.RegisterStrategiesFromAssemblyContaining<PointCalculatorStrategy>();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Micropack.DesignPattern.Samples", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Micropack.DesignPattern.Samples v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
