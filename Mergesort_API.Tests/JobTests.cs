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
        public void Ctor_SetsId()
        {
            Assert.True(basicJob.Id != Guid.Empty);
        }

        [Fact]
        public void Ctor_SetsTimestamp()
        {
            Assert.True(basicJob.Timestamp != default(DateTimeOffset));
        }

        [Fact]
        public void Ctor_SetsStatusAsPending()
        {
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
