using MediatR;

namespace Micropack.ESCQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}
