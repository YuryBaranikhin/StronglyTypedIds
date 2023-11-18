namespace StronglyTypedIds.Utils;

/// <summary>
///     A set of helper methods for <see cref="LongFor{TEntity}" />.
/// </summary>
public static class LongIdUtils
{
    /// <summary>
    ///     Represents <paramref name="value" /> as a <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="value">The value of the base identifier of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="LongFor{TEntity}" />.</returns>
    public static LongFor<TEntity> AsIdFor<TEntity>(this long value)
    {
        return new LongFor<TEntity>(value);
    }

    /// <summary>
    ///     Represents the enumeration <paramref name="values" /> as an enumeration of <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="values">An enumeration of the values of the base identifiers of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="LongFor{TEntity}" />.</returns>
    public static IEnumerable<LongFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<long> values)
    {
        return values.Select(value => new LongFor<TEntity>(value));
    }

    /// <summary>
    ///     Represents an instance of the entity <typeparamref name="TEntity" /> as a <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">An instance of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="LongFor{TEntity}" />.</returns>
    public static LongFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<long>
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new LongFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Represents an enumeration of instances of the entity <typeparamref name="TEntity" /> as an enumeration of <see cref="LongFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">An enumeration of instances of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="LongFor{TEntity}" />.</returns>
    public static IEnumerable<LongFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<long>
    {
        return entities.Select(entity => new LongFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Represents an enumeration of instances of <see cref="LongFor{TEntity}" /> as an enumeration of base identifiers.
    /// </summary>
    /// <param name="ids">An enumeration of instances of <see cref="LongFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of base identifiers.</returns>
    public static IEnumerable<long> AsIds<TEntity>(this IEnumerable<LongFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<long>
    {
        return ids.Select(id => id.Value);
    }
}