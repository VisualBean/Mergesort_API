﻿// <copyright file="JobRunner.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Threading.Tasks;

    public interface IJobRunner
    {
        Task<Job> Execute(SortingJob job);
    }
}