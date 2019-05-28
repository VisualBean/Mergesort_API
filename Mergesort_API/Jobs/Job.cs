// <copyright file="Execution.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// A job.
    /// </summary>
    public abstract class Job
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        public Job()
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.UtcNow;
            this.Status = Status.Pending;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; private set; }

        /// <summary>
        /// The work that has to be done as part of the execution.
        /// </summary>
        public abstract void Work();

        /// <summary>
        /// run this instance.
        /// </summary>
        public void Run()
        {
            this.Work();
            this.Status = Status.Completed;
        }
    }
}
