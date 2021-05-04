using PoliceDepartment.Domain.Entities;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string username);
    }
}
