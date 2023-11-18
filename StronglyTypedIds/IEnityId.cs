namespace StronglyTypedIds;

/// <summary>
///     Marker interface for a typed entity identifier.
/// </summary>
/// <typeparam name="TEntity">The type of the identifiable entity.</typeparam>
/// <typeparam name="TId">The base type of the entity's identifier.</typeparam>
public interface IEntityId<TEntity, out TId>
{
    /// <summary>
    ///     The value of the base identifier of the entity.
    /// </summary>
    TId Value { get; }
}