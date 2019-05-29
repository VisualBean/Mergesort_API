using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mergesort_API.Tests
{
    public class InMemoryJobStoreTests
    {
        private readonly IStorageProvider<Guid, SortingJob> store;
        private readonly SortingJob sortingJob;

        public InMemoryJobStoreTests()
        {
            store = new InMemoryJobStore();

            var sorterMock = new Mock<ISorter<int>>();
            sorterMock.Setup(s => s.Sort(new int[0])).Returns(new int[0]).Verifiable();
            sortingJob = new SortingJob(sorterMock.Object, new int[0]);
        }

        [Fact]
        public void Store_NullJob_DoesNotStoreJob()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await store.Store(Guid.NewGuid(), null));
        }

        [Fact]
        public async Task Retreive_ValidKey_RetrievesAtSavedKey()
        {
            var id = Guid.NewGuid();

            await store.Store(id, sortingJob);
            var job = await store.Retreive(id);

            Assert.Same(sortingJob, job);
        }

        [Fact]
        public async Task Retreive_GetNonExistentId_ReturnsNull()
        {
            var id = Guid.NewGuid();

            var job = await store.Retreive(id);

            Assert.True(job == null);
        }

        [Fact]
        public async Task GetAll_ReturnsAllAdded()
        {
            var id = Guid.NewGuid();
            await store.Store(id, sortingJob);

            id = Guid.NewGuid();
            await store.Store(id, sortingJob);

            id = Guid.NewGuid();
            await store.Store(id, sortingJob);

            id = Guid.NewGuid();
            await store.Store(id, sortingJob);

            id = Guid.NewGuid();
            await store.Store(id, sortingJob);

            var jobs = await store.GetAll();

            Assert.True(jobs.Count() == 5);
        }

    }
}
