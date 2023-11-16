using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class IdTests
{
    /// <summary>
    ///     Tests for <see cref="IdFor{TEntity,TId}.Value" />
    /// </summary>
    public class ValueTests
    {
        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }
    }
}