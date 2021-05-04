namespace PoliceDepartment.Domain.ValuedObjects
{
    public class QueryFilterOptions<TEntity>
    {
        public TEntity Entity { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }

        public QueryFilterOptions(TEntity entity, int offset = 0, int limit = 1000)
        {
            Entity = entity;
            Offset = offset;
            Limit = limit;
        }
    }
}
