using System;

namespace StronglyTypedIds
{
    public struct GuidFor<TEntity> : IEntityId<TEntity, Guid>, IEquatable<GuidFor<TEntity>>, IEquatable<IEntityId<TEntity, Guid>>
    {
        public GuidFor(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (typeof(TEntity).GetHashCode() * 23) ^ Value.GetHashCode();
            }
        }

        public bool Equals(IEntityId<TEntity, Guid> other)
        {
            if (ReferenceEquals(other, null)) return false;
            return Value.Equals(other.Value);
        }

        public bool Equals(GuidFor<TEntity> other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is IEntityId<TEntity, Guid> other && Equals(other);
        }

        public static bool operator ==(GuidFor<TEntity> x, GuidFor<TEntity> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(GuidFor<TEntity> x, GuidFor<TEntity> y)
        {
            return !(x == y);
        }

        public static bool operator ==(GuidFor<TEntity> x, IEntityId<TEntity, Guid> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(GuidFor<TEntity> x, IEntityId<TEntity, Guid> y)
        {
            return !(x == y);
        }
    }
}