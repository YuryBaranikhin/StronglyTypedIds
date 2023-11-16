using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class GuidIdTests
{
    public class ValueTests
    {
        [Fact]
        public void ShouldProvideSpecifiedValue()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.Value;

            // assert
            providedValue.Should().Be(targetId);
        }
    }
}