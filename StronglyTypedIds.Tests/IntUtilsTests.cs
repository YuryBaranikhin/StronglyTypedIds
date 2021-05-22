using System.Linq;
using Bogus;
using FluentAssertions;
using StronglyTypedIds.Utils;
using Xunit;

namespace StronglyTypedIds.Tests
{
    /// <summary>
    /// Tests for <see cref="IntIdUtils"/>
    /// </summary>
    public class IntUtilsTests
    {
        private static readonly Faker Faker = new Faker();

        /// <summary>
        /// Tests for <see cref="IntIdUtils.AsIdFor{TEntity}"/>
        /// </summary>
        public class AsIdForTests
        {
            [Fact]
            public void ShouldBeCreatedFromBaseId()
            {
                // arrange
                var baseId = Faker.Random.Int();
            
                // act
                var stronglyTypedId = baseId.AsIdFor<Order>();

                // assert
                stronglyTypedId.Should().BeOfType<IntFor<Order>>();
                stronglyTypedId.Value.Should().Be(baseId);
            }
        }

        /// <summary>
        /// Tests for <see cref="IntIdUtils.AsIdsFor{TEntity}"/>
        /// </summary>
        public class AsIdsForTests
        {
            [Fact]
            public void ShouldBeCreatedFromBaseIds()
            {
                // arrange
                var baseIds = new[] {Faker.Random.Int(), Faker.Random.Int(), Faker.Random.Int()};

                // act
                var stronglyTypedIds = baseIds.AsIdsFor<Order>();

                // assert
                stronglyTypedIds.Should().AllBeOfType<IntFor<Order>>();
                stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(baseIds);
            }
        }

        /// <summary>
        /// Tests for <see cref="IntIdUtils.AsId"/>
        /// </summary>
        public class AsIdTests
        {
            [Fact]
            public void ShouldBeCreatedFromEntity()
            {
                // arrange
                var baseId = Faker.Random.Int();
                var entity = new Order {Id = baseId};

                // act
                var stronglyTypedId = entity.AsId();

                // assert
                stronglyTypedId.Should().BeOfType<IntFor<Order>>();
                stronglyTypedId.Value.Should().Be(baseId);
            }
        }

        /// <summary>
        /// Tests for <see cref="IntIdUtils.AsIds"/>
        /// </summary>
        public class AsIdsTests
        {
            [Fact]
            public void ShouldBeCreatedFromEntities()
            {
                // arrange
                var entities = new[]
                {
                    new Order {Id = Faker.Random.Int()},
                    new Order {Id = Faker.Random.Int()},
                    new Order {Id = Faker.Random.Int()},
                };

                // act
                var stronglyTypedIds = entities.AsIds();

                // assert
                stronglyTypedIds.Should().AllBeOfType<IntFor<Order>>();
                stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(entities.Select(x => x.Id));
            }
        
            [Fact]
            public void ShouldBeTransformedToBaseIds()
            {
                // arrange
                var baseIds = new[] {Faker.Random.Int(), Faker.Random.Int(), Faker.Random.Int()};
                var stronglyTypedIds = baseIds.AsIdsFor<Order>();

                // act
                var targetIds = stronglyTypedIds.AsIds();

                // assert
                targetIds.Should().BeEquivalentTo(baseIds);
            }
        }
        
        private class Order : IEntityWithId<int>
        {
            public int Id { get; set; }
        }
    }
}