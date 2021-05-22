using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class LongIdTests
    {
        /// <summary>
        /// Tests for <see cref="LongFor{TEntity}.Value"/>
        /// </summary>
        public class ValueTests
        {
            [Fact]
            public void ShouldProvideSpecifiedValue()
            {
                // arrange
                var targetId = Faker.Random.Long();
                var stronglyTypedId = new LongFor<Order>(targetId);

                // act
                var providedValue = stronglyTypedId.Value;

                // assert
                providedValue.Should().Be(targetId);
            }
        }
    }
}