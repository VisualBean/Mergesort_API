// <copyright file="ExecutionProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class InMemoryJobStore : IStorageProvider<int, SortingJob>
    {
        private static readonly Dictionary<int, SortingJob> Jobs = new Dictionary<int, SortingJob>();

        public async Task<IEnumerable<SortingJob>> GetAll()
        {
            return await Task.FromResult(Jobs.Values);
        }

        public async Task<SortingJob> GetById(int Id)
        {
            Jobs.TryGetValue(Id, out SortingJob job);
            return await Task.FromResult(job);
        }

        public async Task Save(int key, SortingJob item)
        {
            if (key <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "Key must be greater than or equal to 1.");
            }

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Job cannot be null.");
            }

            Jobs.Add(key, item);
        }
    }
}