using System.Collections.Generic;
using System.Linq;

namespace StronglyTypedIds.Utils
{
    public static class IdUtils
    {
        public static IdFor<TEntity, TKey> AsId<TEntity, TKey>(this TEntity entity)
            where TEntity : class, IEntityWithId<TKey>
        {
            return new IdFor<TEntity, TKey>(entity.Id);
        }

        public static IEnumerable<IdFor<TEntity, TKey>> AsIds<TEntity, TKey>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntityWithId<TKey>
        {
            return entities.Select(entity => new IdFor<TEntity, TKey>(entity.Id));
        }

        public static IEnumerable<TKey> AsIds<TEntity, TKey>(this IEnumerable<IdFor<TEntity, TKey>> ids)
            where TEntity : class, IEntityWithId<TKey>
        {
            return ids.Select(id => id.Value);
        }
    }
}