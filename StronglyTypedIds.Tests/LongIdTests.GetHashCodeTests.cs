using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class LongIdTests
{
    /// <summary>
    ///     Tests for <see cref="LongFor{TEntity}.GetHashCode" />
    /// </summary>
    public class GetHashCodeTests
    {
        [Fact]
        public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new LongFor<Order>(targetId);

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
            var targetId = Faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new LongFor<PricePosition>(targetId);

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
            var stronglyTypedId = new LongFor<Order>(Faker.Random.Long());
            var anotherStronglyTypedId = new LongFor<Order>(Faker.Random.Long());

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().NotBe(hashCode2);
        }
    }
}