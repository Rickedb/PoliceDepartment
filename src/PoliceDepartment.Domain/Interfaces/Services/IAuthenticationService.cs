using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.ValuedObjects;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUser> Authenticate(User user);
    }
}
