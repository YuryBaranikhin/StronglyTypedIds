using System;

namespace StronglyTypedIds
{
    public struct LongFor<TEntity> : IEntityId<TEntity, long>, IEquatable<LongFor<TEntity>>, IEquatable<IEntityId<TEntity, long>>
    {
        public LongFor(long value)
        {
            Value = value;
        }

        public long Value { get; }
        
        public override int GetHashCode()
        {
            unchecked
            {
                return (typeof(TEntity).GetHashCode() * 23) ^ Value.GetHashCode();
            }
        }

        public bool Equals(IEntityId<TEntity, long> other)
        {
            if (ReferenceEquals(other, null)) return false;
            return Value.Equals(other.Value);
        }

        public bool Equals(LongFor<TEntity> other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is IEntityId<TEntity, long> other && Equals(other);
        }

        public static bool operator ==(LongFor<TEntity> x, LongFor<TEntity> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(LongFor<TEntity> x, LongFor<TEntity> y)
        {
            return !(x == y);
        }

        public static bool operator ==(LongFor<TEntity> x, IEntityId<TEntity, long> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(LongFor<TEntity> x, IEntityId<TEntity, long> y)
        {
            return !(x == y);
        }
    }
}