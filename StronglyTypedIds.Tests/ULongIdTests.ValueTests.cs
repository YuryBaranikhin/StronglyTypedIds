using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class ULongIdTests
{
    /// <summary>
    ///     Tests for <see cref="ULongFor{TEntity}.Value" />
    /// </summary>
    public class ValueTests
    {
        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }
    }
}