using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class CustomIdTests
    {
        /// <summary>
        /// Tests for custom id based on <see cref="IdFor{TEntity,TId}.GetHashCode"/>
        /// </summary>
        public class GetHashCodeTests
        {
            [Fact]
            public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
            {
                // arrange
                var targetId = Guid.NewGuid();
                var stronglyTypedId = new OrderId(targetId);
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
                var stronglyTypedId = new OrderId(targetId);
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
                var stronglyTypedId = new OrderId(Guid.NewGuid());
                var anotherStronglyTypedId = new IdFor<Order, Guid>(Guid.NewGuid());

                // act
                var hashCode1 = stronglyTypedId.GetHashCode();
                var hashCode2 = anotherStronglyTypedId.GetHashCode();

                // assert
                hashCode1.Should().NotBe(hashCode2);
            }
        }
    }
}