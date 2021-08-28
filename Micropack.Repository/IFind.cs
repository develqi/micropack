//using Micropack.Domain.Abstraction;

//namespace Micropack.Repository
//{
//    public interface IFind
//    {
//        ICommit Delete();

//        ICommit Replace<TDestination>(TDestination destination) where TDestination : class, new();

//        ICommit PartialUpdate<T>(bool isActive) where T : class, IActivable;

//        ICommit PartialUpdate<T>(bool isActive, string deactiveReason) where T : class, IActivableWithReason;

//        ICommit UpdateDetails<T, TDetails>(TDetails details) where T : class where TDetails : class, new();
//    }
//}
