using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        ValueTask<TEntity> GetAsync(object id);
        Task<TEntity> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetAllAsyncNoTracking();
        Task<IQueryable<TEntity>> GetAllAsyncNoTracking(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task<int> SaveChangesAsync();
    }

}
