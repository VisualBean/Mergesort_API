// <copyright file="Execution.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;

    public class Execution
    {
        public int Id { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public int Duration { get; set; }

        public Status Status { get; set; }

        public int[] Input { get; set; }

        public int[] Output { get; set; }
    }

    public enum Status
    {
        Pending,
        Completed
    }
}
