using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoliceDepartment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace PoliceDepartment.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        /// <summary>
        /// Login to CriminalCode api
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User with token</returns>
        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Auth(User user)
        {
            return Ok();
        }
    }
}
