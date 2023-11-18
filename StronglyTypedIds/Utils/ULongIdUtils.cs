namespace StronglyTypedIds.Utils;

/// <summary>
///     A set of helper methods for <see cref="ULongFor{TEntity}" />.
/// </summary>
public static class ULongIdUtils
{
    /// <summary>
    ///     Represents <paramref name="value" /> as a <see cref="ULongFor{TEntity}" />.
    /// </summary>
    /// <param name="value">The value of the base identifier of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="ULongFor{TEntity}" />.</returns>
    public static ULongFor<TEntity> AsIdFor<TEntity>(this ulong value)
    {
        return new ULongFor<TEntity>(value);
    }

    /// <summary>
    ///     Represents the enumeration <paramref name="values" /> as an enumeration of <see cref="ULongFor{TEntity}" />.
    /// </summary>
    /// <param name="values">An enumeration of the values of the base identifiers of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="ULongFor{TEntity}" />.</returns>
    public static IEnumerable<ULongFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<ulong> values)
    {
        return values.Select(value => new ULongFor<TEntity>(value));
    }

    /// <summary>
    ///     Represents an instance of the entity <typeparamref name="TEntity" /> as a <see cref="ULongFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">An instance of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="ULongFor{TEntity}" />.</returns>
    public static ULongFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<ulong>
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new ULongFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Represents an enumeration of instances of the entity <typeparamref name="TEntity" /> as an enumeration of <see cref="ULongFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">An enumeration of instances of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="ULongFor{TEntity}" />.</returns>
    public static IEnumerable<ULongFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<ulong>
    {
        return entities.Select(entity => new ULongFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Represents an enumeration of instances of <see cref="ULongFor{TEntity}" /> as an enumeration of base identifiers.
    /// </summary>
    /// <param name="ids">An enumeration of instances of <see cref="ULongFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of base identifiers.</returns>
    public static IEnumerable<ulong> AsIds<TEntity>(this IEnumerable<ULongFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<ulong>
    {
        return ids.Select(id => id.Value);
    }
}