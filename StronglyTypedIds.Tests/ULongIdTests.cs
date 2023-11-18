using Bogus;
using JetBrains.Annotations;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="ULongFor{TEntity}" />
/// </summary>
public partial class ULongIdTests
{
    private static readonly Faker Faker = new();

    private sealed class Order
    {
        public ulong Id { get; set; }
    }

    [UsedImplicitly]
    private sealed class PricePosition
    {
        public ulong Id { get; set; }
    }
}