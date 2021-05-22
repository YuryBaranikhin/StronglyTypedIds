using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class GuidIdTests
    {
        /// <summary>
        /// Tests for <see cref="GuidFor{TEntity}.GetHashCode"/>
        /// </summary>
        public class GetHashCodeTests
        {
            [Fact]
            public void ShouldProvideSameHashCodeWhenValuesAndEntitiesAreEqual()
            {
                // arrange
                var targetId = Guid.NewGuid();
                var stronglyTypedId = new GuidFor<Order>(targetId);
                var anotherStronglyTypedId = new GuidFor<Order>(targetId);

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
                var stronglyTypedId = new GuidFor<Order>(targetId);
                var anotherStronglyTypedId = new GuidFor<PricePosition>(targetId);

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
                var stronglyTypedId = new GuidFor<Order>(Guid.NewGuid());
                var anotherStronglyTypedId = new GuidFor<Order>(Guid.NewGuid());

                // act
                var hashCode1 = stronglyTypedId.GetHashCode();
                var hashCode2 = anotherStronglyTypedId.GetHashCode();

                // assert
                hashCode1.Should().NotBe(hashCode2);
            }
        }
    }
}