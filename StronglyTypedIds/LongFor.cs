using System;

namespace StronglyTypedIds
{
    /// <summary>
    /// Типизированный идентификатор сущности <typeparamref name="TEntity"/> c базовым идентификатором <see cref="long"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности</typeparam>
    public readonly struct LongFor<TEntity> : IEntityId<TEntity, long>, IEquatable<LongFor<TEntity>>, IEquatable<IEntityId<TEntity, long>>
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="LongFor{TEntity}"/>
        /// </summary>
        /// <param name="value">Значение базового идентификатора сущности</param>
        public LongFor(long value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public long Value { get; }
        
        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (typeof(TEntity).GetHashCode() * 73) ^ Value.GetHashCode();
            }
        }

        /// <inheritdoc />
        public bool Equals(IEntityId<TEntity, long>? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public bool Equals(LongFor<TEntity> other)
        {
            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is IEntityId<TEntity, long> other && Equals(other);
        }

        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(LongFor<TEntity> x, LongFor<TEntity> y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(LongFor<TEntity> x, LongFor<TEntity> y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(LongFor<TEntity> x, IEntityId<TEntity, long> y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(LongFor<TEntity> x, IEntityId<TEntity, long> y)
        {
            return !(x == y);
        }
    }
}