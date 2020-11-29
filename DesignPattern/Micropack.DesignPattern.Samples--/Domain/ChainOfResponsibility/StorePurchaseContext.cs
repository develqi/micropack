
namespace Micropack.DesignPattern.Domain.ChainOfResponsibility
{
    public abstract class StorePurchaseContext
    {
        protected readonly StorePurchaseContext _next;
                
        protected StorePurchaseContext(StorePurchaseContext next)
        {
            _next = next;
        }

        public abstract StorePurchaseResponse Execute(StorePurchaseRequest request);
    }

    //public class StorePurchaseContext2 : ChainOfResponsibiliti<StorePurchaseContext, StorePurchaseRequest, StorePurchaseResponse>
    //{
    //    public override StorePurchaseResponse Execute(StorePurchaseRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
