using System.Collections.Generic;
using System.Linq;

namespace StronglyTypedIds.Utils
{
    public static class IntIdUtils
    {
        public static IntFor<TEntity> AsIdFor<TEntity>(this int value)
        {
            return new IntFor<TEntity>(value);
        }
        
        public static IEnumerable<IntFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<int> values)
        {
            return values.Select(value => new IntFor<TEntity>(value));
        }
        
        public static IntFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<int>
        {
            return new IntFor<TEntity>(entity.Id);
        }

        public static IEnumerable<IntFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntityWithId<int>
        {
            return entities.Select(entity => new IntFor<TEntity>(entity.Id));
        }

        public static IEnumerable<int> AsIds<TEntity>(this IEnumerable<IntFor<TEntity>> ids)
            where TEntity : class, IEntityWithId<int>
        {
            return ids.Select(id => id.Value);
        }
    }
}