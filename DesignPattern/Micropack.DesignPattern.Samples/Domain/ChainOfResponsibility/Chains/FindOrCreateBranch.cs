
namespace Micropack.DesignPattern.Samples.ChainOfResponsibility.Chains
{
    public interface ITillService
    {
        void Create();
    }

    public class FindOrCreateBranch : StorePurchaseContext
    {
        private readonly ITillService _tillService;

        public string Name { get; set; }

        public FindOrCreateBranch(StorePurchaseContext next, ITillService tillService) : base(next)
        {
            _tillService = tillService;
        }

        public override StorePurchaseResponse Execute(StorePurchaseRequest request)
        {
            _tillService.Create();
            return _next.Execute(request);
        }
    }
}
