using MediatR;

namespace Micropack.ESCQRS;

public interface ICommandBus
{
    Task Send<TCommand>(TCommand command) where TCommand : ICommand;

    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;

    Task<TCommandResponse> Send<TCommand, TCommandResponse>(TCommand command)
        where TCommand : ICommand<TCommandResponse>
        where TCommandResponse : class;
}

public class CommandBus : ICommandBus
{
    private readonly IMediator _mediator;

    public CommandBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Send<TCommand>(TCommand command) where TCommand : ICommand
        => _mediator.Send(command);

    public Task Send<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
           => _mediator.Send(command, cancellationToken);

    public Task<TCommandResponse> Send<TCommand, TCommandResponse>(TCommand command)
        where TCommand : ICommand<TCommandResponse>
        where TCommandResponse : class
     => _mediator.Send(command);
}
