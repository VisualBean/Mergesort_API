// <copyright file="ExecutionProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class InMemoryJobStore : IStorageProvider<Guid, SortingJob>
    {
        private static readonly Dictionary<Guid, SortingJob> Jobs = new Dictionary<Guid, SortingJob>();

        public async Task<IEnumerable<SortingJob>> GetAll()
        {
            return await Task.FromResult(Jobs.Values);
        }

        public async Task<SortingJob> GetById(Guid Id)
        {
            Jobs.TryGetValue(Id, out SortingJob job);
            return await Task.FromResult(job);
        }

        public async Task Save(Guid key, SortingJob item)
        {
            Jobs[key] = item;
            return;
        }
    }
}