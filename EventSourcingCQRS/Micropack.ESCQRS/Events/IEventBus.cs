namespace Micropack.ESCQRS;

public interface IEventBus
{
    Task Publish<TEvent>(params TEvent[] events) where TEvent : IEvent;
}

public class EventBus : IEventBus
{
    private readonly IMediator _mediator;
    private readonly IPublisher publisher;

    public EventBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Publish<TEvent>(params TEvent[] events) where TEvent : IEvent
    {
        foreach (var @event in events)
        {
            await _mediator.Publish(@event);


        }
    }
}
