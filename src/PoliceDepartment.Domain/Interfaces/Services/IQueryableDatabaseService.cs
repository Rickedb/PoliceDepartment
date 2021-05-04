using System;
using System.Linq;

namespace PoliceDepartment.Domain.Interfaces.Services
{
    public interface IQueryableDatabaseService<TEntity> : IDatabaseService<TEntity> where TEntity : class
    {
        IQueryable Search(Func<IQueryable, IQueryable> func);
    }
}
