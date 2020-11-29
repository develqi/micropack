
namespace Micropack.DesignPattern.Domain.ChainOfResponsibility.Chains
{  
    public class ClaculatePlans : StorePurchaseContext
    {
        public ClaculatePlans(StorePurchaseContext next) : base(next)
        {
            
        }

        public override StorePurchaseResponse Execute(StorePurchaseRequest request)
        {
            // محاسبه امتیاز طرح های وفاداری
            return _next.Execute(request);
        }
    }
}
