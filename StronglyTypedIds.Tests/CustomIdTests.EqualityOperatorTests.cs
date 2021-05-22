﻿using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class CustomIdTests
    {
        /// <summary>
        /// Tests for custom id based on <see cref="IdFor{TEntity,TId}.op_Equality"/>
        /// </summary>
        public class EqualityOperatorTests
        {
            [Fact]
            public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
            {
                // arrange
                var targetId = Guid.NewGuid();
                var stronglyTypedId = new OrderId(targetId);
                var anotherStronglyTypedId = new IdFor<Order, Guid>(targetId);

                // act
                var result = stronglyTypedId == anotherStronglyTypedId;

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
                var result = stronglyTypedId == anotherStronglyTypedId;

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
            {
                // arrange
                var targetId = Guid.NewGuid();
                var stronglyTypedId = new OrderId(targetId);
                IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(targetId);

                // act
                var result = stronglyTypedId == anotherStronglyTypedId;

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
                var result = stronglyTypedId == anotherStronglyTypedId;

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldNotBeEqualWithIEntityIdWhenFirstNull()
            {
                // arrange
                IdFor<Order, Guid> stronglyTypedId = null;
                IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
                ;

                // act
                var result = stronglyTypedId == anotherStronglyTypedId;

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldNotBeEqualWithIEntityIdWhenSecondNull()
            {
                // arrange
                var targetId = Guid.NewGuid();
                var stronglyTypedId = new OrderId(targetId);
                IEntityId<Order, Guid> anotherStronglyTypedId = null;

                // act
                var result = stronglyTypedId == anotherStronglyTypedId;

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeEqualWithIEntityIdWhenBothNull()
            {
                // arrange
                IdFor<Order, Guid> stronglyTypedId = null;
                IEntityId<Order, Guid> anotherStronglyTypedId = null;

                // act
                var result = stronglyTypedId == anotherStronglyTypedId;

                // assert
                result.Should().BeTrue();
            }
        }
    }
}