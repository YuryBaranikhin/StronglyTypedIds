using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class IntIdTests
    {
        /// <summary>
        /// Tests for <see cref="IntFor{TEntity}.Value"/>
        /// </summary>
        public class ValueTests
        {
            [Fact]
            public void ShouldProvideSpecifiedValue()
            {
                // arrange
                var targetId = Faker.Random.Int();
                var stronglyTypedId = new IntFor<Order>(targetId);

                // act
                var providedValue = stronglyTypedId.Value;

                // assert
                providedValue.Should().Be(targetId);
            }
        }
    }
}