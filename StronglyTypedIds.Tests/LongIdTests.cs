using Bogus;

namespace StronglyTypedIds.Tests
{
    /// <summary>
    /// Tests for <see cref="LongFor{TEntity}"/>
    /// </summary>
    public partial class LongIdTests
    {
        private static readonly Faker Faker = new Faker();

        private class Order
        {
            public long Id { get; set; }
        }

        private class PricePosition
        {
            public long Id { get; set; }
        }
    }
}