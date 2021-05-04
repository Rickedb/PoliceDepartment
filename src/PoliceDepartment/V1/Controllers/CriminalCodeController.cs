using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Services;
using PoliceDepartment.Domain.ValuedObjects;
using System;
using System.Runtime.CompilerServices;
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
        /// Searches for a criminal code by its Id
        /// </summary>
        /// <returns>A single criminal code</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest(id);
            }

            var entity = await _service.GetAsync(id);
            if(entity == null)
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
        public IActionResult Search(ODataQueryOptions<CriminalCode> options)
        {
            var entities = _service.Search(options.ApplyTo);
            return Ok(entities);
        }

        [HttpPost]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CriminalCode entity)
        {
            entity.CreateUserId = entity.UpdateUserId = CurrentUser.Id;
            entity = await _service.AddAndSaveAsync(entity);
            return Ok(entity);
        }

        [HttpPatch()]
        [HttpPatch("edit")]
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(CriminalCode entity)
        {
            entity.UpdateUserId = CurrentUser.Id;
            entity = await _service.UpdateAndSaveAsync(entity);
            return Ok(entity);
        }

        [HttpDelete()]
        [HttpDelete("delete")]
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(CriminalCode entity)
        {
            await _service.DeleteAndSaveAsync(entity);
            return Ok();
        }
    }
}
