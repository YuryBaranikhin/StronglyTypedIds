namespace StronglyTypedIds.Utils;

/// <summary>
///     A set of helper methods for <see cref="UIntFor{TEntity}" />.
/// </summary>
public static class UIntIdUtils
{
    /// <summary>
    ///     Represents <paramref name="value" /> as a <see cref="UIntFor{TEntity}" />.
    /// </summary>
    /// <param name="value">The value of the base identifier of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="UIntFor{TEntity}" />.</returns>
    public static UIntFor<TEntity> AsIdFor<TEntity>(this uint value)
    {
        return new UIntFor<TEntity>(value);
    }

    /// <summary>
    ///     Represents the enumeration <paramref name="values" /> as an enumeration of <see cref="UIntFor{TEntity}" />.
    /// </summary>
    /// <param name="values">An enumeration of the values of the base identifiers of the entity <typeparamref name="TEntity" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="UIntFor{TEntity}" />.</returns>
    public static IEnumerable<UIntFor<TEntity>> AsIdsFor<TEntity>(this IEnumerable<uint> values)
    {
        return values.Select(value => new UIntFor<TEntity>(value));
    }

    /// <summary>
    ///     Represents an instance of the entity <typeparamref name="TEntity" /> as a <see cref="UIntFor{TEntity}" />.
    /// </summary>
    /// <param name="entity">An instance of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an instance of <see cref="UIntFor{TEntity}" />.</returns>
    public static UIntFor<TEntity> AsId<TEntity>(this TEntity entity) where TEntity : class, IEntityWithId<uint>
    {
        return new UIntFor<TEntity>(entity.Id);
    }

    /// <summary>
    ///     Represents an enumeration of instances of the entity <typeparamref name="TEntity" /> as an enumeration of <see cref="UIntFor{TEntity}" />.
    /// </summary>
    /// <param name="entities">An enumeration of instances of the identifiable entity.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of instances of <see cref="UIntFor{TEntity}" />.</returns>
    public static IEnumerable<UIntFor<TEntity>> AsIds<TEntity>(this IEnumerable<TEntity> entities)
        where TEntity : class, IEntityWithId<uint>
    {
        return entities.Select(entity => new UIntFor<TEntity>(entity.Id));
    }

    /// <summary>
    ///     Represents an enumeration of instances of <see cref="UIntFor{TEntity}" /> as an enumeration of base identifiers.
    /// </summary>
    /// <param name="ids">An enumeration of instances of <see cref="UIntFor{TEntity}" />.</param>
    /// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
    /// <returns>Returns an enumeration of base identifiers.</returns>
    public static IEnumerable<uint> AsIds<TEntity>(this IEnumerable<UIntFor<TEntity>> ids)
        where TEntity : class, IEntityWithId<uint>
    {
        return ids.Select(id => id.Value);
    }
}