using System.Globalization;

namespace StronglyTypedIds;

/// <summary>
///     Типизированный идентификатор сущности <typeparamref name="TEntity" /> c базовым идентификатором <see cref="Guid" />
/// </summary>
/// <typeparam name="TEntity">Тип идентифицируемой сущности</typeparam>
public readonly record struct GuidFor<TEntity> :
    IEntityId<TEntity, Guid>,
    IEquatable<IEntityId<TEntity, Guid>>,
    IComparable,
    IComparable<GuidFor<TEntity>>,
    IComparable<IEntityId<TEntity, Guid>>,
    IFormattable
{
    /// <summary>
    ///     Инициализирует новый экземпляр <see cref="GuidFor{TEntity}" />
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

    /// <summary>
    ///     Returns a string representation of the value, according to the provided format specifier.
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
        if (obj == null) return 1;

        var value = obj as IEntityId<TEntity, Guid>;
        if (value == null)
            throw new ArgumentException($"Аргумент должен реализовывать {nameof(IEntityId<TEntity, Guid>)}");

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
    public int CompareTo(GuidFor<TEntity> other)
    {
        return Value.CompareTo(other.Value);
    }

    /// <inheritdoc />
    public int CompareTo(IEntityId<TEntity, Guid>? other)
    {
        return ReferenceEquals(other, null) ? 1 : Value.CompareTo(other.Value);
    }

    /// <summary>
    ///     Оператор равенства
    /// </summary>
    /// <param name="x">Левый операнд для сравнения</param>
    /// <param name="y">Правый операнд для сравнения</param>
    /// <returns>
    ///     Возвращает <see langword="true" />, если базовые идентификаторы совпадают, и <see langword="false" /> в
    ///     остальных случаях
    /// </returns>
    public static bool operator ==(GuidFor<TEntity> x, IEntityId<TEntity, Guid> y)
    {
        return x.Equals(y);
    }

    /// <summary>
    ///     Оператор неравенства
    /// </summary>
    /// <param name="x">Левый операнд для сравнения</param>
    /// <param name="y">Правый операнд для сравнения</param>
    /// <returns>
    ///     Возвращает <see langword="false" />, если базовые идентификаторы совпадают, и <see langword="true" /> в
    ///     остальных случаях
    /// </returns>
    public static bool operator !=(GuidFor<TEntity> x, IEntityId<TEntity, Guid> y)
    {
        return !(x == y);
    }
}