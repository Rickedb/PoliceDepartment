using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Repositories;
using PoliceDepartment.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Services
{
    public class UserService : DatabaseService<User>
    {
        private readonly ICryptographyService _cryptographyService;

        public UserService(IUserRepository repository, ICryptographyService cryptographyService) : base(repository)
        {
            _cryptographyService = cryptographyService;
        }

        public override async Task<User> AddAsync(User entity)
        {
            entity.Password = await _cryptographyService.EncryptAsync(entity.Password);
            return await base.AddAsync(entity);
        }
    }
}
