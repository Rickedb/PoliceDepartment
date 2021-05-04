using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Interfaces.Services
{
    public interface IDatabaseService<TEntity> : IDisposable where TEntity : class
    {
        ValueTask<TEntity> GetAsync(object id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities);
        Task<TEntity> AddAndSaveAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> UpdateAndSaveAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(IEnumerable<TEntity> entity);
        Task<bool> DeleteAndSaveAsync(object id);
        Task<bool> DeleteAndSaveAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }

}
