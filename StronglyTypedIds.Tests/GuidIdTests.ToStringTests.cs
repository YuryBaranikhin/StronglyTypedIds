using System.Globalization;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class GuidIdTests
{
    /// <summary>
    ///     Tests for <see cref="GuidFor{TEntity}.ToString" />
    /// </summary>
    public class ToStringTests
    {
        [Fact]
        public void ShouldProvideValueString()
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString();

            // assert
            providedValue.Should().Be(targetId.ToString());
        }

        [Theory]
        [MemberData(nameof(GetGuidFormats), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedValueString(string format)
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString(format);

            // assert
            providedValue.Should().Be(targetId.ToString(format));
        }

        [Theory]
        [MemberData(nameof(GetGuidFormatsWithCultures), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedWithFormatterValueString(string format, CultureInfo cultureInfo)
        {
            // arrange
            var targetId = Guid.NewGuid();
            var stronglyTypedId = new GuidFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString(format, cultureInfo);

            // assert
            providedValue.Should().Be(targetId.ToString(format, cultureInfo));
        }

        public static IEnumerable<object[]> GetGuidFormats()
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { "N" };
            yield return new object[] { "D" };
            yield return new object[] { "B" };
            yield return new object[] { "P" };
            yield return new object[] { "X" };
        }

        public static IEnumerable<object[]> GetGuidFormatsWithCultures()
        {
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            foreach (var format in GetGuidFormats())
                yield return new[] { format.Single(), culture };
        }
    }
}