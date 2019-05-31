// <copyright file="IDGenerator.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System.Threading;

    public static class IDGenerator
    {
        private static int currentID = 0;

        public static int GenerateNewId()
        {
            return Interlocked.Increment(ref currentID);
        }
    }
}
