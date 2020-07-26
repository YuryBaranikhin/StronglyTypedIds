using System.Linq;
using Bogus;
using FluentAssertions;
using StronglyTypedIds.Utils;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public class LongUtilsTests
    {
        private readonly Faker faker = new Faker();
        
        [Fact]
        public void ShouldBeCreatedFromBaseId()
        {
            // arrange
            var baseId = faker.Random.Long();
            
            // act
            var stronglyTypedId = baseId.AsIdFor<Order>();

            // assert
            stronglyTypedId.Should().BeOfType<LongFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }

        [Fact]
        public void ShouldBeCreatedFromBaseIds()
        {
            // arrange
            var baseIds = new[] {faker.Random.Long(), faker.Random.Long(), faker.Random.Long()};

            // act
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // assert
            stronglyTypedIds.Should().AllBeOfType<LongFor<Order>>();
            stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(baseIds);
        }

        [Fact]
        public void ShouldBeCreatedFromEntity()
        {
            // arrange
            var baseId = faker.Random.Long();
            var entity = new Order {Id = baseId};

            // act
            var stronglyTypedId = entity.AsId();

            // assert
            stronglyTypedId.Should().BeOfType<LongFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }

        [Fact]
        public void ShouldBeCreatedFromEntities()
        {
            // arrange
            var entities = new[]
            {
                new Order {Id = faker.Random.Long()},
                new Order {Id = faker.Random.Long()},
                new Order {Id = faker.Random.Long()},
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
            var baseIds = new[] {faker.Random.Long(), faker.Random.Long(), faker.Random.Long()};
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // act
            var targetIds = stronglyTypedIds.AsIds();

            // assert
            targetIds.Should().BeEquivalentTo(baseIds);
        }

        private class Order : IEntityWithId<long>
        {
            public long Id { get; set; }
        }
    }
}