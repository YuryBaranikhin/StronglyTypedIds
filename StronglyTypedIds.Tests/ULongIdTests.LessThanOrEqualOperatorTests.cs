using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class ULongIdTests
{
    /// <summary>
    ///     Tests for <see cref="ULongFor{TEntity}.op_LessThanOrEqual" />
    /// </summary>
    public class LessThanOrEqualOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsLessThanRight()
        {
            // arrange
            var left = new ULongFor<Order>(1);
            var right = new ULongFor<Order>(2);

            // act
            var result = left <= right;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeTrueWhenLeftIsEqualToRight()
        {
            // arrange
            var left = new ULongFor<Order>(1);
            var right = new ULongFor<Order>(1);

            // act
            var result = left <= right;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsGreaterThanRight()
        {
            // arrange
            var left = new ULongFor<Order>(2);
            var right = new ULongFor<Order>(1);

            // act
            var result = left <= right;

            // assert
            result.Should().BeFalse();
        }
    }
}