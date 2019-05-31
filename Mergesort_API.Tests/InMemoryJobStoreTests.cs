using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace Mergesort_API.Tests
{
    public class InMemoryJobStoreTests
    {
        private readonly SortingJob sortingJob;
        private readonly Mock<ILogger<InMemoryJobStore>> loggerMock;
        public InMemoryJobStoreTests()
        {
            var sorterMock = new Mock<ISorter<int>>();
            loggerMock = new Mock<ILogger<InMemoryJobStore>>();
            sorterMock.Setup(s => s.Sort(Array.Empty<int>())).Returns(Array.Empty<int>()).Verifiable();
            sortingJob = new SortingJob(sorterMock.Object, Array.Empty<int>());
        }

        [Fact]
        public void Save_NullJob_ThrowsNullException()
        {
            var store = new InMemoryJobStore(loggerMock.Object);
            Func<Task> act = async () => await store.Save(1, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Save_RespectsThreads()
        {
            // Best effort thread test

            var store = new InMemoryJobStore(loggerMock.Object);
            Parallel.For(0, 100, async (i) =>
            {
                await store.Save(IDGenerator.GenerateNewId(), sortingJob);
            });

            var allItems = await store.GetAll();
            allItems.Should().NotContainNulls();
            allItems.Should().HaveCount(100);
        }

        [Fact]
        public void Save_WithPreexistingKey_ThrowsArgumentException()
        {
            var store = new InMemoryJobStore(loggerMock.Object);

            Func<Task> act = async () => await store.Save(1, null);
            Func<Task> act2 = async () => await store.Save(1, null);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Retreive_WithExistingKey_RetrievesAtSavedKey()
        {
            var store = new InMemoryJobStore(loggerMock.Object);
            var id = IDGenerator.GenerateNewId();

            await store.Save(id, sortingJob);
            var job = await store.GetById(id);

            job.Should().NotBeNull();
            job.Should().BeOfType(typeof(SortingJob));
            job.Should().BeSameAs(sortingJob);
        }

        [Fact]
        public async Task Retreive_WithNonExistantKey_ReturnsNull()
        {
            var store = new InMemoryJobStore(loggerMock.Object);
            var job = await store.GetById(365);

            job.Should().BeNull();
        }

        [Fact]
        public async Task GetAll_ReturnsAllAdded()
        {
            var store = new InMemoryJobStore(loggerMock.Object);

            await store.Save(IDGenerator.GenerateNewId(), sortingJob);
            await store.Save(IDGenerator.GenerateNewId(), sortingJob);

            var jobs = await store.GetAll();

            jobs.Should().HaveCount(2);
            jobs.Should().NotContainNulls();
        }

    }
}
