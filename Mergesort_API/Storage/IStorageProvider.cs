// <copyright file="IStorageProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The storageprovider interface
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IStorageProvider<K, T>
    {
        /// <summary>
        /// Saves the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns>A Task.</returns>
        Task Save(K key, T item);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>A <see cref="{T}"/>.</returns>
        Task<T> GetById(K Id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>A List of <see cref="{T}"/></returns>
        Task<IEnumerable<T>> GetAll();
    }
}
