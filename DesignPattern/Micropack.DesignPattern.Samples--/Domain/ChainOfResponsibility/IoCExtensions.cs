using Microsoft.Extensions.DependencyInjection;
using Micropack.DesignPattern.Domain.ChainOfResponsibility.Chains;

namespace Micropack.DesignPattern.Domain.ChainOfResponsibility
{
    public static class IoCExtensions
    {
        public static void AddStorePurchaseChains(this IServiceCollection services)
        {
            services.Chain<StorePurchaseContext>()
                    .Add<FindOrCreateBranch>()
                    .Add<FindOrCreateTill>()
                    .Add<FindOrCreateCustomer>()
                    .Add<ClaculatePlans>()
                    .Add<SaveToDatabase>()
                    .Configure();

            // use below code in IoC...
            //services.AddStorePurchaseChains();
        }
    }
}


