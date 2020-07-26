using System;
using System.Collections.Generic;

namespace StronglyTypedIds
{
    public class IdFor<TEntity, TId> : IEntityId<TEntity, TId>, IEquatable<IdFor<TEntity, TId>>
    {
        public IdFor(TId value)
        {
            Value = value;
        }

        public TId Value { get; }

        public override int GetHashCode()
        {
            unchecked
            {
                return (typeof(TEntity).GetHashCode() * 73) ^ EqualityComparer<TId>.Default.GetHashCode(Value);
            }
        }

        public bool Equals(IdFor<TEntity, TId>? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TId>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IdFor<TEntity, TId>) obj);
        }
    }
}