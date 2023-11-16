namespace StronglyTypedIds.Utils;

/// <summary>
///     Набор вспомогательных методов для <see cref="GuidFor{TEntity}" />.
/// </summary>
public static class GuidIdUtils
{
    /// <summary>
    ///     Представляет <paramref name="value" /> в виде <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="value">Значение базового идентификатора сущности <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает экземпляр <see cref="GuidFor{TEntity}" />.</returns>
    public static GuidFor<TEntity> AsIdFor<TEntity>(this Guid value)
    {
        return new GuidFor<TEntity>(value);
    }

    /// <summary>
    ///     Представляет перечисление <paramref name="values" /> в виде перечисления <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="values">Перечисление значений базовых идентификаторов сущности <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление экземпляров <see cref="GuidFor{TEntity}" />.</returns>
    public static IEnumerable<GuidFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<Guid> values)
    {
        return values.Select(value => new GuidFor<TEntity>(value));
    }

    /// <summary>
    ///     Представляет экземпляр сущности <typeparamref name="TEntity" /> в виде <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">Экземпляр идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает экземпляр <see cref="GuidFor{TEntity}" />.</returns>
    public static GuidFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<Guid>
    {
        return new GuidFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Представляет перечисление экземпляров сущности <typeparamref name="TEntity" /> в виде перечисления
    ///     <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">Перечисление экземпляров идентифицируемой сущности.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление экземпляров <see cref="GuidFor{TEntity}" />.</returns>
    public static IEnumerable<GuidFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<Guid>
    {
        return entities.Select(entity => new GuidFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Представляет перечисление экземпляров <see cref="GuidFor{TEntity}" /> в виде перечисления базовых идентификаторов.
    /// </summary>
    /// <param name="ids">Перечисление экземпляров <see cref="GuidFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности.</typeparam>
    /// <returns>Возвращает перечисление базовых идентификаторов.</returns>
    public static IEnumerable<Guid> AsIds<TEntity>(this IEnumerable<GuidFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<Guid>
    {
        return ids.Select(id => id.Value);
    }
}