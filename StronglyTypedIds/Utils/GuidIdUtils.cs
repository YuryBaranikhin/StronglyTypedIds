namespace StronglyTypedIds.Utils;

/// <summary>
///     A set of helper methods for <see cref="GuidFor{TEntity}" />.
/// </summary>
public static class GuidIdUtils
{
    /// <summary>
    ///     Represents <paramref name="value" /> as a <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="value">The value of the base identifier of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="GuidFor{TEntity}" />.</returns>
    public static GuidFor<TEntity> AsIdFor<TEntity>(this Guid value)
    {
        return new GuidFor<TEntity>(value);
    }

    /// <summary>
    ///     Represents the enumeration <paramref name="values" /> as an enumeration of <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="values">An enumeration of the values of the base identifiers of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="GuidFor{TEntity}" />.</returns>
    public static IEnumerable<GuidFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<Guid> values)
    {
        return values.Select(value => new GuidFor<TEntity>(value));
    }

    /// <summary>
    ///     Represents an instance of the entity <typeparamref name="TEntity" /> as a <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">An instance of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="GuidFor{TEntity}" />.</returns>
    public static GuidFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<Guid>
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new GuidFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Represents an enumeration of instances of the entity <typeparamref name="TEntity" /> as an enumeration of <see cref="GuidFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">An enumeration of instances of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="GuidFor{TEntity}" />.</returns>
    public static IEnumerable<GuidFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<Guid>
    {
        return entities.Select(entity => new GuidFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Represents an enumeration of instances of <see cref="GuidFor{TEntity}" /> as an enumeration of base identifiers.
    /// </summary>
    /// <param name="ids">An enumeration of instances of <see cref="GuidFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of base identifiers.</returns>
    public static IEnumerable<Guid> AsIds<TEntity>(this IEnumerable<GuidFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<Guid>
    {
        return ids.Select(id => id.Value);
    }
}