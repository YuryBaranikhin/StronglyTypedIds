
namespace StronglyTypedIds
{
    public interface IEntityWithId<out TId>
    {
        TId Id { get; }
    }
}