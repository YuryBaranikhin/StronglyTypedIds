using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

/// <summary>
/// This partial class contains tests for the IdFor class.
/// </summary>
public partial class IdTests
{
    /// <summary>
    /// This class contains tests for <see cref="IdFor{TEntity, TId}.op_LessThanOrEqual" />
    /// </summary>
    public class LessThanOrEqualToOperatorTests
    {
        /// <summary>
        /// Tests that the less than or equal to operator returns false when the left operand is null.
        /// </summary>
        [Fact]
        public void ShouldBeFalseWhenLeftIsNull()
        {
            // arrange
            IdFor<Order, int> id1 = null;
            var id2 = new IdFor<Order, int>(1);

            // act
            var result = id1 <= id2;

            // assert
            result.Should().BeFalse();
        }

        /// <summary>
        /// Tests that the less than or equal to operator returns false when the right operand is null.
        /// </summary>
        [Fact]
        public void ShouldBeFalseWhenRightIsNull()
        {
            // arrange
            var id1 = new IdFor<Order, int>(1);
            IdFor<Order, int> id2 = null;

            // act
            var result = id1 <= id2;

            // assert
            result.Should().BeFalse();
        }

        /// <summary>
        /// Tests that the less than or equal to operator returns true when both operands are null.
        /// </summary>
        [Fact]
        public void ShouldBeTrueWhenBothAreNull()
        {
            // arrange
            IdFor<Order, int> id1 = null;
            IdFor<Order, int> id2 = null;

            // act
            var result = id1 <= id2;

            // assert
            result.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the less than or equal to operator returns true when the left operand is less than the right operand.
        /// </summary>
        [Fact]
        public void ShouldBeTrueWhenLeftIsLessThanRight()
        {
            // arrange
            var id1 = new IdFor<Order, int>(1);
            var id2 = new IdFor<Order, int>(2);

            // act
            var result = id1 <= id2;

            // assert
            result.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the less than or equal to operator returns true when the left operand is equal to the right operand.
        /// </summary>
        [Fact]
        public void ShouldBeTrueWhenLeftIsEqualToRight()
        {
            // arrange
            var id1 = new IdFor<Order, int>(1);
            var id2 = new IdFor<Order, int>(1);

            // act
            var result = id1 <= id2;

            // assert
            result.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the less than or equal to operator returns false when the left operand is greater than the right operand.
        /// </summary>
        [Fact]
        public void ShouldBeFalseWhenLeftIsGreaterThanRight()
        {
            // arrange
            var id1 = new IdFor<Order, int>(2);
            var id2 = new IdFor<Order, int>(1);

            // act
            var result = id1 <= id2;

            // assert
            result.Should().BeFalse();
        }
    }
}