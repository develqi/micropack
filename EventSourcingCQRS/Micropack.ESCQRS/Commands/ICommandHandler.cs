using MediatR;

namespace Micropack.ESCQRS
{
    public interface ICommandHandler<in T> : IRequestHandler<T> where T : ICommand
    {

    }
}
