using Bogus;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public class IntIdTests
    {
        private readonly Faker faker = new Faker();

        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }

        [Fact]
        public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IntFor<Order>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IntFor<Order>(faker.Random.Int());
            var anotherStronglyTypedId = new IntFor<Order>(faker.Random.Int());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IntFor<PricePosition>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, int>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IntFor<Order>(faker.Random.Int());
            var anotherStronglyTypedId = new IdFor<Order, int>(faker.Random.Int());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<PricePosition, int>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            IEntityId<Order, int> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeSimilarWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IntFor<Order>(targetId);

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeSimilarWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IntFor<Order>(faker.Random.Int());
            var anotherStronglyTypedId = new IntFor<Order>(faker.Random.Int());

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeSimilarWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, int>(targetId);

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeSimilarWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IntFor<Order>(faker.Random.Int());
            var anotherStronglyTypedId = new IdFor<Order, int>(faker.Random.Int());

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeSimilarWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = faker.Random.Int();
            var stronglyTypedId = new IntFor<Order>(targetId);
            IEntityId<Order, int> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Int();
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
            var targetId = faker.Random.Int();
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
            var stronglyTypedId = new IntFor<Order>(faker.Random.Int());
            var anotherStronglyTypedId = new IntFor<Order>(faker.Random.Int());

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().NotBe(hashCode2);
        }

        private class Order
        {
        }

        private class PricePosition
        {
        }
    }
}