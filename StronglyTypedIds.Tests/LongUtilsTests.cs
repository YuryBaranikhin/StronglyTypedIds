using System.Linq;
using Bogus;
using FluentAssertions;
using StronglyTypedIds.Utils;
using Xunit;

namespace StronglyTypedIds.Tests
{
    /// <summary>
    /// Tests for <see cref="LongIdUtils"/>
    /// </summary>
    public class LongUtilsTests
    {
        private static readonly Faker Faker = new Faker();
        
        /// <summary>
        /// Tests for <see cref="LongIdUtils.AsIdFor{TEntity}"/>
        /// </summary>
        public class AsIdForTests
        {
            [Fact]
            public void ShouldBeCreatedFromBaseId()
            {
                // arrange
                var baseId = Faker.Random.Long();
            
                // act
                var stronglyTypedId = baseId.AsIdFor<Order>();

                // assert
                stronglyTypedId.Should().BeOfType<LongFor<Order>>();
                stronglyTypedId.Value.Should().Be(baseId);
            }
        }

        /// <summary>
        /// Tests for <see cref="LongIdUtils.AsIdsFor{TEntity}"/>
        /// </summary>
        public class AsIdsForTests
        {
            [Fact]
            public void ShouldBeCreatedFromBaseIds()
            {
                // arrange
                var baseIds = new[] {Faker.Random.Long(), Faker.Random.Long(), Faker.Random.Long()};

                // act
                var stronglyTypedIds = baseIds.AsIdsFor<Order>();

                // assert
                stronglyTypedIds.Should().AllBeOfType<LongFor<Order>>();
                stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(baseIds);
            }
        }

        /// <summary>
        /// Tests for <see cref="LongIdUtils.AsId"/>
        /// </summary>
        public class AsIdTests
        {
            [Fact]
            public void ShouldBeCreatedFromEntity()
            {
                // arrange
                var baseId = Faker.Random.Long();
                var entity = new Order {Id = baseId};

                // act
                var stronglyTypedId = entity.AsId();

                // assert
                stronglyTypedId.Should().BeOfType<LongFor<Order>>();
                stronglyTypedId.Value.Should().Be(baseId);
            }
        }

        /// <summary>
        /// Tests for <see cref="LongIdUtils.AsIds"/>
        /// </summary>
        public class AsIdsTests
        {
            [Fact]
            public void ShouldBeCreatedFromEntities()
            {
                // arrange
                var entities = new[]
                {
                    new Order {Id = Faker.Random.Long()},
                    new Order {Id = Faker.Random.Long()},
                    new Order {Id = Faker.Random.Long()},
                };

                // act
                var stronglyTypedIds = entities.AsIds();

                // assert
                stronglyTypedIds.Should().AllBeOfType<LongFor<Order>>();
                stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(entities.Select(x => x.Id));
            }
        
            [Fact]
            public void ShouldBeTransformedToBaseIds()
            {
                // arrange
                var baseIds = new[] {Faker.Random.Long(), Faker.Random.Long(), Faker.Random.Long()};
                var stronglyTypedIds = baseIds.AsIdsFor<Order>();

                // act
                var targetIds = stronglyTypedIds.AsIds();

                // assert
                targetIds.Should().BeEquivalentTo(baseIds);
            }
        }
        
        private class Order : IEntityWithId<long>
        {
            public long Id { get; set; }
        }
    }
}