// <copyright file="MergesortController.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MergesortController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        /// <summary>
        /// Gets the executions by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200">Execution found.</response>
        /// <response code="400">Bad id.</response>
        /// <response code="404">Execution not found.</response>
        [HttpGet("Executions/{id}")]
        [ProducesResponseType(typeof(Execution),200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetExecutionsById(int id)
        {
            return Ok(new string[] { "value1", "value2" });
        }

        /// <summary>
        /// Gets all executions.
        /// </summary>
        /// <response code="200">Executions found.</response>
        /// <response code="404">No executions found.</response>
        [HttpGet("Executions")]
        [ProducesResponseType(typeof(IEnumerable<Execution>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetExecutions()
        {
            return Ok(new string[] { "value1", "value2" });
        }

    }
}
