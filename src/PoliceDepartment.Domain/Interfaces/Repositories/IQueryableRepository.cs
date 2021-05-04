using System.Linq;

namespace PoliceDepartment.Domain.Interfaces.Repositories
{
    public interface IQueryableRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Search();
    }
}
