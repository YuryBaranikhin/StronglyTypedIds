using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class LongIdTests
    {
        /// <summary>
        /// Tests for <see cref="LongFor{TEntity}.ToString"/>
        /// </summary>
        public class ToStringTests
        {
            [Fact]
            public void ShouldProvideValueString()
            {
                // arrange
                var targetId = Faker.Random.Long();
                var stronglyTypedId = new LongFor<Order>(targetId);

                // act
                var providedValue = stronglyTypedId.ToString();

                // assert
                providedValue.Should().Be(targetId.ToString());
            }
        }
    }
}