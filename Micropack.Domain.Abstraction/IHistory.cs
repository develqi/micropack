using System;

namespace Micropack.Domain.Abstraction
{
    public interface IHistory
    {
        DateTimeOffset CreatedOn { get; set; }

        DateTimeOffset? ModifiedOn { get; set; }
    }
}