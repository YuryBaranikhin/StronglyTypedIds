using System;
using System.Collections.Generic;

namespace StronglyTypedIds
{
    public class IdFor<TEntity, TId> : IEntityId<TEntity, TId>, IEquatable<IdFor<TEntity, TId>>, IEquatable<IEntityId<TEntity, TId>>
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

        public bool Equals(IEntityId<TEntity, TId>? other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TId>.Default.Equals(Value, other.Value);
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
            return obj is IEntityId<TEntity, TId> other && Equals(other);
        }
        
        public static bool operator ==(IdFor<TEntity, TId>? x, IdFor<TEntity, TId>? y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        public static bool operator !=(IdFor<TEntity, TId>? x, IdFor<TEntity, TId>? y)
        {
            return !(x == y);
        }

        public static bool operator ==(IdFor<TEntity, TId>? x, IEntityId<TEntity, TId>? y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        public static bool operator !=(IdFor<TEntity, TId>? x, IEntityId<TEntity, TId>? y)
        {
            return !(x == y);
        }
    }
}