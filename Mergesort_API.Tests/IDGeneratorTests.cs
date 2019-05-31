using FluentAssertions;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Xunit;

namespace Mergesort_API.Tests
{
    public class IDGeneratorTests
    {
        [Fact]
        public void GenerateNewId_RespectsThreads()
        {
            // Best effort thread test for id generation.

            var numbers = new ConcurrentBag<int>();
            Parallel.For(0, 100, i => {

                numbers.Add(IDGenerator.GenerateNewId());
            });

            numbers.Should().NotContainNulls();
            numbers.Should().NotContain(0);
            numbers.Should().OnlyHaveUniqueItems();
            numbers.Should().HaveCount(100);

        }

        [Fact]
        public void GenerateNewID_IncrementsId()
        {
            var first = IDGenerator.GenerateNewId();
            var second = IDGenerator.GenerateNewId();

            first.Should().BeGreaterThan(0);
            first.Should().BeLessThan(second);
        }
    }
}
