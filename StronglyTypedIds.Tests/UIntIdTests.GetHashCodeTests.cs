using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.GetHashCode" />
    /// </summary>
    public class GetHashCodeTests
    {
        [Fact]
        public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var anotherStronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().Be(hashCode2);
        }

        [Fact]
        public void ShouldNotProvideSameHashCodeWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);
            var anotherStronglyTypedId = new UIntFor<PricePosition>(targetId);

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().NotBe(hashCode2);
        }

        [Fact]
        public void ShouldNotProvideSameHashCodeWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());
            var anotherStronglyTypedId = new UIntFor<Order>(Faker.Random.UInt());

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().NotBe(hashCode2);
        }
    }
}