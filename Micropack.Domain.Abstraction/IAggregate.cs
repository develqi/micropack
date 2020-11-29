using System;

namespace Micropack.Domain.Abstraction
{
    public interface IAggregate
    {
        Guid Id { get; }
    }
}