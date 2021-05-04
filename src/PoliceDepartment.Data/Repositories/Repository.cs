using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoliceDepartment.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await Context.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities)
        {
            var added = new List<TEntity>();
            foreach (var entity in entities)
            {
                added.Add(await AddAsync(entity));
            }

            return added;
        }

        public virtual ValueTask<TEntity> GetAsync(object id)
        {
            return Context.FindAsync<TEntity>(id);
        }

        public virtual Task<TEntity> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Context.Set<TEntity>().AsNoTracking();
            return entities.FirstOrDefaultAsync(predicate);
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() =>
            {
                var entities = Context.Set<TEntity>();
                return entities.Where(predicate).AsQueryable();
            });
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsyncNoTracking()
        {
            return Task.Run(() =>
            {
                var entities = Context.Set<TEntity>().AsNoTracking();
                return entities;
            });
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsyncNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() =>
            {
                var entities = Context.Set<TEntity>().AsNoTracking();
                return entities.Where(predicate).AsQueryable();
            });
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.Run(() =>
            {
                var entry = Context.Update(entity);
                return entry.Entity;
            });
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() => Context.Remove(entity));
        }

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await Context.FindAsync<TEntity>(id);
            await Task.Run(() => Context.Remove(entity));
        }

        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }

}
