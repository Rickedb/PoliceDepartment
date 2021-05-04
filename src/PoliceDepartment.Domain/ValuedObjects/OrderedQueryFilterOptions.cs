using System;
using System.Linq.Expressions;

namespace PoliceDepartment.Domain.ValuedObjects
{
    public class OrderedQueryFilterOptions<TEntity, TOrderPropertyType> : QueryFilterOptions<TEntity>
    {
        public Expression<Func<TEntity, TOrderPropertyType>> OrderColumn { get; set; }
        public bool OrderByDescending { get; set; }

        public OrderedQueryFilterOptions(TEntity entity, bool orderByDescending = false, int offset = 0, int limit = 1000) : base(entity, offset, limit)
        {
            OrderByDescending = orderByDescending;
        }

        public OrderedQueryFilterOptions(TEntity entity, Expression<Func<TEntity, TOrderPropertyType>> orderColumn = default, bool orderByDescending = false, int offset = 0, int limit = 1000) 
            : this(entity, orderByDescending, offset, limit)
        {
            OrderColumn = orderColumn;
        }

        public OrderedQueryFilterOptions(QueryFilterOptions<TEntity> options, Expression<Func<TEntity, TOrderPropertyType>> orderColumn = default, bool orderByDescending = false) 
            : this(options.Entity, orderColumn, orderByDescending, options.Offset, options.Limit)
        {
        }
    }
}
