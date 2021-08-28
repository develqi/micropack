using Micropack.Domain.Abstraction;
using System.Threading;
using System.Threading.Tasks;

namespace Micropack.Repository
{
    public interface ICodeGenerator
    {
        Task<ICommit> GenerateCodeAsync<T>(CancellationToken cancellationToken) where T : class, IEntityNumeric, IUniqueCode;
    }
}
