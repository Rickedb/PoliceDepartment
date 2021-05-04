using PoliceDepartment.Domain.Interfaces.Repositories;
using PoliceDepartment.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace PoliceDepartment.Domain.Services
{
    public class QueryableDatabaseService<TEntity> : DatabaseService<TEntity>, IQueryableDatabaseService<TEntity> where TEntity : class
    {
        private new IQueryableRepository<TEntity> Repository { get => (IQueryableRepository<TEntity>)base.Repository; }

        public QueryableDatabaseService(IQueryableRepository<TEntity> repository) : base(repository)
        {
        }

        public IQueryable Search(Func<IQueryable, IQueryable> func)
        {
            var entities = Repository.Search();
            return func(entities);
        }
    }
}
