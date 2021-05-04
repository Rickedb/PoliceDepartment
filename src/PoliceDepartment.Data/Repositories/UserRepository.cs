using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Data.Contexts;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace PoliceDepartment.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly PoliceDepartmentContext _policeDepartmentContext;

        public UserRepository(PoliceDepartmentContext context) : base(context)
        {
            _policeDepartmentContext = context;
        }

        public Task<User> GetAsync(string username)
        {
            return _policeDepartmentContext.Users.FirstOrDefaultAsync(x => x.Username == username);   
        }
    }
}
