
namespace Micropack.DesignPattern.Domain.ChainOfResponsibility.Chains
{
    public interface IBranchService
    {
        void Create();
    }

    public class FindOrCreateTill : StorePurchaseContext
    {
        private readonly IBranchService _branchService;

        public string Name { get; set; }

        public FindOrCreateTill(StorePurchaseContext next, IBranchService branchService) : base(next)
        {
            _branchService = branchService;
        }

        public override StorePurchaseResponse Execute(StorePurchaseRequest request)
        {
            _branchService.Create();
            return _next.Execute(request);
        }
    }
}
