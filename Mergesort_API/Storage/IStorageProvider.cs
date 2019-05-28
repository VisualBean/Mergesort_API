﻿// <copyright file="IStorageProvider.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStorageProvider<K, T>
    {
        Task Store(K key, T item);

        Task<T> Retreive(K Id);

        Task<IEnumerable<T>> GetAll();
    }
}