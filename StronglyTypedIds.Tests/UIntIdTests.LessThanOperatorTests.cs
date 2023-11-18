using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.op_LessThan" />
    /// </summary>
    public class LessThanOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsLessThanRight()
        {
            var left = new UIntFor<Order>(1);
            var right = new UIntFor<Order>(2);

            var result = left < right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsNotLessThanRight()
        {
            var left = new UIntFor<Order>(2);
            var right = new UIntFor<Order>(1);

            var result = left < right;

            result.Should().BeFalse();
        }
    }
}