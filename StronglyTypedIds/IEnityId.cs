namespace StronglyTypedIds
{
    public interface IEntityId<TEntity, out TId>
    {
        TId Value { get; }
    }
}