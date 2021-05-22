namespace StronglyTypedIds
{
    /// <summary>
    /// Маркерный интерфейс типизированного идентификатора сущности
    /// </summary>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности</typeparam>
    /// <typeparam name="TId">Базовый тип идентификатора сущности</typeparam>
    public interface IEntityId<TEntity, out TId>
    {
        /// <summary>
        /// Значение базового идентификатора сущности
        /// </summary>
        TId Value { get; }
    }
}