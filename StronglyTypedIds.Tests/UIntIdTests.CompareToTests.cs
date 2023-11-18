﻿using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.CompareTo" />
    /// </summary>
    public class CompareToTests
    {
        [Fact]
        public void ShouldProvide0ForSameId()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var result = stronglyTypedId.CompareTo(stronglyTypedId);

            // assert
            result.Should().Be(0);
        }

        [Fact]
        public void ShouldProvide0ForSameBaseId()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var anotherStronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var result = stronglyTypedId.CompareTo(anotherStronglyTypedId);

            // assert
            result.Should().Be(0);
        }

        [Fact]
        public void ShouldProvide1WhenCompareToNullObject()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);


            // act
            var result = stronglyTypedId.CompareTo((object)null);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void ShouldProvide1WhenCompareToNullEntityId()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);


            // act
            var result = stronglyTypedId.CompareTo(null);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void ShouldProvideSameResultAsBaseIdsDo()
        {
            // arrange
            var stronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());
            var anotherStronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());

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
            var stronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());
            var anotherStronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());

            // act
            var result1 = stronglyTypedId.CompareTo((IEntityId<Order, uint>)anotherStronglyTypedId);
            var result2 = anotherStronglyTypedId.CompareTo((IEntityId<Order, uint>)stronglyTypedId);

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
            var stronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());
            var anotherStronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());

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
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var someObject = new Order();

            // act
            var act = () => stronglyTypedId.CompareTo(someObject);

            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}