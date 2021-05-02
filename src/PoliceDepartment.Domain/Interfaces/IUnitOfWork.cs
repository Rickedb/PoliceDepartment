using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync();
        Task<int> SaveAndCommitChangesAsync();
        void Commit();
        void Rollback();
    }

}
