// <copyright file="ExecutionProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class SortingJobRunner : IJobRunner
    {
        private readonly ILogger logger;

        public SortingJobRunner(ILogger<SortingJobRunner> logger)
        {
            this.logger = logger;
        }

        public async Task Execute(SortingJob job, CancellationToken cancellationToken = default(CancellationToken))
        {
            Task.Run(
                () => {
                this.logger.LogInformation("Beginning execution of job:{0}", job.Id);
                job.Run();
            }, cancellationToken);
        }
    }
}