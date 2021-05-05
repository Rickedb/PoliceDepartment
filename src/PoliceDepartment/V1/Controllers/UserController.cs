using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Services;
using System.Net;
using System.Threading.Tasks;

namespace PoliceDepartment.V1.Controllers
{
    [Authorize]
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
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Auth([CustomizeValidator(RuleSet = "Authenticate")] User user)
        {
            var authenticatedUser = await _authenticationService.Authenticate(user);
            if(authenticatedUser == null)
            {
                return Unauthorized(user);
            }

            return Ok(authenticatedUser);
        }

        /// <summary>
        /// Creates a new user (Used only for testing purposes)
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User with token</returns>
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            user = await _userService.AddAndSaveAsync(user);
            user.Password = string.Empty;
            return Ok(user);
        }
    }
}
