using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class IntIdTests
{
    /// <summary>
    ///     Tests for <see cref="IntFor{TEntity}.op_GreaterThanOrEqual" />
    /// </summary>
    public class GreaterThanOrEqualOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsGreaterThanRight()
        {
            var left = new IntFor<Order>(2);
            var right = new IntFor<Order>(1);

            var result = left >= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeTrueWhenLeftIsEqualToRight()
        {
            var left = new IntFor<Order>(1);
            var right = new IntFor<Order>(1);

            var result = left >= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsLessThanRight()
        {
            var left = new IntFor<Order>(1);
            var right = new IntFor<Order>(2);

            var result = left >= right;

            result.Should().BeFalse();
        }
    }
}