using System;
using Xunit;

namespace Mergesort_API.Tests
{
    public class BasicJob : Job
    {
        public override void Work()
        {
            //Do nothing
        }
    }

    public class JobTests
    {
        private readonly Job basicJob;
        public JobTests()
        {
            basicJob = new BasicJob();
        }

        [Fact]
        public void Ctor_SetsInitialState()
        {
            Assert.True(basicJob.Id != default(Guid));
            Assert.True(basicJob.Timestamp != default(DateTimeOffset));
            Assert.True(basicJob.Status == Status.Pending);
        }

        [Fact]
        public void Run_WhenWorkIsDone_MarksJobAsCompleted()
        {
            basicJob.Run();

            Assert.Equal(Status.Completed, basicJob.Status);
        }
    }
}
