namespace StronglyTypedIds.Utils;

/// <summary>
///     A set of helper methods for <see cref="IdFor{TEntity, TKey}" />.
/// </summary>
public static class IdUtils
{
    /// <summary>
    ///     Represents an instance of the entity <typeparamref name="TEntity" /> as a <see cref="IdFor{TEntity, TKey}" />.
    /// </summary>
    /// <param name="entity">An instance of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <typeparam name="TKey">The base type of the entity's identifier.</typeparam>
    /// <returns>Returns an instance of <see cref="IdFor{TEntity, TKey}" />.</returns>
    public static IdFor<TEntity, TKey> AsId<TEntity, TKey>(this TEntity entity)
        where TEntity : class, IEntityWithId<TKey>
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new IdFor<TEntity, TKey>(entity.Id);
    }

    /// <summary>
    ///     Represents an enumeration of instances of the entity <typeparamref name="TEntity" /> as an enumeration of <see cref="IdFor{TEntity, TKey}" />.
    /// </summary>
    /// <param name="entities">An enumeration of instances of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <typeparam name="TKey">The base type of the entity's identifier.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="IdFor{TEntity, TKey}" />.</returns>
    public static IEnumerable<IdFor<TEntity, TKey>> AsIds<TEntity, TKey>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<TKey>
    {
        return entities.Select(entity => new IdFor<TEntity, TKey>(entity.Id));
    }

    /// <summary>
    ///     Represents an enumeration of instances of <see cref="IdFor{TEntity, TKey}" /> as an enumeration of base identifiers.
    /// </summary>
    /// <param name="ids">An enumeration of instances of <see cref="IdFor{TEntity, TKey}" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <typeparam name="TKey">The base type of the entity's identifier.</typeparam>
    /// <returns>Returns an enumeration of base identifiers.</returns>
    public static IEnumerable<TKey> AsIds<TEntity, TKey>(this IEnumerable<IdFor<TEntity, TKey>> ids)
        where TEntity : class, IEntityWithId<TKey>
    {
        return ids.Select(id => id.Value);
    }
}