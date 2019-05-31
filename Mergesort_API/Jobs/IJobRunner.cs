// <copyright file="IJobRunner.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The jobrunner interface.
    /// </summary>
    public interface IJobRunner
    {
        /// <summary>
        /// Executes the specified job.
        /// </summary>
        /// <param name="job">The job.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        Task Execute(SortingJob job,  CancellationToken cancellationToken = default(CancellationToken));
    }
}