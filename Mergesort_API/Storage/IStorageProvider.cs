// <copyright file="IStorageProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The storageprovider interface.
    /// </summary>
    /// <typeparam name="TKey">The Key type.</typeparam>
    /// <typeparam name="TItem">The stored item type.</typeparam>
    public interface IStorageProvider<TKey, TItem>
    {
        /// <summary>
        /// Saves the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns>A Task.</returns>
        Task Save(TKey key, TItem item);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task.</returns>
        Task<TItem> GetById(TKey id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/>.</returns>
        Task<IEnumerable<TItem>> GetAll();
    }
}
