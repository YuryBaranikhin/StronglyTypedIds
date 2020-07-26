using Bogus;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public class LongIdTests
    {
        private readonly Faker faker = new Faker();

        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }

        [Fact]
        public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new LongFor<Order>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new LongFor<Order>(faker.Random.Long());
            var anotherStronglyTypedId = new LongFor<Order>(faker.Random.Long());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new LongFor<PricePosition>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, long>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new LongFor<Order>(faker.Random.Long());
            var anotherStronglyTypedId = new IdFor<Order, long>(faker.Random.Long());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<PricePosition, long>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            IEntityId<Order, long> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeSimilarWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new LongFor<Order>(targetId);

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeSimilarWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new LongFor<Order>(faker.Random.Long());
            var anotherStronglyTypedId = new LongFor<Order>(faker.Random.Long());

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldBeSimilarWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, long>(targetId);

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeSimilarWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new LongFor<Order>(faker.Random.Long());
            var anotherStronglyTypedId = new IdFor<Order, long>(faker.Random.Long());

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeSimilarWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);
            IEntityId<Order, long> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = faker.Random.Long();
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
            var targetId = faker.Random.Long();
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
            var stronglyTypedId = new LongFor<Order>(faker.Random.Long());
            var anotherStronglyTypedId = new LongFor<Order>(faker.Random.Long());

            // act
            var hashCode1 = stronglyTypedId.GetHashCode();
            var hashCode2 = anotherStronglyTypedId.GetHashCode();

            // assert
            hashCode1.Should().NotBe(hashCode2);
        }

        private class Order
        {
            public long Id { get; set; }
        }
        
        private class PricePosition
        {
            public long Id { get; set; }
        }
    }
}