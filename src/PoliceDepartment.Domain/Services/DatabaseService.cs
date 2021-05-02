using Microsoft.VisualBasic;
using PoliceDepartment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Services
{
    public class DatabaseService<TEntity> : IDatabaseService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;

        public DatabaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity) => _repository.AddAsync(entity);

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

        public virtual Task DeleteAsync(TEntity entity) => _repository.DeleteAsync(entity);

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await _repository.GetAsync(id);
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
            await _repository.DeleteAsync(entity);
            return await SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAndSaveAsync(object id)
        {
            var entity = await _repository.GetAsync(id);
            return await DeleteAndSaveAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsyncNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAllAsyncNoTracking(predicate);
        }

        public virtual Task<TEntity> GetAsync(object id) => _repository.GetAsync(id);

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) => _repository.GetAsNoTrackingAsync(predicate);

        public virtual Task<TEntity> UpdateAsync(TEntity entity) => _repository.UpdateAsync(entity);

        public virtual async Task<TEntity> UpdateAndSaveAsync(TEntity entity)
        {
            entity = await UpdateAsync(entity);
            _ = await SaveChangesAsync();
            return entity;
        }

        public virtual Task<int> SaveChangesAsync() => _repository.SaveChangesAsync();

        public void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
            }
        }
    }

}
