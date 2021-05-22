using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class GuidIdTests
    {
        /// <summary>
        /// Tests for <see cref="GuidFor{TEntity}.ToString"/>
        /// </summary>
        public class ToStringTests
        {
            [Fact]
            public void ShouldProvideValueString()
            {
                // arrange
                var targetId = Guid.NewGuid();
                var stronglyTypedId = new GuidFor<Order>(targetId);

                // act
                var providedValue = stronglyTypedId.ToString();

                // assert
                providedValue.Should().Be(targetId.ToString());
            }
        }
    }
}