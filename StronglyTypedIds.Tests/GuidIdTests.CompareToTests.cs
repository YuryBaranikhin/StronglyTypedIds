﻿using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class GuidIdTests
{
    /// <summary>
    ///     Tests for <see cref="GuidFor{TEntity}.CompareTo" />
    /// </summary>
    public class CompareToTests
    {
        [Fact]
        public void ShouldProvide0ForSameId()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var result = stronglyTypedId.CompareTo(stronglyTypedId);

            // assert
            result.Should().Be(0);
        }

        [Fact]
        public void ShouldProvide0ForSameBaseId()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);
            var anotherStronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var result = stronglyTypedId.CompareTo(anotherStronglyTypedId);

            // assert
            result.Should().Be(0);
        }

        [Fact]
        public void ShouldProvide1WhenCompareToNullObject()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);


            // act
            var result = stronglyTypedId.CompareTo((object)null);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void ShouldProvide1WhenCompareToNullEntityId()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);


            // act
            var result = stronglyTypedId.CompareTo(null);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void ShouldProvideSameResultAsBaseIdsDo()
        {
            // arrange
            var stronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
            var anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

            // act
            var result1 = stronglyTypedId.CompareTo(anotherStronglyTypedId);
            var result2 = anotherStronglyTypedId.CompareTo(stronglyTypedId);

            var baseResult1 = stronglyTypedId.Value.CompareTo(anotherStronglyTypedId.Value);
            var baseResult2 = anotherStronglyTypedId.Value.CompareTo(stronglyTypedId.Value);

            // assert
            result1.Should().Be(baseResult1);
            result2.Should().Be(baseResult2);
        }

        [Fact]
        public void ShouldProvideSameResultAsBaseIdsDoForEntityId()
        {
            // arrange
            var stronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
            var anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

            // act
            var result1 = stronglyTypedId.CompareTo((IEntityId<Order, Guid>)anotherStronglyTypedId);
            var result2 = anotherStronglyTypedId.CompareTo((IEntityId<Order, Guid>)stronglyTypedId);

            var baseResult1 = stronglyTypedId.Value.CompareTo(anotherStronglyTypedId.Value);
            var baseResult2 = anotherStronglyTypedId.Value.CompareTo(stronglyTypedId.Value);

            // assert
            result1.Should().Be(baseResult1);
            result2.Should().Be(baseResult2);
        }

        [Fact]
        public void ShouldProvideSameResultAsBaseIdsDoForObject()
        {
            // arrange
            var stronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
            var anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

            // act
            var result1 = stronglyTypedId.CompareTo((object)anotherStronglyTypedId);
            var result2 = anotherStronglyTypedId.CompareTo((object)stronglyTypedId);

            var baseResult1 = stronglyTypedId.Value.CompareTo(anotherStronglyTypedId.Value);
            var baseResult2 = anotherStronglyTypedId.Value.CompareTo(stronglyTypedId.Value);

            // assert
            result1.Should().Be(baseResult1);
            result2.Should().Be(baseResult2);
        }

        [Fact]
        public void ShouldThrowWhenCompareWithNoEntityId()
        {
            // arrange
            var stronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
            var someObject = new Order();

            // act
            var act = () => stronglyTypedId.CompareTo(someObject);

            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}