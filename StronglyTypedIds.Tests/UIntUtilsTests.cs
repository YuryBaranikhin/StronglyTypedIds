using Bogus;
using FluentAssertions;
using StronglyTypedIds.Utils;
using Xunit;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="UIntIdUtils" />
/// </summary>
public class UIntUtilsTests
{
    private static readonly Faker Faker = new();

    /// <summary>
    ///     Tests for <see cref="UIntIdUtils.AsIdFor{TEntity}" />
    /// </summary>
    public class AsIdForTests
    {
        [Fact]
        public void ShouldBeCreatedFromBaseId()
        {
            // arrange
            var baseId = Faker.Random.UInt();

            // act
            var stronglyTypedId = baseId.AsIdFor<Order>();

            // assert
            stronglyTypedId.Should().BeOfType<UIntFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }
    }

    /// <summary>
    ///     Tests for <see cref="UIntIdUtils.AsIdsFor{TEntity}" />
    /// </summary>
    public class AsIdsForTests
    {
        [Fact]
        public void ShouldBeCreatedFromBaseIds()
        {
            // arrange
            var baseIds = new[] { Faker.Random.UInt(), Faker.Random.UInt(), Faker.Random.UInt() };

            // act
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // assert
            stronglyTypedIds.Should().AllBeOfType<UIntFor<Order>>();
            stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(baseIds);
        }
    }

    /// <summary>
    ///     Tests for <see cref="UIntIdUtils.AsId" />
    /// </summary>
    public class AsIdTests
    {
        [Fact]
        public void ShouldBeCreatedFromEntity()
        {
            // arrange
            var baseId = Faker.Random.UInt();
            var entity = new Order { Id = baseId };

            // act
            var stronglyTypedId = entity.AsId();

            // assert
            stronglyTypedId.Should().BeOfType<UIntFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }
    }

    /// <summary>
    ///     Tests for <see cref="UIntIdUtils.AsIds" />
    /// </summary>
    public class AsIdsTests
    {
        [Fact]
        public void ShouldBeCreatedFromEntities()
        {
            // arrange
            var entities = new[]
            {
                new Order { Id = Faker.Random.UInt() },
                new Order { Id = Faker.Random.UInt() },
                new Order { Id = Faker.Random.UInt() }
            };

            // act
            var stronglyTypedIds = entities.AsIds();

            // assert
            stronglyTypedIds.Should().AllBeOfType<UIntFor<Order>>();
            stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(entities.Select(x => x.Id));
        }

        [Fact]
        public void ShouldBeTransformedToBaseIds()
        {
            // arrange
            var baseIds = new[] { Faker.Random.UInt(), Faker.Random.UInt(), Faker.Random.UInt() };
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // act
            var targetIds = stronglyTypedIds.AsIds();

            // assert
            targetIds.Should().BeEquivalentTo(baseIds);
        }
    }

    private sealed class Order : IEntityWithId<uint>
    {
        public uint Id { get; set; }
    }
}