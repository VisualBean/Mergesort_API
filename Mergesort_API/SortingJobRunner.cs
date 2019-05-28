// <copyright file="ExecutionProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Threading.Tasks;

    public class SortingJobRunner : IJobRunner
    {
        public async Task<Job> Execute(SortingJob job)
        {
            Task.Factory.StartNew(() => {
                job.Run();
            });

            return job;
        }
    }
}