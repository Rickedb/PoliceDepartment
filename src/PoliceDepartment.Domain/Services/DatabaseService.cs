using PoliceDepartment.Domain.Interfaces.Repositories;
using PoliceDepartment.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Services
{
    public class DatabaseService<TEntity> : IDatabaseService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> Repository;

        public DatabaseService(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity) => Repository.AddAsync(entity);

        public virtual async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities)
        {
            var dbEntities = new Collection<TEntity>();
            foreach (var entity in entities)
            {
                dbEntities.Add(await AddAsync(entity));
            }

            return dbEntities;
        }

        public virtual async Task<TEntity> AddAndSaveAsync(TEntity entity)
        {
            entity = await AddAsync(entity);
            _ = await SaveChangesAsync();
            return entity;
        }

        public virtual Task DeleteAsync(TEntity entity) => Repository.DeleteAsync(entity);

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await Repository.GetAsync(id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await DeleteAsync(entity);
            }
        }

        public virtual async Task<bool> DeleteAndSaveAsync(TEntity entity)
        {
            await Repository.DeleteAsync(entity);
            return await SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAndSaveAsync(object id)
        {
            var entity = await Repository.GetAsync(id);
            return await DeleteAndSaveAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsyncNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.GetAllAsyncNoTracking(predicate);
        }

        public virtual ValueTask<TEntity> GetAsync(object id) => Repository.GetAsync(id);

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) => Repository.GetAsNoTrackingAsync(predicate);

        public virtual Task<TEntity> UpdateAsync(TEntity entity) => Repository.UpdateAsync(entity);

        public virtual async Task<TEntity> UpdateAndSaveAsync(TEntity entity)
        {
            entity = await UpdateAsync(entity);
            _ = await SaveChangesAsync();
            return entity;
        }

        public virtual Task<int> SaveChangesAsync() => Repository.SaveChangesAsync();

        public void Dispose()
        {
            if (Repository != null)
            {
                Repository.Dispose();
            }
        }
    }

}
