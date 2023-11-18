namespace StronglyTypedIds;

/// <summary>
///     Marker interface for an entity with an identifier.
/// </summary>
/// <typeparam name="TId">The base type of the entity's identifier.</typeparam>
public interface IEntityWithId<out TId>
{
    /// <summary>
    ///     The value of the base identifier of the entity.
    /// </summary>
    TId Id { get; }
}