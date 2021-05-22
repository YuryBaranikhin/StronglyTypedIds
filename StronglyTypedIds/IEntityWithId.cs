
namespace StronglyTypedIds
{
    /// <summary>
    /// Маркерный интерфейс сущности с идентификатором
    /// </summary>
    /// <typeparam name="TId">Базовый тип идентификатора сущности</typeparam>
    public interface IEntityWithId<out TId>
    {
        /// <summary>
        /// Значение базового идентификатора сущности
        /// </summary>
        TId Id { get; }
    }
}