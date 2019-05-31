using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Mergesort_API.Tests
{
    public class IDGeneratorTests
    {

        [Fact]
        public void GenerateNewId_IncrementsId()
        {
            var first = IDGenerator.GenerateNewId();
            var second = IDGenerator.GenerateNewId();

            first.Should().BeGreaterThan(0);
            first.Should().BeLessThan(second);

        }

    }
}
