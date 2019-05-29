// <copyright file="MergesortController.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MergesortController : ControllerBase
    {
        private static readonly ISorter<int> Sorter = new MergeSorter();
        private readonly IJobRunner runner;
        private readonly IStorageProvider<Guid, SortingJob> jobStore;

        public MergesortController(IJobRunner runner, IStorageProvider<Guid, SortingJob> jobStore)
        {
            this.runner = runner;
            this.jobStore = jobStore;
        }

        /// <summary>
        /// Mergesort sorting an array.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        [HttpPost]
        [ProducesResponseType(typeof(Job), 201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SortArray([FromBody] int[] numbers)
        {
            var job = new SortingJob(Sorter, numbers);

            await this.jobStore.Store(job.Id, job);
            await this.runner.Execute(job);

            return this.Accepted(new { job.Id, job.Timestamp, job.Status });
        }

        /// <summary>
        /// Gets the executions by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200">Execution found.</response>
        /// <response code="400">Bad id.</response>
        /// <response code="404">Execution not found.</response>
        [HttpGet("Executions/{id}")]
        [ProducesResponseType(typeof(SortingJob), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetExecutionsById(Guid id)
        {
            var job = await this.jobStore.Retreive(id);
            if (job == null)
            {
                return this.NotFound();
            }

            return this.Ok(job);
        }

        /// <summary>
        /// Gets all executions.
        /// </summary>
        /// <response code="200">Executions found.</response>
        /// <response code="404">No executions found.</response>
        [HttpGet("Executions")]
        [ProducesResponseType(typeof(IEnumerable<Job>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetExecutions()
        {
            var jobs = await this.jobStore.GetAll();
            if (jobs.Any())
            {
                 return this.Ok(jobs.Select(job => new { job.Id, job.Timestamp, job.Status }));
            }

            return this.NotFound();
        }

    }
}
