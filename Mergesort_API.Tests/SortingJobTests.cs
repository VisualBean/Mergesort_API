using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Mergesort_API.Tests
{
    public class SortingJobTests
    {
        private readonly Mock<ISorter<int>> sorterMock;
        private readonly int[] unsortedArray = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private readonly int[] sortedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public SortingJobTests()
        {
            sorterMock = new Mock<ISorter<int>>();
            sorterMock.Setup(s => s.Sort(unsortedArray)).Returns(sortedArray).Verifiable();
        }

        [Fact]
        public void With_NullInput_ThrowsNullException()
        {
            Action actNullArray = () => new SortingJob(sorterMock.Object, null);

            actNullArray.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void With_NullSorter_ThrowsNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SortingJob(null, Array.Empty<int>()));
        }

        [Fact]
        public void Work_SortsUsingSorter()
        {
            var sortingJob = new SortingJob(sorterMock.Object, Array.Empty<int>());

            sortingJob.Work();

            sorterMock.Verify(s => s.Sort(It.IsAny<int[]>()), Times.Once());
        }

        [Fact]
        public void Work_WhenDone_SetsDuration()
        {
            var sortingJob = new SortingJob(sorterMock.Object, Array.Empty<int>());
            sortingJob.Work();

            sortingJob.Duration.Should().NotBe(default(TimeSpan));
        }

        [Fact]
        public void Work_WhenDone_SetsSortedOutput()
        {
            

            var sortingJob = new SortingJob(sorterMock.Object, unsortedArray);
            sortingJob.Work();

            sortingJob.Output.Should().NotBeNull();
            sortingJob.Output.Should().NotBeEmpty();
            sortingJob.Output.Should().BeSameAs(sortedArray);
        }
    }
}
