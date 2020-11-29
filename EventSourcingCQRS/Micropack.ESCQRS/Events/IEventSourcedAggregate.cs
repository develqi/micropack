using System;
using System.Collections.Generic;

namespace Micropack.ESCQRS
{
    public interface IEventSourcedAggregate
    {
        Guid Id { get; }

        Queue<IEvent> PendingEvents { get; }
    }

    public abstract class EventSourcedAggregate: IEventSourcedAggregate
    {
        public Guid Id { get; protected set; }

        public Queue<IEvent> PendingEvents { get; private set; }

        protected EventSourcedAggregate()
        {
            PendingEvents = new Queue<IEvent>();
        }

        protected void Append(IEvent @event)
        {
            PendingEvents.Enqueue(@event);
        }
    }
}
