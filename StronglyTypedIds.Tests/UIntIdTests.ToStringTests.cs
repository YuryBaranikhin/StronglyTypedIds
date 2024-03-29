﻿using System.Globalization;
using FluentAssertions;
using Xunit;

namespace StronglyTypedIds.Tests;

public partial class UIntIdTests
{
    /// <summary>
    ///     Tests for <see cref="UIntFor{TEntity}.ToString" />
    /// </summary>
    public class ToStringTests
    {
        [Fact]
        public void ShouldProvideValueString()
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString();

            // assert
            providedValue.Should().Be(targetId.ToString());
        }

        [Theory]
        [MemberData(nameof(GetUIntFormats), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedValueString(string format)
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString(format);

            // assert
            providedValue.Should().Be(targetId.ToString(format));
        }

        [Theory]
        [MemberData(nameof(GetUIntFormatsWithCultures), MemberType = typeof(ToStringTests))]
        public void ShouldProvideFormattedWithFormatterValueString(string format, CultureInfo cultureInfo)
        {
            // arrange
            var targetId = Faker.Random.UInt();
            var stronglyTypedId = new UIntFor<Order>(targetId);

            // act
            var providedValue = stronglyTypedId.ToString(format, cultureInfo);

            // assert
            providedValue.Should().Be(targetId.ToString(format, cultureInfo));
        }

        public static IEnumerable<object[]> GetUIntFormats()
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

        public static IEnumerable<object[]> GetUIntFormatsWithCultures()
        {
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            foreach (var format in GetUIntFormats())
                yield return new[] { format.Single(), culture };
        }
    }
}