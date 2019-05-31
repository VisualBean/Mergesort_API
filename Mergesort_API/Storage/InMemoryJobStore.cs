// <copyright file="InMemoryJobStore.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class InMemoryJobStore : IStorageProvider<int, SortingJob>
    {
        private static readonly ConcurrentDictionary<int, SortingJob> Jobs = new ConcurrentDictionary<int, SortingJob>();

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

            if (!Jobs.TryAdd(key, item))
            {
                 throw new ArgumentException("Key already exists.");
            }
        }
    }
}