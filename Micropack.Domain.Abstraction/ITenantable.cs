using System;

namespace Micropack.Domain.Abstraction
{
    public interface ITenantable
    {
        Guid TenantId { get; set; }
    }
}