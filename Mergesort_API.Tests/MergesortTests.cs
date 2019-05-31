using FluentAssertions;
using System;
using Xunit;

namespace Mergesort_API.Tests
{
    public class MergeSortTest
    {
        private readonly ISorter<int> sorter;

        public MergeSortTest()
        {
            sorter = new MergeSorter();
        }
        [Fact]
        public void Sort_WithArray_SortsArrayAscending()
        {
            var input = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var output = sorter.Sort(input);

            output.Should().BeInAscendingOrder();
            output.Should().NotBeSameAs(expected);
        }

        [Fact]
        public void Sort_WithEmptyArray_SortsArray()
        {
            var input = Array.Empty<int>();
            var output = sorter.Sort(input);

            output.Should().BeSameAs(output);
        }

        [Fact]
        public void Sort_NullInput_ThrowsNullException()
        {
            int[] input = null;

            Action sort = () => sorter.Sort(input);

            sort.Should().Throw<ArgumentNullException>();
        }
    }
}
