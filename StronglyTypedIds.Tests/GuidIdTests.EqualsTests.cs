﻿using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class GuidIdTests
{
    /// <summary>
    ///     Tests for <see cref="GuidFor{TEntity}.Equals" />
    /// </summary>
    public class EqualsTests
    {
        [Fact]
        public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);
            var anotherStronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
            var anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

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
            var stronglyTypedId = new GuidFor<Order>(targetId);
            var anotherStronglyTypedId = new GuidFor<PricePosition>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, Guid>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
            var anotherStronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());

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
            var stronglyTypedId = new GuidFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<PricePosition, Guid>(targetId);

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
            var stronglyTypedId = new GuidFor<Order>(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
    }
}