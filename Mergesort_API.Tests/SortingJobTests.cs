using Moq;
using System;
using Xunit;

namespace Mergesort_API.Tests
{

    public class SortingJobTests
    {
        private readonly SortingJob sortingJob;
        private readonly Mock<ISorter<int>> sorterMock;

        public SortingJobTests()
        {
            sorterMock = new Mock<ISorter<int>>();
            sorterMock.Setup(s => s.Sort(new int[0])).Returns(new int[0]).Verifiable();
            sortingJob = new SortingJob(sorterMock.Object, new int[0]);
        }

        [Fact]
        public void Ctor_NullInput_ThrowsNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SortingJob(sorterMock.Object, null));
        }

        [Fact]
        public void Ctor_NullSorter_ThrowsNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SortingJob(null, new int[0]));
        }

        [Fact]
        public void Work_SortsUsingSorter()
        {
            sortingJob.Work();

            sorterMock.Verify(s => s.Sort(new int[0]), Times.Once());
        }

        [Fact]
        public void Work_WhenDone_SetsDuration()
        {
            sortingJob.Work();

            Assert.True(sortingJob.Duration != default(TimeSpan));
        }
    }
}
