using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.op_GreaterThanOrEqual" />
    /// </summary>
    public class GreaterThanOrEqualOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsGreaterThanRight()
        {
            var left = new UIntFor<Order>(2);
            var right = new UIntFor<Order>(1);

            var result = left >= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeTrueWhenLeftIsEqualToRight()
        {
            var left = new UIntFor<Order>(1);
            var right = new UIntFor<Order>(1);

            var result = left >= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsLessThanRight()
        {
            var left = new UIntFor<Order>(1);
            var right = new UIntFor<Order>(2);

            var result = left >= right;

            result.Should().BeFalse();
        }
    }
}