using System.ComponentModel.DataAnnotations;

namespace Micropack.Abstraction;

public interface IRowVersion
{
    [Timestamp]
    public byte[] RowVersion { get; set; }
}