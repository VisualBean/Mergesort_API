using System;
using Xunit;

namespace Mergesort_API.Tests
{
    public class JobTests
    {
        private readonly Job basicJob;
        public JobTests()
        {
            basicJob = new BasicJob();
        }

        [Fact]
        public void Job_WhenCreated_SetsInitialState()
        {
            Assert.True(basicJob.Id > 0);
            Assert.True(basicJob.Timestamp != default(DateTimeOffset));
            Assert.Equal(Status.Pending, basicJob.Status);
        }

        [Fact]
        public void Run_WhenWorkIsDone_MarksJobAsCompleted()
        {
            basicJob.Run();

            Assert.Equal(Status.Completed, basicJob.Status);
        }
    }
}
