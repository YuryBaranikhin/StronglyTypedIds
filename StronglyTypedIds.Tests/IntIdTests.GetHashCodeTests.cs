using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class IntIdTests
{
    /// <summary>
    ///     Tests for <see cref="IntFor{TEntity}.GetHashCode" />
    /// </summary>
    public class GetHashCodeTests
    {
        [Fact]
        public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IntFor<Order>(targetId);

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
            var targetId = Faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IntFor<PricePosition>(targetId);

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
            var stronglyTypedId = new IntFor<Order>(Faker.Random.Int());
            var anotherStronglyTypedId = new IntFor<Order>(Faker.Random.Int());

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().NotBe(hashCode2);
        }
    }
}