using System;

namespace StronglyTypedIds
{
    public struct IntFor<TEntity> : IEntityId<TEntity, int>, IEquatable<IntFor<TEntity>>,
        IEquatable<IEntityId<TEntity, int>>
    {
        public IntFor(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public override int GetHashCode()
        {
            unchecked
            {
                return (typeof(TEntity).GetHashCode() * 73) ^ Value.GetHashCode();
            }
        }

        public bool Equals(IEntityId<TEntity, int> other)
        {
            if (ReferenceEquals(other, null)) return false;
            return Value.Equals(other.Value);
        }

        public bool Equals(IntFor<TEntity> other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is IEntityId<TEntity, int> other && Equals(other);
        }

        public static bool operator ==(IntFor<TEntity> x, IntFor<TEntity> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(IntFor<TEntity> x, IntFor<TEntity> y)
        {
            return !(x == y);
        }

        public static bool operator ==(IntFor<TEntity> x, IEntityId<TEntity, int> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(IntFor<TEntity> x, IEntityId<TEntity, int> y)
        {
            return !(x == y);
        }
    }
}