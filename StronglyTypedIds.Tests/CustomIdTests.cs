namespace StronglyTypedIds.Tests;

/// <summary>
///     Tests for custom id based on <see cref="IdFor{TEntity,TId}" />
/// </summary>
public partial class CustomIdTests
{
    private sealed class Order
    {
    }

    private sealed class PricePosition
    {
    }

    private sealed class OrderId : IdFor<Order, Guid>
    {
        public OrderId(Guid value) : base(value)
        {
        }
    }
}