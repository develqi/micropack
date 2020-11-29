using MediatR;

namespace Micropack.ESCQRS
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {

    }
}
