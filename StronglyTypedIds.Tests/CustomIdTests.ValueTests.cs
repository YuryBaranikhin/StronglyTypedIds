using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class CustomIdTests
{
    /// <summary>
    ///     Tests for custom id based on <see cref="IdFor{TEntity,TId}.Value" />
    /// </summary>
    public class ValueTests
    {
        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }
    }
}