using System;

namespace StronglyTypedIds
{
    /// <summary>
    /// Типизированный идентификатор сущности <typeparamref name="TEntity"/> c базовым идентификатором <see cref="Guid"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности</typeparam>
    public readonly struct GuidFor<TEntity> : IEntityId<TEntity, Guid>, IEquatable<GuidFor<TEntity>>, IEquatable<IEntityId<TEntity, Guid>>
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="GuidFor{TEntity}"/>
        /// </summary>
        /// <param name="value">Значение базового идентификатора сущности</param>
        public GuidFor(Guid value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public Guid Value { get; }

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
        public bool Equals(IEntityId<TEntity, Guid>? other)
        {
            if (ReferenceEquals(other, null)) return false;
            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public bool Equals(GuidFor<TEntity> other)
        {
            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is IEntityId<TEntity, Guid> other && Equals(other);
        }
        
        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(GuidFor<TEntity> x, GuidFor<TEntity> y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(GuidFor<TEntity> x, GuidFor<TEntity> y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(GuidFor<TEntity> x, IEntityId<TEntity, Guid> y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(GuidFor<TEntity> x, IEntityId<TEntity, Guid> y)
        {
            return !(x == y);
        }
    }
}