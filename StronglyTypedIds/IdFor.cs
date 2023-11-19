using System.Globalization;

namespace StronglyTypedIds;

/// <summary>
///     Typed identifier for the entity <typeparamref name="TEntity" /> with base identifier
///     <typeparamref name="TId" />
/// </summary>
/// <typeparam name="TEntity">Type of the identified entity</typeparam>
/// <typeparam name="TId">Base type of the entity identifier</typeparam>
public class IdFor<TEntity, TId> :
    IEntityId<TEntity, TId>,
    IEquatable<IdFor<TEntity, TId>>,
    IEquatable<IEntityId<TEntity, TId>>,
    IComparable,
    IComparable<IdFor<TEntity, TId>>,
    IComparable<IEntityId<TEntity, TId>>,
    IFormattable
{
    /// <summary>
    ///     Initializes a new instance of <see cref="IdFor{TEntity,TId}" />
    /// </summary>
    /// <param name="value">Value of the base entity identifier</param>
    public IdFor(TId value)
    {
        Value = value;
    }

    /// <inheritdoc />
    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(obj, null)) return 1;
        if (ReferenceEquals(this, obj)) return 0;

        var value = obj as IEntityId<TEntity, TId>;
        if (value == null)
            throw new ArgumentException($"Аргумент должен реализовывать {nameof(IEntityId<TEntity, TId>)}");

        return CompareTo(value);
    }

    /// <inheritdoc />
    public int CompareTo(IdFor<TEntity, TId>? other)
    {
        if (ReferenceEquals(null, other)) return 1;
        if (ReferenceEquals(this, other)) return 0;
        return Comparer<TId>.Default.Compare(Value, other.Value);
    }

    /// <inheritdoc />
    public int CompareTo(IEntityId<TEntity, TId>? other)
    {
        if (ReferenceEquals(null, other)) return 1;
        if (ReferenceEquals(this, other)) return 0;
        return Comparer<TId>.Default.Compare(Value, other.Value);
    }

    /// <inheritdoc />
    public TId Value { get; }

    /// <inheritdoc />
    public bool Equals(IdFor<TEntity, TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<TId>.Default.Equals(Value, other.Value);
    }

    /// <inheritdoc />
    public bool Equals(IEntityId<TEntity, TId>? other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(this, other)) return true;

        return EqualityComparer<TId>.Default.Equals(Value, other.Value);
    }

    /// <inheritdoc />
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        var formattableValue = Value as IFormattable;
        return formattableValue == null ? ToString() : formattableValue.ToString(format, formatProvider);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Value?.ToString() ?? "null";
    }

    /// <summary>
    ///     Returns a string representation of the value, according to the provided format specifier.
    /// </summary>
    /// <param name="format">format specifier</param>
    /// <returns>Returns a string representation of the value, according to the provided format specifier.</returns>
    public string ToString(string? format)
    {
        return ToString(format, CultureInfo.CurrentCulture);
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
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;

        return obj is IEntityId<TEntity, TId> other && Equals(other);
    }


    /// <summary>
    ///     Equality operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="true" />, if the base identifiers match, and <see langword="false" /> in
    ///     other cases
    /// </returns>
    public static bool operator ==(IdFor<TEntity, TId>? x, IdFor<TEntity, TId>? y)
    {
        return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
    }

    /// <summary>
    ///     Inequality operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="false" />, if the base identifiers match, and <see langword="true" /> in
    ///     other cases
    /// </returns>
    public static bool operator !=(IdFor<TEntity, TId>? x, IdFor<TEntity, TId>? y)
    {
        return !(x == y);
    }

    /// <summary>
    ///     Equality operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="true" />, if the base identifiers match, and <see langword="false" /> in
    ///     other cases
    /// </returns>
    public static bool operator ==(IdFor<TEntity, TId>? x, IEntityId<TEntity, TId>? y)
    {
        return ReferenceEquals(x, null) ? ReferenceEquals(y, null) : x.Equals(y);
    }

    /// <summary>
    ///     Inequality operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="false" />, if the base identifiers match, and <see langword="true" /> in
    ///     other cases
    /// </returns>
    public static bool operator !=(IdFor<TEntity, TId>? x, IEntityId<TEntity, TId>? y)
    {
        return !(x == y);
    }

    /// <summary>
    ///     Greater than operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="true" />, if the base identifier of x is greater than the base identifier of y, and <see langword="false" /> in
    ///     other cases
    /// </returns>
    public static bool operator >(IdFor<TEntity, TId> x, IdFor<TEntity, TId> y)
    {
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;

        return Comparer<TId>.Default.Compare(x.Value, y.Value) > 0;
    }

    /// <summary>
    ///     Greater than or equal to operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="true" />, if the base identifier of x is greater than or equal to the base identifier of y, and <see langword="false" /> in
    ///     other cases
    /// </returns>
    public static bool operator >=(IdFor<TEntity, TId> x, IdFor<TEntity, TId> y)
    {
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;

        return Comparer<TId>.Default.Compare(x.Value, y.Value) >= 0;
    }

    /// <summary>
    ///     Less than operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="true" />, if the base identifier of x is less than the base identifier of y, and <see langword="false" /> in
    ///     other cases
    /// </returns>
    public static bool operator <(IdFor<TEntity, TId> x, IdFor<TEntity, TId> y)
    {
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;

        return Comparer<TId>.Default.Compare(x.Value, y.Value) < 0;
    }

    /// <summary>
    ///     Less than or equal to operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="true" />, if the base identifier of x is less than or equal to the base identifier of y, and <see langword="false" /> in
    ///     other cases
    /// </returns>
    public static bool operator <=(IdFor<TEntity, TId> x, IdFor<TEntity, TId> y)
    {
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;

        return Comparer<TId>.Default.Compare(x.Value, y.Value) <= 0;
    }
}