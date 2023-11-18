using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class ULongIdTests
{
    /// <summary>
    ///     Tests for <see cref="ULongFor{TEntity}.CompareTo" />
    /// </summary>
    public class CompareToTests
    {
        [Fact]
        public void ShouldProvide0ForSameId()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);

            // act
            var result = stronglyTypedId.CompareTo(stronglyTypedId);

            // assert
            result.Should().Be(0);
        }

        [Fact]
        public void ShouldProvide0ForSameBaseId()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);
            var anotherStronglyTypedId = new ULongFor<Order>(targetId);

            // act
            var result = stronglyTypedId.CompareTo(anotherStronglyTypedId);

            // assert
            result.Should().Be(0);
        }

        [Fact]
        public void ShouldProvide1WhenCompareToNullObject()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);


            // act
            var result = stronglyTypedId.CompareTo((object)null);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void ShouldProvide1WhenCompareToNullEntityId()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);


            // act
            var result = stronglyTypedId.CompareTo(null);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void ShouldProvideSameResultAsBaseIdsDo()
        {
            // arrange
            var stronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());
            var anotherStronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());

            // act
            var result1 = stronglyTypedId.CompareTo(anotherStronglyTypedId);
            var result2 = anotherStronglyTypedId.CompareTo(stronglyTypedId);

            var baseResult1 = stronglyTypedId.Value.CompareTo(anotherStronglyTypedId.Value);
            var baseResult2 = anotherStronglyTypedId.Value.CompareTo(stronglyTypedId.Value);

            // assert
            result1.Should().Be(baseResult1);
            result2.Should().Be(baseResult2);
        }

        [Fact]
        public void ShouldProvideSameResultAsBaseIdsDoForEntityId()
        {
            // arrange
            var stronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());
            var anotherStronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());

            // act
            var result1 = stronglyTypedId.CompareTo((IEntityId<Order, ulong>)anotherStronglyTypedId);
            var result2 = anotherStronglyTypedId.CompareTo((IEntityId<Order, ulong>)stronglyTypedId);

            var baseResult1 = stronglyTypedId.Value.CompareTo(anotherStronglyTypedId.Value);
            var baseResult2 = anotherStronglyTypedId.Value.CompareTo(stronglyTypedId.Value);

            // assert
            result1.Should().Be(baseResult1);
            result2.Should().Be(baseResult2);
        }

        [Fact]
        public void ShouldProvideSameResultAsBaseIdsDoForObject()
        {
            // arrange
            var stronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());
            var anotherStronglyTypedId = new ULongFor<Order>(Faker.Random.ULong());

            // act
            var result1 = stronglyTypedId.CompareTo((object)anotherStronglyTypedId);
            var result2 = anotherStronglyTypedId.CompareTo((object)stronglyTypedId);

            var baseResult1 = stronglyTypedId.Value.CompareTo(anotherStronglyTypedId.Value);
            var baseResult2 = anotherStronglyTypedId.Value.CompareTo(stronglyTypedId.Value);

            // assert
            result1.Should().Be(baseResult1);
            result2.Should().Be(baseResult2);
        }

        [Fact]
        public void ShouldThrowWhenCompareWithNoEntityId()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);
            var someObject = new Order();

            // act
            var act = () => stronglyTypedId.CompareTo(someObject);

            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}