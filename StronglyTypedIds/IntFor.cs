using System;

namespace StronglyTypedIds
{
    /// <summary>
    /// Типизированный идентификатор сущности <typeparamref name="TEntity"/> c базовым идентификатором <see cref="int"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности</typeparam>
    public readonly struct IntFor<TEntity> : IEntityId<TEntity, int>, IEquatable<IntFor<TEntity>>,
        IEquatable<IEntityId<TEntity, int>>
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="IntFor{TEntity}"/>
        /// </summary>
        /// <param name="value">Значение базового идентификатора сущности</param>
        public IntFor(int value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public int Value { get; }
        
        /// <inheritdoc />
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (typeof(TEntity).GetHashCode() * 73) ^ Value.GetHashCode();
            }
        }

        /// <inheritdoc />
        public bool Equals(IEntityId<TEntity, int>? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public bool Equals(IntFor<TEntity> other)
        {
            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is IEntityId<TEntity, int> other && Equals(other);
        }

        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(IntFor<TEntity> x, IntFor<TEntity> y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(IntFor<TEntity> x, IntFor<TEntity> y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(IntFor<TEntity> x, IEntityId<TEntity, int> y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(IntFor<TEntity> x, IEntityId<TEntity, int> y)
        {
            return !(x == y);
        }
    }
}