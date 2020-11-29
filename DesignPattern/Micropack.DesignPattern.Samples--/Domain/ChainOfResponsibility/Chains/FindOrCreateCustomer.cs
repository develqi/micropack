
namespace Micropack.DesignPattern.Domain.ChainOfResponsibility.Chains
{
    public interface ICustomerService
    {
        void Create();
    }

    public class FindOrCreateCustomer : StorePurchaseContext
    {
        private readonly ICustomerService _customerService;

        public string Name { get; set; }

        public FindOrCreateCustomer(StorePurchaseContext next, ICustomerService customerService) : base(next)
        {
            _customerService = customerService;
        }

        public override StorePurchaseResponse Execute(StorePurchaseRequest request)
        {
            _customerService.Create();
            return _next.Execute(request);
        }
    }
}
