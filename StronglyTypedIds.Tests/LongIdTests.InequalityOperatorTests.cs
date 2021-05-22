using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class LongIdTests
    {
        /// <summary>
        /// Tests for <see cref="LongFor{TEntity}.op_Inequality"/>
        /// </summary>
        public class InequalityOperatorTests
        {
            [Fact]
            public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
            {
                // arrange
                var targetId = Faker.Random.Long();
                var stronglyTypedId = new LongFor<Order>(targetId);
                var anotherStronglyTypedId = new LongFor<Order>(targetId);

                // act
                var result = stronglyTypedId != anotherStronglyTypedId;

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldNotBeEqualWhenValuesAreDifferent()
            {
                // arrange
                var stronglyTypedId = new LongFor<Order>(Faker.Random.Long());
                var anotherStronglyTypedId = new LongFor<Order>(Faker.Random.Long());

                // act
                var result = stronglyTypedId != anotherStronglyTypedId;

                // assert
                result.Should().BeTrue();
            }

            [Fact]
            public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
            {
                // arrange
                var targetId = Faker.Random.Long();
                var stronglyTypedId = new LongFor<Order>(targetId);
                var anotherStronglyTypedId = new IdFor<Order, long>(targetId);

                // act
                var result = stronglyTypedId != anotherStronglyTypedId;

                // assert
                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
            {
                // arrange
                var stronglyTypedId = new LongFor<Order>(Faker.Random.Long());
                var anotherStronglyTypedId = new IdFor<Order, long>(Faker.Random.Long());

                // act
                var result = stronglyTypedId != anotherStronglyTypedId;

                // assert
                result.Should().BeTrue();
            }

            [Fact]
            public void ShouldNotBeEqualWithIEntityIdWhenNull()
            {
                // arrange
                var targetId = Faker.Random.Long();
                var stronglyTypedId = new LongFor<Order>(targetId);
                IEntityId<Order, long> anotherStronglyTypedId = null;

                // act
                var result = stronglyTypedId != anotherStronglyTypedId;

                // assert
                result.Should().BeTrue();
            }
        }
    }
}