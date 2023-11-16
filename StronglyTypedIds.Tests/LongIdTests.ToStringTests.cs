using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class LongIdTests
{
    /// <summary>
    ///     Tests for <see cref="LongFor{TEntity}.ToString" />
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

        [Theory]
        [MemberData(nameof(GetLongFormats), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedValueString(string format)
        {
            // arrange
            var targetId = Faker.Random.Long();
            var stronglyTypedId = new LongFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString(format);

            // assert
            providedValue.Should().Be(targetId.ToString(format));
        }

        [Theory]
        [MemberData(nameof(GetLongFormatsWithCultures), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedWithFormatterValueString(string format, CultureInfo cultureInfo)
        {
            // arrange
            var targetId = Faker.Random.Long();
            var zeroId = new LongFor<Order>(0);
            var stronglyTypedId = new LongFor<Order>(targetId);
            var oppositeStronglyTypedId = new LongFor<Order>(-1 * targetId);

            // act
            var results = new Dictionary<LongFor<Order>, string>
            {
                { zeroId, zeroId.ToString(format, cultureInfo) },
                { stronglyTypedId, stronglyTypedId.ToString(format, cultureInfo) },
                { oppositeStronglyTypedId, oppositeStronglyTypedId.ToString(format, cultureInfo) }
            };

            // assert
            foreach (var result in results) result.Value.Should().Be(result.Key.Value.ToString(format, cultureInfo));
        }

        public static IEnumerable<object[]> GetLongFormats()
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

        public static IEnumerable<object[]> GetLongFormatsWithCultures()
        {
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            foreach (var format in GetLongFormats())
                yield return new[] { format.Single(), culture };
        }
    }
}