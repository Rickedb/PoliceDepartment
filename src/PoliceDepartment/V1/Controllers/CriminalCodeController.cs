using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceDepartment.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]

    public class CriminalCodeController : ControllerBase
    {
        private readonly ILogger<CriminalCodeController> _logger;

        public CriminalCodeController(ILogger<CriminalCodeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Searches for a criminal code by its Id
        /// </summary>
        /// <returns>A single criminal code</returns>
        [HttpGet("{id}")]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Searches for a criminal code
        /// </summary>
        /// <returns>List of criminal codes</returns>
        [HttpGet("search")]
        public IActionResult Search()
        {
            return Ok();
        }

        [HttpPost]
        [HttpPost("add")]
        public IActionResult Add(CriminalCode criminalCode)
        {
            return Ok();
        }

        [HttpPatch()]
        [HttpPatch("edit")]
        [HttpPost("edit")]
        public IActionResult Edit(CriminalCode criminalCode)
        {
            return Ok();
        }

        [HttpDelete()]
        [HttpDelete("delete")]
        [HttpPost("delete")]
        public IActionResult Delete(CriminalCode criminalCode)
        {
            return Ok();
        }
    }
}
