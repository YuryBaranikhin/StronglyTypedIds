using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class ULongIdTests
{
    /// <summary>
    ///     Tests for <see cref="ULongFor{TEntity}.GetHashCode" />
    /// </summary>
    public class GetHashCodeTests
    {
        [Fact]
        public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);
            var anotherStronglyTypedId = new ULongFor<Order>(targetId);

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
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);
            var anotherStronglyTypedId = new ULongFor<PricePosition>(targetId);

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
            var stronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());
            var anotherStronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().NotBe(hashCode2);
        }
    }
}