// <copyright file="Execution.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;

    /// <summary>
    /// A sorting job.
    /// </summary>
    /// <seealso cref="Job" />
    public class SortingJob : Job
    {
        /// <summary>
        /// The sorter to be used for sorting.
        /// </summary>
        private readonly ISorter<int> sorter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingJob"/> class.
        /// </summary>
        /// <param name="sorter">The sorter.</param>
        /// <param name="input">The input.</param>
        public SortingJob(ISorter<int> sorter, int[] input)
        {
            this.sorter = sorter ?? throw new ArgumentNullException(nameof(sorter), "Sorter cannot be null.");
            this.Input = input ?? throw new ArgumentNullException(nameof(input), "Array cannot be null.");
        }

        /// <summary>
        /// Work that is to be done as part of the job execution.
        /// </summary>
        public override void Work()
        {
            this.Output = this.sorter.Sort(this.Input);
            this.Duration = DateTime.UtcNow - this.Timestamp;
        }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public int[] Input { get; private set; }

        /// <summary>
        /// Gets or sets the output.
        /// </summary>
        /// <value>
        /// The output.
        /// </value>
        public int[] Output { get; private set; }

    }
}
