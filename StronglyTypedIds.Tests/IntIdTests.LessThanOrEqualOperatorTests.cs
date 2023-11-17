using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class IntIdTests
{
    /// <summary>
    ///     Tests for <see cref="IntFor{TEntity}.op_LessThanOrEqual" />
    /// </summary>
    public class LessThanOrEqualOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsLessThanRight()
        {
            var left = new IntFor<Order>(1);
            var right = new IntFor<Order>(2);

            var result = left <= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeTrueWhenLeftIsEqualToRight()
        {
            var left = new IntFor<Order>(1);
            var right = new IntFor<Order>(1);

            var result = left <= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsGreaterThanRight()
        {
            var left = new IntFor<Order>(2);
            var right = new IntFor<Order>(1);

            var result = left <= right;

            result.Should().BeFalse();
        }
    }
}