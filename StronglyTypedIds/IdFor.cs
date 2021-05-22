using System;
using System.Collections.Generic;

namespace StronglyTypedIds
{
    /// <summary>
    /// Типизированный идентификатор сущности <typeparamref name="TEntity"/> c базовым идентификатором <typeparamref name="TId"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности</typeparam>
    /// <typeparam name="TId">Базовый тип идентификатора сущности</typeparam>
    public class IdFor<TEntity, TId> : IEntityId<TEntity, TId>, IEquatable<IdFor<TEntity, TId>>, IEquatable<IEntityId<TEntity, TId>>
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="IdFor{TEntity,TId}"/>
        /// </summary>
        /// <param name="value">Значение базового идентификатора сущности</param>
        public IdFor(TId value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public TId Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value?.ToString() ?? "null";
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (typeof(TEntity).GetHashCode() * 73) ^ EqualityComparer<TId>.Default.GetHashCode(Value);
            }
        }

        /// <inheritdoc />
        public bool Equals(IEntityId<TEntity, TId>? other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TId>.Default.Equals(Value, other.Value);
        }

        /// <inheritdoc />
        public bool Equals(IdFor<TEntity, TId>? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TId>.Default.Equals(Value, other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is IEntityId<TEntity, TId> other && Equals(other);
        }
        
        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(IdFor<TEntity, TId>? x, IdFor<TEntity, TId>? y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(IdFor<TEntity, TId>? x, IdFor<TEntity, TId>? y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="true"/>, если базовые идентификаторы совпадают, и <see langword="false"/> в остальных случаях</returns>
        public static bool operator ==(IdFor<TEntity, TId>? x, IEntityId<TEntity, TId>? y)
        {
            return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="x">Левый операнд для сравнения</param>
        /// <param name="y">Правый операнд для сравнения</param>
        /// <returns>Возвращает <see langword="false"/>, если базовые идентификаторы совпадают, и <see langword="true"/> в остальных случаях</returns>
        public static bool operator !=(IdFor<TEntity, TId>? x, IEntityId<TEntity, TId>? y)
        {
            return !(x == y);
        }
    }
}