using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public class IdTests
    {
        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }
        
        [Fact]
        public void ShouldBeEqualWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, Guid>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqualWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());
            var anotherStronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldNotBeEqualWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            var anotherStronglyTypedId = new IdFor<PricePosition, Guid>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldBeEqualWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());
            IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenEntitiesAreDifferent()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            IEntityId<PricePosition, Guid> anotherStronglyTypedId = new GuidFor<PricePosition>(targetId);

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldNotBeEqualWithIEntityIdWhenNull()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId.Equals(anotherStronglyTypedId);

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldBeSimilarWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, Guid>(targetId);

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void ShouldNotBeSimilarWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());
            var anotherStronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldBeSimilarWithIEntityIdWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void ShouldNotBeSimilarWithIEntityIdWhenValuesAreDifferent()
        {
            // arrange
            var stronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());
            IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotBeSimilarWithIEntityIdWhenFirstNull()
        {
            // arrange
            var targetId = Guid.NewGuid();
            IdFor<Order, Guid> stronglyTypedId = null;
            IEntityId<Order, Guid> anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());;

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldNotBeSimilarWithIEntityIdWhenSecondNull()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            IEntityId<Order, Guid> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void ShouldBeSimilarWithIEntityIdWhenBothNull()
        {
            // arrange
            IdFor<Order, Guid> stronglyTypedId = null;
            IEntityId<Order, Guid> anotherStronglyTypedId = null;

            // act
            var result = stronglyTypedId == anotherStronglyTypedId;

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            var anotherStronglyTypedId = new IdFor<Order, Guid>(targetId);

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
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new IdFor<Order, Guid>(targetId);
            var anotherStronglyTypedId = new IdFor<PricePosition, Guid>(targetId);

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
            var stronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());
            var anotherStronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());

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