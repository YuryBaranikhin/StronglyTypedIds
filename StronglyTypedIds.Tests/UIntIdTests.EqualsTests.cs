using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.Equals" />
    /// </summary>
    public class EqualsTests
    {
        [Fact]
        public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var anotherStronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());
            var anotherStronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var anotherStronglyTypedId = new UIntFor<PricePosition>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, uint>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());
            var anotherStronglyTypedId = new IdFor<Order, uint>(Faker.Random.UInt());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<PricePosition, uint>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            IEntityId<Order, uint> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
    }
}