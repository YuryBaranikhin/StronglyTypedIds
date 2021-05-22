using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public partial class IntIdTests
    {
        /// <summary>
        /// Tests for <see cref="IntFor{TEntity}.ToString"/>
        /// </summary>
        public class ToStringTests
        {
            [Fact]
            public void ShouldProvideValueString()
            {
                // arrange
                var targetId = Faker.Random.Int();
                var stronglyTypedId = new IntFor<Order>(targetId);

                // act
                var providedValue = stronglyTypedId.ToString();

                // assert
                providedValue.Should().Be(targetId.ToString());
            }
        }
    }
}