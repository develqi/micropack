using MediatR;

namespace Micropack.ESCQRS;

public interface ICommand : IRequest
{

}

public interface ICommand<TResponse> : IRequest<TResponse> where TResponse : class
{

}