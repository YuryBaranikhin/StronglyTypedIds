namespace StronglyTypedIds.Utils;

/// <summary>
///     Набор вспомогательных методов для <see cref="IntFor{TEntity}" />.
/// </summary>
public static class IntIdUtils
{
    /// <summary>
    ///     Представляет <paramref name="value" /> в виде <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="value">Значение базового идентификатора сущности <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает экземпляр <see cref="IntFor{TEntity}" />.</returns>
    public static IntFor<TEntity> AsIdFor<TEntity>(this int value)
    {
        return new IntFor<TEntity>(value);
    }

    /// <summary>
    ///     Представляет перечисление <paramref name="values" /> в виде перечисления <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="values">Перечисление значений базовых идентификаторов сущности <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление экземпляров <see cref="IntFor{TEntity}" />.</returns>
    public static IEnumerable<IntFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<int> values)
    {
        return values.Select(value => new IntFor<TEntity>(value));
    }

    /// <summary>
    ///     Представляет экземпляр сущности <typeparamref name="TEntity" /> в виде <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">Экземпляр идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает экземпляр <see cref="IntFor{TEntity}" />.</returns>
    public static IntFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<int>
    {
        return new IntFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Представляет перечисление экземпляров сущности <typeparamref name="TEntity" /> в виде перечисления
    ///     <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">Перечисление экземпляров идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление экземпляров <see cref="IntFor{TEntity}" />.</returns>
    public static IEnumerable<IntFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<int>
    {
        return entities.Select(entity => new IntFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Представляет перечисление экземпляров <see cref="IntFor{TEntity}" /> в виде перечисления базовых идентификаторов.
    /// </summary>
    /// <param name="ids">Перечисление экземпляров <see cref="IntFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление базовых идентификаторов.</returns>
    public static IEnumerable<int> AsIds<TEntity>(this IEnumerable<IntFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<int>
    {
        return ids.Select(id => id.Value);
    }
}