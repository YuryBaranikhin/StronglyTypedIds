using Bogus;
using JetBrains.Annotations;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="UIntFor{TEntity}" />
/// </summary>
public partial class UIntIdTests
{
    private static readonly Faker Faker = new();

    private sealed class Order;

    [UsedImplicitly]
    private sealed class PricePosition;
}