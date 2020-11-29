using System;

namespace Micropack.Domain.Abstraction
{
    public interface IOwner
    {
        Guid OwnerId { get; set; }
    }
}