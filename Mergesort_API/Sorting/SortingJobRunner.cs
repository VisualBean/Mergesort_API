// <copyright file="ExecutionProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The Sorting Job Runner
    /// </summary>
    /// <seealso cref="Mergesort_API.IJobRunner" />
    public class SortingJobRunner : IJobRunner
    {
        private readonly ILogger logger;

        public SortingJobRunner(ILogger<SortingJobRunner> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Executes the specified job.
        /// </summary>
        /// <param name="job">The job.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        public async Task Execute(SortingJob job, CancellationToken cancellationToken = default(CancellationToken))
        {
            Task.Run(
                () =>
                {
                this.logger.LogInformation("Beginning execution of job:{0}", job.Id);
                job.Run();
            }, cancellationToken);
        }
    }
}