using MediatR;

namespace Micropack.ESCQRS
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {

    }
}
