// <copyright file="MergeSorter.cs" company="Alexander Steinhauer-Wichmann">
// Copyright (c) Alexander Steinhauer-Wichmann. All rights reserved.
// </copyright>

namespace Mergesort_API
{
    using System;

    /// <summary>
    /// A MergeSorter.
    /// </summary>
    /// <seealso cref="Mergesort_API.ISorter{T}" />
    public class MergeSorter : ISorter<int>
    {
        /// <summary>
        /// Sorts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A sorted integer array.</returns>
        /// <exception cref="ArgumentNullException">input - Cannot be null.</exception>
        public int[] Sort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Cannot be null");
            }

            var numbers = (int[])input.Clone();
            this.MergeSort(numbers, 0, numbers.Length - 1);
            return numbers;
        }

        /// <summary>
        /// Merges the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="left">The left.</param>
        /// <param name="middle">The middle.</param>
        /// <param name="right">The right.</param>
        private void Merge(int[] input, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }

        /// <summary>
        /// Merges the sort.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        private void MergeSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                this.MergeSort(input, left, middle);
                this.MergeSort(input, middle + 1, right);

                this.Merge(input, left, middle, right);
            }
        }
    }
}
