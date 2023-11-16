using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class LongIdTests
{
    /// <summary>
    ///     Tests for <see cref="LongFor{TEntity}.op_GreaterThanOrEqual" />
    /// </summary>
    public class GreaterThanOrEqualOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsGreaterThanRight()
        {
            // arrange
            var left = new LongFor<Order>(2);
            var right = new LongFor<Order>(1);

            // act
            var result = left >= right;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeTrueWhenLeftIsEqualToRight()
        {
            // arrange
            var left = new LongFor<Order>(1);
            var right = new LongFor<Order>(1);

            // act
            var result = left >= right;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsLessThanRight()
        {
            // arrange
            var left = new LongFor<Order>(1);
            var right = new LongFor<Order>(2);

            // act
            var result = left >= right;

            // assert
            result.Should().BeFalse();
        }
    }
}