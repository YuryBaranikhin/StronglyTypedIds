using System.Globalization;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class ULongIdTests
{
    /// <summary>
    ///     Tests for <see cref="ULongFor{TEntity}.ToString" />
    /// </summary>
    public class ToStringTests
    {
        [Fact]
        public void ShouldProvideValueString()
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString();

            // assert
            providedValue.Should().Be(targetId.ToString());
        }

        [Theory]
        [MemberData(nameof(GetULongFormats), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedValueString(string format)
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var stronglyTypedId = new ULongFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString(format);

            // assert
            providedValue.Should().Be(targetId.ToString(format));
        }

        [Theory]
        [MemberData(nameof(GetULongFormatsWithCultures), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedWithFormatterValueString(string format, CultureInfo cultureInfo)
        {
            // arrange
            var targetId = Faker.Random.ULong();
            var zeroId = new ULongFor<Order>(0);
            var stronglyTypedId = new ULongFor<Order>(targetId);

            // act
            var results = new Dictionary<ULongFor<Order>, string>
            {
                { zeroId, zeroId.ToString(format, cultureInfo) },
                { stronglyTypedId, stronglyTypedId.ToString(format, cultureInfo) },
            };

            // assert
            foreach (var result in results) result.Value.Should().Be(result.Key.Value.ToString(format, cultureInfo));
        }

        public static IEnumerable<object[]> GetULongFormats()
        {
            yield return new object[] { null };
            yield return new object[] { "" };

            yield return new object[] { "C" };
            yield return new object[] { "D" };
            yield return new object[] { "E" };
            yield return new object[] { "F" };
            yield return new object[] { "G" };
            yield return new object[] { "N" };
            yield return new object[] { "P" };
            yield return new object[] { "X" };
            yield return new object[] { "\u2030" };
        }

        public static IEnumerable<object[]> GetULongFormatsWithCultures()
        {
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            foreach (var format in GetULongFormats())
                yield return new[] { format.Single(), culture };
        }
    }
}