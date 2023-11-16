using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class LongIdTests
{
    /// <summary>
    ///     Tests for <see cref="LongFor{TEntity}.op_LessThan" />
    /// </summary>
    public class LessThanOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsLessThanRight()
        {
            // arrange
            var left = new LongFor<Order>(1);
            var right = new LongFor<Order>(2);

            // act
            var result = left < right;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsNotLessThanRight()
        {
            // arrange
            var left = new LongFor<Order>(2);
            var right = new LongFor<Order>(1);

            // act
            var result = left < right;

            // assert
            result.Should().BeFalse();
        }
    }
}