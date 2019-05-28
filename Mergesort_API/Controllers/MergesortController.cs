using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mergesort_API.Controllers
{
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

        [HttpGet("Executions/{id}")]
        public async Task<IActionResult> GetExecutionsById(int id)
        {
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpGet("Executions")]
        public async Task<IActionResult> GetExecutions()
        {
            return Ok(new string[] { "value1", "value2" });
        }

    }
}
