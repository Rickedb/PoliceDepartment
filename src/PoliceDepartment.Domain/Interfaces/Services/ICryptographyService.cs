using System;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Interfaces.Services
{
    public interface ICryptographyService 
    {
        Task<string> EncryptAsync(string value);
        Task<string> DecryptAsync(string value);
    }
}
