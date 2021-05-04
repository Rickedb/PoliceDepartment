using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Domain.Entities;
using System;
using System.Linq;
using System.Security.Claims;

namespace PoliceDepartment.V1.Controllers
{
    [Authorize]
    public class AuthorizedController : ControllerBase
    {
        private User _user;

        public User CurrentUser
        {
            get
            {
                if (_user == default)
                {
                    _user = new User()
                    {
                        Id = Guid.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value),
                        Username = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Name).Value
                    };
                }
                return _user;
            }
        }

    }
}
