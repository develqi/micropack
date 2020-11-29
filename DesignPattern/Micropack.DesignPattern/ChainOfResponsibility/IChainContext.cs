using System.Threading.Tasks;

namespace Micropack.DesignPattern.ChainOfResponsibility
{
    //public interface IChainContext
    //{
    //    protected readonly IChainContext _next;

    //    public StorePurchaseContext(IChainContext next) => _next = next;

    //    public abstract Task<StorePurchaseResponse> Execute(StorePurchaseRequest request);
    //}

    public abstract class ChainContext
    {
        protected readonly ChainContext _next;
        protected readonly ChainContext _previous;

        public ChainContext(ChainContext next, ChainContext previous)
        {
            _next = next;
            _previous = previous;
        }

        public abstract IChainResponse Execute(IChainRequest request);

        public abstract Task<IChainResponse> ExecuteAsync(IChainRequest request);
    }
}
