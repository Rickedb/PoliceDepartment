using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Domain.Interfaces.Repositories;
using System.Linq;

namespace PoliceDepartment.Data.Repositories
{
    public class QueryableRepository<TEntity> : Repository<TEntity>, IQueryableRepository<TEntity> where TEntity : class
    {
        public QueryableRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<TEntity> Search()
        {
            return Context.Set<TEntity>();
        }
    }
}
