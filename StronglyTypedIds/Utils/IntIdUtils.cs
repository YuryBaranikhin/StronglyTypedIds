namespace StronglyTypedIds.Utils;

/// <summary>
///     A set of helper methods for <see cref="IntFor{TEntity}" />.
/// </summary>
public static class IntIdUtils
{
    /// <summary>
    ///     Represents <paramref name="value" /> as a <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="value">The value of the base identifier of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="IntFor{TEntity}" />.</returns>
    public static IntFor<TEntity> AsIdFor<TEntity>(this int value)
    {
        return new IntFor<TEntity>(value);
    }

    /// <summary>
    ///     Represents the enumeration <paramref name="values" /> as an enumeration of <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="values">An enumeration of the values of the base identifiers of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="IntFor{TEntity}" />.</returns>
    public static IEnumerable<IntFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<int> values)
    {
        return values.Select(value => new IntFor<TEntity>(value));
    }

    /// <summary>
    ///     Represents an instance of the entity <typeparamref name="TEntity" /> as a <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">An instance of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="IntFor{TEntity}" />.</returns>
    public static IntFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<int>
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new IntFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Represents an enumeration of instances of the entity <typeparamref name="TEntity" /> as an enumeration of <see cref="IntFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">An enumeration of instances of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="IntFor{TEntity}" />.</returns>
    public static IEnumerable<IntFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<int>
    {
        return entities.Select(entity => new IntFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Represents an enumeration of instances of <see cref="IntFor{TEntity}" /> as an enumeration of base identifiers.
    /// </summary>
    /// <param name="ids">An enumeration of instances of <see cref="IntFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of base identifiers.</returns>
    public static IEnumerable<int> AsIds<TEntity>(this IEnumerable<IntFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<int>
    {
        return ids.Select(id => id.Value);
    }
}