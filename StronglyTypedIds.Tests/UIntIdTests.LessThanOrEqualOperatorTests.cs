using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.op_LessThanOrEqual" />
    /// </summary>
    public class LessThanOrEqualOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsLessThanRight()
        {
            var left = new UIntFor<Order>(1);
            var right = new UIntFor<Order>(2);

            var result = left <= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeTrueWhenLeftIsEqualToRight()
        {
            var left = new UIntFor<Order>(1);
            var right = new UIntFor<Order>(1);

            var result = left <= right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsGreaterThanRight()
        {
            var left = new UIntFor<Order>(2);
            var right = new UIntFor<Order>(1);

            var result = left <= right;

            result.Should().BeFalse();
        }
    }
}