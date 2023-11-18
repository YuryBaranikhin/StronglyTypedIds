using Bogus;
using FluentAssertions;
using StronglyTypedIds.Utils;
using Xunit;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="ULongIdUtils" />
/// </summary>
public class ULongUtilsTests
{
    private static readonly Faker Faker = new();

    /// <summary>
    ///     Tests for <see cref="ULongIdUtils.AsIdFor{TEntity}" />
    /// </summary>
    public class AsIdForTests
    {
        [Fact]
        public void ShouldBeCreatedFromBaseId()
        {
            // arrange
            var baseId = Faker.Random.ULong();

            // act
            var stronglyTypedId = baseId.AsIdFor<Order>();

            // assert
            stronglyTypedId.Should().BeOfType<ULongFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }
    }

    /// <summary>
    ///     Tests for <see cref="ULongIdUtils.AsIdsFor{TEntity}" />
    /// </summary>
    public class AsIdsForTests
    {
        [Fact]
        public void ShouldBeCreatedFromBaseIds()
        {
            // arrange
            var baseIds = new[] { Faker.Random.ULong(), Faker.Random.ULong(), Faker.Random.ULong() };

            // act
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // assert
            stronglyTypedIds.Should().AllBeOfType<ULongFor<Order>>();
            stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(baseIds);
        }
    }

    /// <summary>
    ///     Tests for <see cref="ULongIdUtils.AsId" />
    /// </summary>
    public class AsIdTests
    {
        [Fact]
        public void ShouldBeCreatedFromEntity()
        {
            // arrange
            var baseId = Faker.Random.ULong();
            var entity = new Order { Id = baseId };

            // act
            var stronglyTypedId = entity.AsId();

            // assert
            stronglyTypedId.Should().BeOfType<ULongFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }
    }

    /// <summary>
    ///     Tests for <see cref="ULongIdUtils.AsIds" />
    /// </summary>
    public class AsIdsTests
    {
        [Fact]
        public void ShouldBeCreatedFromEntities()
        {
            // arrange
            var entities = new[]
            {
                new Order { Id = Faker.Random.ULong() },
                new Order { Id = Faker.Random.ULong() },
                new Order { Id = Faker.Random.ULong() }
            };

            // act
            var stronglyTypedIds = entities.AsIds();

            // assert
            stronglyTypedIds.Should().AllBeOfType<ULongFor<Order>>();
            stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(entities.Select(x => x.Id));
        }

        [Fact]
        public void ShouldBeTransformedToBaseIds()
        {
            // arrange
            var baseIds = new[] { Faker.Random.ULong(), Faker.Random.ULong(), Faker.Random.ULong() };
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // act
            var targetIds = stronglyTypedIds.AsIds();

            // assert
            targetIds.Should().BeEquivalentTo(baseIds);
        }
    }

    private sealed class Order : IEntityWithId<ulong>
    {
        public ulong Id { get; set; }
    }
}