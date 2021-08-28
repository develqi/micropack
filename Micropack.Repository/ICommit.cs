using System.Threading;
using System.Threading.Tasks;

namespace Micropack.Repository
{
    public interface ICommit
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAndReturnIdAsync(CancellationToken cancellationToken);
    }
}
