using MediatR;
using System.Threading.Tasks;

namespace Micropack.ESCQRS
{
    public interface IQueryBus
    {
        Task<TResponse> Send<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;

        Task<TResponse> SendPagination<TPaginationQuery, TResponse>(TPaginationQuery query) 
            where TPaginationQuery : PaginationQuery<TResponse>
            where TResponse : class;
    }

    public class QueryBus : IQueryBus
    {
        private readonly IMediator _mediator;
        
        public QueryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> Send<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
        {
            return _mediator.Send(query);
        }

        public Task<TResponse> SendPagination<TPaginationQuery, TResponse>(TPaginationQuery query)
            where TPaginationQuery : PaginationQuery<TResponse>
            where TResponse : class
        {
            return _mediator.Send(query);
        }
    }
}
