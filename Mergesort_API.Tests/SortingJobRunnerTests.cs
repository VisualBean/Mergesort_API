using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Mergesort_API.Tests
{
    public class SortingJobRunnerTests
    {
        private readonly IJobRunner runner;
        private readonly Mock<SortingJob> sortingJobMock;
        private readonly Mock<ISorter<int>> sorterMock;

        public SortingJobRunnerTests()
        {
            var loggerMock = new Mock<ILogger<SortingJobRunner>>();

            sorterMock = new Mock<ISorter<int>>();
            sortingJobMock = new Mock<SortingJob>(sorterMock.Object, Array.Empty<int>());
            runner = new SortingJobRunner(loggerMock.Object);
        }

        [Fact]
        public void Execute_WithValidJob_RunsJob()
        {
            runner.Execute(sortingJobMock.Object);

            // Sleep due to fire and forget nature of Execute. - Might cause flakyness.
            Thread.Sleep(1000);
            sortingJobMock.Verify(s => s.Run(), Times.Once);
        }

    }
}
