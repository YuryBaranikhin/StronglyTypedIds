using System;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class IdTests
    {
        /// <summary>
        /// Tests for <see cref="IdFor{TEntity,TId}.ToString"/>
        /// </summary>
        public class ToStringTests
        {
            [Fact]
            public void ShouldProvideValueString()
            {
                // arrange
                var targetId = Guid.NewGuid();
                var stronglyTypedId = new IdFor<Order, Guid>(targetId);

                // act
                var providedValue = stronglyTypedId.ToString();

                // assert
                providedValue.Should().Be(targetId.ToString());
            }
            
            [Fact]
            public void ShouldNotThrowWhenValueIsNull()
            {
                // arrange
                var stronglyTypedId = new IdFor<Order, object>(null);

                // act
                Func<string> act = () => stronglyTypedId.ToString();

                // assert
                act.Should().NotThrow();
            }
        }
    }
}