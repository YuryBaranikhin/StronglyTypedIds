using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class LongIdTests
{
    /// <summary>
    ///     Tests for <see cref="LongFor{TEntity}.op_GreaterThan" />
    /// </summary>
    public class GreaterThanOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsGreaterThanRight()
        {
            // arrange
            var left = new LongFor<Order>(2);
            var right = new LongFor<Order>(1);

            // act
            var result = left > right;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsNotGreaterThanRight()
        {
            // arrange
            var left = new LongFor<Order>(1);
            var right = new LongFor<Order>(2);

            // act
            var result = left > right;

            // assert
            result.Should().BeFalse();
        }
    }
}