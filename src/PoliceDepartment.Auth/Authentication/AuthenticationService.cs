using Microsoft.IdentityModel.Tokens;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Repositories;
using PoliceDepartment.Domain.Interfaces.Services;
using PoliceDepartment.Domain.ValuedObjects;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PoliceDepartment.Auth.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly AuthenticationOptions _options;

        public AuthenticationService(IUserRepository userRepository, ICryptographyService cryptographyService, AuthenticationOptions options)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
            _options = options;
        }

        public async Task<AuthenticatedUser> Authenticate(User user)
        {
            var dbUser = await _userRepository.GetAsync(user.Username);
            var decryptedPassword = await _cryptographyService.DecryptAsync(dbUser.Password);
            if(user.Password == decryptedPassword)
            {
                var token = GenerateJwtToken(dbUser);
                return new AuthenticatedUser()
                {
                    Username = user.Username,
                    Token = token,
                    ExpiresIn = _options.TotalMinutesOfValidToken
                };
            }

            return default;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_options.TotalMinutesOfValidToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
