// <copyright file="InMemoryJobStore.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The In memory job store.
    /// </summary>
    /// <seealso cref="Mergesort_API.IStorageProvider{int, Mergesort_API.SortingJob}" />
    public class InMemoryJobStore : IStorageProvider<int, SortingJob>
    {
        /// <summary>
        /// The memory storage.
        /// </summary>
        private static readonly ConcurrentDictionary<int, SortingJob> Jobs = new ConcurrentDictionary<int, SortingJob>();
        private readonly ILogger<InMemoryJobStore> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryJobStore"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public InMemoryJobStore(ILogger<InMemoryJobStore> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>A List of <see cref="SortingJob"/></returns>
        public async Task<IEnumerable<SortingJob>> GetAll()
        {
            return await Task.FromResult(Jobs.Values);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="SortingJob"/></returns>
        public async Task<SortingJob> GetById(int id)
        {
            if (!Jobs.TryGetValue(id, out SortingJob job))
            {
                this.logger.LogWarning($"Job with id: {id} not found.");
            }

            return await Task.FromResult(job);
        }

        /// <summary>
        /// Saves the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns>A Task.</returns>
        /// <exception cref="ArgumentOutOfRangeException">key - Key must be greater than or equal to 1.</exception>
        /// <exception cref="ArgumentNullException">item - Job cannot be null.</exception>
        /// <exception cref="ArgumentException">Key already exists.</exception>
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

            this.logger.LogInformation("Saved job with id {0}", key);
        }
    }
}