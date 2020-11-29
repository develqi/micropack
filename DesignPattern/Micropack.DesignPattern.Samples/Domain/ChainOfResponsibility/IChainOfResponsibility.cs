
//namespace Micropack.DesignPattern.Samples.ChainOfResponsibility
//{
//    public interface IChainOfResponsibility<TContext, TRequest, TResponse> 
//        where TContext : class
//        where TRequest : class
//        where TResponse : class
//    {
//        //readonly TContext _successor;

//        ////public StorePurchaseContext(TContext context)
//        ////{
//        ////    _successor = storePurchaseContext;
//        ////}

//        //TResponse Execute(TRequest request);
//    }

//    public abstract class ChainOfResponsibiliti<TContext, TRequest, TResponse>
//       where TContext : class
//       where TRequest : class
//       where TResponse : class
//    {
//        protected readonly TContext _successor;

//        public ChainOfResponsibiliti(TContext context)
//        {
//            _successor = context;
//        }

//        public abstract TResponse Execute(TRequest request);
//    }
//}
