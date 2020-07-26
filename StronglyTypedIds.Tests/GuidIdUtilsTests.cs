using System;
using System.Linq;
using FluentAssertions;
using StronglyTypedIds.Utils;
using Xunit;

namespace StronglyTypedIds.Tests
{
    public class GuidUtilsTests
    {
        [Fact]
        public void ShouldBeCreatedFromBaseId()
        {
            // arrange
            var baseId = Guid.NewGuid();
            
            // act
            var stronglyTypedId = baseId.AsIdFor<Order>();

            // assert
            stronglyTypedId.Should().BeOfType<GuidFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }

        [Fact]
        public void ShouldBeCreatedFromBaseIds()
        {
            // arrange
            var baseIds = new[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};

            // act
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // assert
            stronglyTypedIds.Should().AllBeOfType<GuidFor<Order>>();
            stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(baseIds);
        }

        [Fact]
        public void ShouldBeCreatedFromEntity()
        {
            // arrange
            var baseId = Guid.NewGuid();
            var entity = new Order {Id = baseId};

            // act
            var stronglyTypedId = entity.AsId();

            // assert
            stronglyTypedId.Should().BeOfType<GuidFor<Order>>();
            stronglyTypedId.Value.Should().Be(baseId);
        }

        [Fact]
        public void ShouldBeCreatedFromEntities()
        {
            // arrange
            var entities = new[]
            {
                new Order {Id = Guid.NewGuid()},
                new Order {Id = Guid.NewGuid()},
                new Order {Id = Guid.NewGuid()},
            };

            // act
            var stronglyTypedIds = entities.AsIds();

            // assert
            stronglyTypedIds.Should().AllBeOfType<GuidFor<Order>>();
            stronglyTypedIds.Select(x => x.Value).Should().BeEquivalentTo(entities.Select(x => x.Id));
        }
        
        [Fact]
        public void ShouldBeTransformedToBaseIds()
        {
            // arrange
            var baseIds = new[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};
            var stronglyTypedIds = baseIds.AsIdsFor<Order>();

            // act
            var targetIds = stronglyTypedIds.AsIds();

            // assert
            targetIds.Should().BeEquivalentTo(baseIds);
        }

        private class Order : IEntityWithId<Guid>
        {
            public Guid Id { get; set; }
        }
    }
}