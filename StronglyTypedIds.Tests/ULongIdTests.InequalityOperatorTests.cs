using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class ULongIdTests
{
    /// <summary>
    ///     Tests for <see cref="ULongFor{TEntity}.op_Inequality" />
    /// </summary>
    public class InequalityOperatorTests
    {
        [Fact]
        public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);
            var anotherStronglyTypedId = new ULongFor<Order>(targetId);

            // act
            var result = stronglyTypedId != anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());
            var anotherStronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());

            // act
            var result = stronglyTypedId != anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, ulong>(targetId);

            // act
            var result = stronglyTypedId != anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());
            var anotherStronglyTypedId = new IdFor<Order, ulong>(Faker.Random.ULong());

            // act
            var result = stronglyTypedId != anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);
            IEntityId<Order, ulong> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId != anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }
    }
}