using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mergesort_API.Tests
{
    public class IDGeneratorTests
    {
        [Fact]
        public async Task GenerateNewId_IncrementsId()
        {
            // Best effort thread test for id generation.

            var tasks = new List<Task<int>>();
            Parallel.For(0, 100, (i) => {
                tasks.Add(Task.Run(() => IDGenerator.GenerateNewId()));
            });

            await Task.WhenAll(tasks);

            var numbers = tasks.Select(t => t.Result);

            numbers.Should().OnlyHaveUniqueItems();
            numbers.Should().NotBeEmpty();
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
