using MediatR;

namespace Micropack.ESCQRS
{
    public interface IPaginationQueryHandler<in TPaginationQuery, TResponse> : IRequestHandler<TPaginationQuery, TResponse>
         where TPaginationQuery : PaginationQuery<TResponse>
         where TResponse : class
    {

    }
}
