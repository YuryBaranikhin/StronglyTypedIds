﻿using System;

namespace StronglyTypedIds.Tests
{
    /// <summary>
    /// Tests for <see cref="GuidFor{TEntity}"/>
    /// </summary>
    public partial class GuidIdTests
    {
        private class Order
        {
            public Guid Id { get; set; }
        }

        private class PricePosition
        {
            public Guid Id { get; set; }
        }
    }
}