using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace Mergesort_API.Tests
{
    public class InMemoryJobStoreTests
    {
        private readonly SortingJob sortingJob;
        private readonly IStorageProvider<int, SortingJob> store;
        public InMemoryJobStoreTests()
        {
            var sorterMock = new Mock<ISorter<int>>();
            sorterMock.Setup(s => s.Sort(Array.Empty<int>())).Returns(Array.Empty<int>()).Verifiable();
            sortingJob = new SortingJob(sorterMock.Object, Array.Empty<int>());
            store = new InMemoryJobStore();
        }

        [Fact]
        public async Task Save_NullJob_ThrowsNullException()
        {
            Func<Task> act = async () => await store.Save(1, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Save_WithPreexistingKey_ThrowsArgumentException()
        {
            Func<Task> act = async () => await store.Save(1, null);
            Func<Task> act2 = async () => await store.Save(1, null);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Retreive_WithExistingKey_RetrievesAtSavedKey()
        {
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
            var job = await store.GetById(365);

            job.Should().BeNull();
        }

        [Fact]
        public async Task GetAll_ReturnsAllAdded()
        {
            await store.Save(IDGenerator.GenerateNewId(), sortingJob);

            await store.Save(IDGenerator.GenerateNewId(), sortingJob);

            var jobs = await store.GetAll();

            jobs.Should().HaveCount(2);
            jobs.Should().NotContainNulls();
        }

    }
}
