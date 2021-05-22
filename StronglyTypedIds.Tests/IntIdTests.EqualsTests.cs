using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class IntIdTests
    {
        /// <summary>
        /// Tests for <see cref="IntFor{TEntity}.Equals"/>
        /// </summary>
        public class EqualsTests
        {
            [Fact]
            public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
            {
                // arrange
                var targetId = Faker.Random.Int();
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
                var stronglyTypedId = new IntFor<Order>(Faker.Random.Int());
                var anotherStronglyTypedId = new IntFor<Order>(Faker.Random.Int());

                // act
                var result = stronglyTypedId.Equals(anotherStronglyTypedId);

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldNotBeEqualWhenEntitiesAreDifferent()
            {
                // arrange
                var targetId = Faker.Random.Int();
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
                var targetId = Faker.Random.Int();
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
                var stronglyTypedId = new IntFor<Order>(Faker.Random.Int());
                var anotherStronglyTypedId = new IdFor<Order, int>(Faker.Random.Int());

                // act
                var result = stronglyTypedId.Equals(anotherStronglyTypedId);

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldNotBeEqualWithIEntityIdWhenEntitiesAreDifferent()
            {
                // arrange
                var targetId = Faker.Random.Int();
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
                var targetId = Faker.Random.Int();
                var stronglyTypedId = new IntFor<Order>(targetId);
                IEntityId<Order, int> anotherStronglyTypedId = null;

                // act
                var result = stronglyTypedId.Equals(anotherStronglyTypedId);

                // assert
                result.Should().BeFalse();
            }
        }
    }
}