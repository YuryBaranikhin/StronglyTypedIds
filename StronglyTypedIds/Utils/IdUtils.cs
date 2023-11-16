using System.Collections.Generic;
using System.Linq;

namespace StronglyTypedIds.Utils;

/// <summary>
///     Набор вспомогательных методов для <see cref="IdFor{TEntity, TKey}" />.
/// </summary>
public static class IdUtils
{
    /// <summary>
    ///     Представляет экземпляр сущности <typeparamref name="TEntity" /> в виде <see cref="IdFor{TEntity, TKey}" />.
    /// </summary>
    /// <param name="entity">Экземпляр идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <typeparam name="TKey">Тип базового идентификатора сущности <typeparamref name="TEntity" />.</typeparam>
    /// <returns>Возвращает экземпляр <see cref="IdFor{TEntity, TKey}" />.</returns>
    public static IdFor<TEntity, TKey> AsId<TEntity, TKey>(this TEntity entity)
        where TEntity : class, IEntityWithId<TKey>
    {
        return new IdFor<TEntity, TKey>(entity.Id);
    }

    /// <summary>
    ///     Представляет перечисление экземпляров сущности <typeparamref name="TEntity" /> в виде перечисления
    ///     <see cref="IdFor{TEntity, TKey}" />.
    /// </summary>
    /// <param name="entities">Перечисление экземпляров идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <typeparam name="TKey">Тип базового идентификатора сущности <typeparamref name="TEntity" />.</typeparam>
    /// <returns>Возвращает перечисление экземпляров <see cref="IdFor{TEntity, TKey}" />.</returns>
    public static IEnumerable<IdFor<TEntity, TKey>> AsIds<TEntity, TKey>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<TKey>
    {
        return entities.Select(entity => new IdFor<TEntity, TKey>(entity.Id));
    }

    /// <summary>
    ///     Представляет перечисление экземпляров <see cref="IdFor{TEntity, TKey}" /> в виде перечисления базовых
    ///     идентификаторов.
    /// </summary>
    /// <param name="ids">Перечисление экземпляров <see cref="IdFor{TEntity, TKey}" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <typeparam name="TKey">Тип базового идентификатора сущности <typeparamref name="TEntity" />.</typeparam>
    /// <returns>Возвращает перечисление базовых идентификаторов.</returns>
    public static IEnumerable<TKey> AsIds<TEntity, TKey>(this IEnumerable<IdFor<TEntity, TKey>> ids)
        where TEntity : class, IEntityWithId<TKey>
    {
        return ids.Select(id => id.Value);
    }
}