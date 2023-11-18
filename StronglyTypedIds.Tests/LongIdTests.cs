using Bogus;
using JetBrains.Annotations;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="LongFor{TEntity}" />
/// </summary>
public partial class LongIdTests
{
    private static readonly Faker Faker = new();

    private sealed class Order
    {
        public long Id { get; set; }
    }

    [UsedImplicitly]
    private sealed class PricePosition
    {
        public long Id { get; set; }
    }
}