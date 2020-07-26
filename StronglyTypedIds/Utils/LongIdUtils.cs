using System.Collections.Generic;
using System.Linq;

namespace StronglyTypedIds.Utils
{
    public static class LongIdUtils
    {
        public static LongFor<TEntity> AsIdFor<TEntity>(this long value)
        {
            return new LongFor<TEntity>(value);
        }
        
        public static IEnumerable<LongFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<long> values)
        {
            return values.Select(value => new LongFor<TEntity>(value));
        }
        
        public static LongFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<long>
        {
            return new LongFor<TEntity>(entity.Id);
        }

        public static IEnumerable<LongFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
            where TEntity : class, IEntityWithId<long>
        {
            return entities.Select(entity => new LongFor<TEntity>(entity.Id));
        }

        public static IEnumerable<long> AsIds<TEntity>(this IEnumerable<LongFor<TEntity>> ids)
            where TEntity : class, IEntityWithId<long>
        {
            return ids.Select(id => id.Value);
        }
    }
}