using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PoliceDepartment.V1.Controllers
{

    [ApiController]
    [Route("v1/criminal-code")]

    public class CriminalCodeController : AuthorizedController
    {
        private readonly IQueryableDatabaseService<CriminalCode> _service;

        public CriminalCodeController(IQueryableDatabaseService<CriminalCode> service)
        {
            _service = service;
        }

        /// <summary>
        /// Searches for a criminal code
        /// </summary>
        /// <param name="id">Criminal code Id</param>
        /// <returns>A single criminal code</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest(id);
            }

            var entity = await _service.GetAsync(id);
            if (entity == null)
            {
                return NotFound(id);
            }

            return Ok(entity);
        }

        /// <summary>
        /// Searches for a criminal code
        /// </summary>
        /// <returns>List of criminal codes</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<CriminalCode>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Search(ODataQueryOptions<CriminalCode> options)
        {
            var entities = _service.Search(options.ApplyTo);
            return Ok(entities);
        }

        /// <summary>
        /// Creates a brand new Criminal Code
        /// </summary>
        /// <param name="entity">Criminal Code entity</param>
        /// <returns>A new Criminal Code entity</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CriminalCode), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([CustomizeValidator(RuleSet = "CreateOrEdit")] CriminalCode entity)
        {
            entity.CreateUserId = entity.UpdateUserId = CurrentUser.Id;
            entity = await _service.AddAndSaveAsync(entity);
            return Ok(entity);
        }

        /// <summary>
        /// Updates an existant criminal code
        /// </summary>
        /// <param name="id">Id of criminal code to update</param>
        /// <param name="entity">Criminal code with updates</param>
        /// <returns>The updated criminal code</returns>
        [HttpPut("{id}")]
        [HttpPost("edit/{id}")]
        [ProducesResponseType(typeof(CriminalCode), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Edit([CustomizeValidator(RuleSet = "CriminalCodeExists")] int id, [CustomizeValidator(RuleSet = "CreateOrEdit")] CriminalCode entity)
        {
            entity.Id = id;
            entity.UpdateUserId = CurrentUser.Id;
            entity = await _service.UpdateAndSaveAsync(entity);
            return Ok(entity);
        }

        /// <summary>
        /// Deletes a single criminal code
        /// </summary>
        /// <param name="id">Criminal code id</param>
        [HttpDelete("{id}")]
        [HttpPost("delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([CustomizeValidator(RuleSet = "CriminalCodeExists")] int id)
        {
            await _service.DeleteAndSaveAsync(id);
            return Ok();
        }
    }
}
