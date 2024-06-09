using MediatR;

namespace Micropack.ESCQRS;

public interface ICommandHandler<in T> : IRequestHandler<T> where T : ICommand
{

}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : class
{

}