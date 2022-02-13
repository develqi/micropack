using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Micropack.ESCQRS
{
    public interface IEventStore
    {
        Task<Unit> Store<TCommand>(EventTypes eventType, TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}
