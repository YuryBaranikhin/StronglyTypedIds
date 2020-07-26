using System;
using System.Collections.Generic;
using System.Linq;

namespace StronglyTypedIds.Utils
{
    public static class GuidIdUtils
    {
        public static GuidFor<TEntity> AsIdFor<TEntity>(this Guid value)
        {
            return new GuidFor<TEntity>(value);
        }

        public static IEnumerable<GuidFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<Guid> values)
        {
            return values.Select(value => new GuidFor<TEntity>(value));
        }

        public static GuidFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<Guid>
        {
            return new GuidFor<TEntity>(entity.Id);
        }

        public static IEnumerable<GuidFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntityWithId<Guid>
        {
            return entities.Select(entity => new GuidFor<TEntity>(entity.Id));
        }

        public static IEnumerable<Guid> AsIds<TEntity>(this IEnumerable<GuidFor<TEntity>> ids)
            where TEntity : class, IEntityWithId<Guid>
        {
            return ids.Select(id => id.Value);
        }
    }
}