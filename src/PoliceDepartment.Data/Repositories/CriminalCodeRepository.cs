using PoliceDepartment.Data.Contexts;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Repositories;
using System.Linq;

namespace PoliceDepartment.Data.Repositories
{
    public class CriminalCodeRepository : Repository<CriminalCode>, IQueryableRepository<CriminalCode>
    {
        private new PoliceDepartmentContext Context { get => (PoliceDepartmentContext)base.Context; }

        public CriminalCodeRepository(PoliceDepartmentContext context) : base(context)
        {

        }

        public IQueryable<CriminalCode> Search()
        {
            return Context.CriminalCodes.AsQueryable();
        }
    }
}
