using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class IntIdTests
{
    /// <summary>
    ///     Tests for <see cref="IntFor{TEntity}.op_GreaterThan" />
    /// </summary>
    public class GreaterThanOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsGreaterThanRight()
        {
            var left = new IntFor<Order>(2);
            var right = new IntFor<Order>(1);

            var result = left > right;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsNotGreaterThanRight()
        {
            var left = new IntFor<Order>(1);
            var right = new IntFor<Order>(2);

            var result = left > right;

            result.Should().BeFalse();
        }
    }
}