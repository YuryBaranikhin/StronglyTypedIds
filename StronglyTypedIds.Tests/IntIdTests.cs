using Bogus;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="IntFor{TEntity}" />
/// </summary>
public partial class IntIdTests
{
    private static readonly Faker Faker = new();

    private sealed class Order
    {
    }

    private sealed class PricePosition
    {
    }
}