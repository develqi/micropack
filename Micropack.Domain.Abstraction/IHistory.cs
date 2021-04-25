using System;

namespace Micropack.Domain.Abstraction
{
    public interface IHistory
    {
        DateTimeOffset CreatedOn { get; set; }

        DateTimeOffset? LastModifiedOn { get; set; }
    }
}