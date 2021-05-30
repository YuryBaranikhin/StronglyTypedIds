using System;
using System.Globalization;

namespace StronglyTypedIds
{
    /// <summary>
    /// Типизированный идентификатор сущности <typeparamref name="TEntity"/> c базовым идентификатором <see cref="int"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип идентифицируемой сущности</typeparam>
    public readonly struct IntFor<TEntity> : 
        IEntityId<TEntity, int>,
        IEquatable<IntFor<TEntity>>,
        IEquatable<IEntityId<TEntity, int>>,
        IComparable,
        IComparable<IntFor<TEntity>>,
        IComparable<IEntityId<TEntity, int>>,
        IFormattable
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

        /// <summary>
        /// Returns a string representation of the value, according to the provided format specifier.
        /// </summary>
        /// <param name="format">format specifier</param>
        /// <returns>Returns a string representation of the value, according to the provided format specifier.</returns>
        public string ToString(string? format)
        {
            return Value.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <inheritdoc />
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return Value.ToString(format, formatProvider);
        }

        /// <inheritdoc />
        public int CompareTo(object? obj)
        {
            if (obj == null) {
                return 1;
            }

            var value = obj as IEntityId<TEntity, int>;
            if (value == null) {
                throw new ArgumentException($"Аргумент должен реализовывать {nameof(IEntityId<TEntity, int>)}");
            }

            return CompareTo(value);
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
        public int CompareTo(IntFor<TEntity> other)
        {
            return Value.CompareTo(other.Value);
        }

        /// <inheritdoc />
        public int CompareTo(IEntityId<TEntity, int>? other)
        {
            return ReferenceEquals(other, null) ? 1 : Value.CompareTo(other.Value);
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