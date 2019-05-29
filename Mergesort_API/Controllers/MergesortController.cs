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
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MergesortController : ControllerBase
    {
        private static readonly ISorter<int> Sorter = new MergeSorter();
        private readonly IJobRunner runner;
        private readonly IStorageProvider<Guid, SortingJob> jobStore;
        private readonly ILogger logger;

        public MergesortController(IJobRunner runner, IStorageProvider<Guid, SortingJob> jobStore, ILogger<MergesortController> logger)
        {
            this.runner = runner;
            this.jobStore = jobStore;
            this.logger = logger;
        }

        /// <summary>
        /// Mergesort sorting an array.
        /// </summary>
        /// <param name="numbers">The array of integers to sort.</param>
        [HttpPost]
        [ProducesResponseType(typeof(Job), 201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SortArray([FromBody] int[] numbers)
        {
            var job = new SortingJob(Sorter, numbers);

            await this.jobStore.Save(job.Id, job);
            await this.runner.Execute(job);

            return this.Accepted(new { job.Id, job.Timestamp, job.Status });
        }

        /// <summary>
        /// Gets the executions by identifier.
        /// </summary>
        /// <param name="id">The identifier of the job to retrieve.</param>
        /// <response code="200">Execution found.</response>
        /// <response code="404">Execution not found.</response>
        [HttpGet("Executions/{id}")]
        [ProducesResponseType(typeof(SortingJob), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetExecutionsById(Guid id)
        {
            var job = await this.jobStore.GetById(id);
            if (job == null)
            {
                this.logger.LogWarning("Failed to retrieve job for id {0}", id);
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

            this.logger.LogWarning("No jobs found.");
            return this.NotFound();
        }

    }
}
