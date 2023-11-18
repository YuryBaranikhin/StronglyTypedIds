using JetBrains.Annotations;

namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for <see cref="GuidFor{TEntity}" />
/// </summary>
public partial class GuidIdTests
{
    private sealed class Order
    {
        public Guid Id { get; set; }
    }

    [UsedImplicitly]
    private sealed class PricePosition
    {
        public Guid Id { get; set; }
    }
}