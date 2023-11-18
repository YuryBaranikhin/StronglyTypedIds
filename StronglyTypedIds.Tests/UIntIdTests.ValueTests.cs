using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.Value" />
    /// </summary>
    public class ValueTests
    {
        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }
    }
}