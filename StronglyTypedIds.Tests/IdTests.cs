using JetBrains.Annotations;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="IdFor{TEntity,TId}" />
/// </summary>
public partial class IdTests
{
    private sealed class Order
    {
    }

    [UsedImplicitly]
    private sealed class PricePosition
    {
    }
}