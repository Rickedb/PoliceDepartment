using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace PoliceDepartment.V1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseService<User> _userService;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IDatabaseService<User> userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Login to CriminalCode api
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User with token</returns>
        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Auth(User user)
        {
            var authenticatedUser = await _authenticationService.Authenticate(user);
            if(authenticatedUser == null)
            {
                return Unauthorized(user);
            }

            return Ok(authenticatedUser);
        }

        /// <summary>
        /// Creates an User
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User with token</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(User user)
        {
            user = await _userService.AddAndSaveAsync(user);
            user.Password = string.Empty;
            return Ok(user);
        }
    }
}
