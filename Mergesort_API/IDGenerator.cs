// <copyright file="IDGenerator.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Threading;

    /// <summary>
    /// The ID Generator.
    /// </summary>
    public static class IDGenerator
    {
        /// <summary>
        /// The current identifier.
        /// </summary>
        private static int currentID = 0;

        /// <summary>
        /// Generates the new identifier.
        /// </summary>
        /// <returns>A <see cref="int"/></returns>
        public static int GenerateNewId()
        {
            return Interlocked.Increment(ref currentID);
        }
    }
}
