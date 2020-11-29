
namespace Micropack.Domain.Abstraction
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}