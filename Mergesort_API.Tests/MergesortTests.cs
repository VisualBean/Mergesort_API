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
        public void Sort_SortsAnArrayAscending()
        {
            var input = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var output = sorter.Sort(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Sort_EmptyInput_DoesNotThrow()
        {
            var input = new int[0];

            var output = sorter.Sort(input);

            Assert.True(true);
        }

        [Fact]
        public void Sort_NullInput_ThrowsNullException()
        {
            int[] input = null;

            Assert.Throws<ArgumentNullException>(() => sorter.Sort(input));
        }
    }
}
