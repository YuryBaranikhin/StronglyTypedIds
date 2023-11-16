using System.Collections.Generic;
using System.Linq;

namespace StronglyTypedIds.Utils;

/// <summary>
///     Набор вспомогательных методов для <see cref="LongFor{TEntity}" />.
/// </summary>
public static class LongIdUtils
{
    /// <summary>
    ///     Представляет <paramref name="value" /> в виде <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="value">Значение базового идентификатора сущности <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает экземпляр <see cref="LongFor{TEntity}" />.</returns>
    public static LongFor<TEntity> AsIdFor<TEntity>(this long value)
    {
        return new LongFor<TEntity>(value);
    }

    /// <summary>
    ///     Представляет перечисление <paramref name="values" /> в виде перечисления <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="values">Перечисление значений базовых идентификаторов сущности <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление экземпляров <see cref="LongFor{TEntity}" />.</returns>
    public static IEnumerable<LongFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<long> values)
    {
        return values.Select(value => new LongFor<TEntity>(value));
    }

    /// <summary>
    ///     Представляет экземпляр сущности <typeparamref name="TEntity" /> в виде <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">Экземпляр идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает экземпляр <see cref="LongFor{TEntity}" />.</returns>
    public static LongFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<long>
    {
        return new LongFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Представляет перечисление экземпляров сущности <typeparamref name="TEntity" /> в виде перечисления
    ///     <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">Перечисление экземпляров идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление экземпляров <see cref="LongFor{TEntity}" />.</returns>
    public static IEnumerable<LongFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<long>
    {
        return entities.Select(entity => new LongFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Представляет перечисление экземпляров <see cref="LongFor{TEntity}" /> в виде перечисления базовых идентификаторов.
    /// </summary>
    /// <param name="ids">Перечисление экземпляров <see cref="LongFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление базовых идентификаторов.</returns>
    public static IEnumerable<long> AsIds<TEntity>(this IEnumerable<LongFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<long>
    {
        return ids.Select(id => id.Value);
    }
}