using System;

namespace StronglyTypedIds.Tests
{
    /// <summary>
    /// Tests for custom id based on <see cref="IdFor{TEntity,TId}"/>
    /// </summary>
    public partial class CustomIdTests
    {
        private class Order
        {
        }

        private class PricePosition
        {
        }
        
        private class OrderId: IdFor<Order, Guid>
        {
            public OrderId(Guid value) : base(value)
            {
            }
        }
    }
}