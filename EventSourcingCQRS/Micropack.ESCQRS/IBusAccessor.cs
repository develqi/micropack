namespace Micropack.ESCQRS;

public interface IBusAccessor
{
    IQueryBus QueryBus { get; }

    ICommandBus CommandBus { get; }
}

public class BusAccessor : IBusAccessor
{
    private readonly Lazy<IQueryBus> _queryBus;
    private readonly Lazy<ICommandBus> _commandBus;

    public BusAccessor(Lazy<ICommandBus> commandBus, Lazy<IQueryBus> queryBus)
    {
        _queryBus = queryBus;
        _commandBus = commandBus;
    }

    public IQueryBus QueryBus => _queryBus.Value;

    public ICommandBus CommandBus => _commandBus.Value;
}
