using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class CustomIdTests
{
    /// <summary>
    ///     Tests for custom id based on <see cref="IdFor{TEntity,TId}.Equals" />
    /// </summary>
    public class EqualsTests
    {
        [Fact]
        public void ShouldBeEqualWhenIdIsTheSame()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);

            // act
            var result = stronglyTypedId.Equals(stronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);
            var anotherStronglyTypedId = new IdFor<Order, Guid>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new OrderId(Guid.NewGuid());
            var anotherStronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);
            var anotherStronglyTypedId = new IdFor<PricePosition, Guid>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualToNull()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);

            // act
            var result = stronglyTypedId.Equals(null);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenIdIsTheSame()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = stronglyTypedId;

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new OrderId(Guid.NewGuid());
            IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);
            IEntityId<PricePosition, Guid> anotherStronglyTypedId = new GuidFor<PricePosition>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new OrderId(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
    }
}