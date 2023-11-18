using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class GuidIdTests
{
    /// <summary>
    ///     Tests for <see cref="GuidFor{TEntity}.op_LessThan" />
    /// </summary>
    public class LessThanOperatorTests
    {
        [Fact]
        public void ShouldBeTrueWhenLeftIsLessThanRight()
        {
            // arrange
            var left = new GuidFor<Order>(Guid.Parse("439b8c26-96c9-4d73-bd68-ba0692bbe858"));
            var right = new GuidFor<Order>(Guid.Parse("439b8c26-96c9-4d73-bd68-ba0692bbe859"));

            // act
            var result = left < right;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeFalseWhenLeftIsNotLessThanRight()
        {
            // arrange
            var left = new GuidFor<Order>(Guid.Parse("439b8c26-96c9-4d73-bd68-ba0692bbe858"));
            var right = new GuidFor<Order>(Guid.Parse("439b8c26-96c9-4d73-bd68-ba0692bbe858"));

            // act
            var result = left < right;

            // assert
            result.Should().BeFalse();
        }
    }
}