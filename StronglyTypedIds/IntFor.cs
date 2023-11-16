﻿using System.Globalization;

namespace StronglyTypedIds;

/// <summary>
///     Typed identifier for the entity <typeparamref name="TEntity" /> with base identifier <see cref="int" />
/// </summary>
/// <typeparam name="TEntity">Type of the identified entity</typeparam>
public readonly record struct IntFor<TEntity> :
    IEntityId<TEntity, int>,
    IEquatable<IEntityId<TEntity, int>>,
    IComparable,
    IComparable<IntFor<TEntity>>,
    IComparable<IEntityId<TEntity, int>>,
    IFormattable
{
    /// <summary>
    ///     Initializes a new instance of <see cref="IntFor{TEntity}" />
    /// </summary>
    /// <param name="value">Value of the base entity identifier</param>
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

        var value = obj as IEntityId<TEntity, int>;
        if (value == null)
            throw new ArgumentException($"Argument must implement {nameof(IEntityId<TEntity, int>)}");

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

    /// <summary>
    ///     Equality operator
    /// </summary>
    /// <param name="x">Left operand for comparison</param>
    /// <param name="y">Right operand for comparison</param>
    /// <returns>
    ///     Returns <see langword="true" />, if the base identifiers match, and <see langword="false" /> in
    ///     other cases
    /// </returns>
    public static bool operator ==(IntFor<TEntity> x, IEntityId<TEntity, int> y)
    {
        return x.Equals(y);
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
    public static bool operator !=(IntFor<TEntity> x, IEntityId<TEntity, int> y)
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
    public static bool operator >(IntFor<TEntity> x, IntFor<TEntity> y)
    {
        return x.Value > y.Value;
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
    public static bool operator >=(IntFor<TEntity> x, IntFor<TEntity> y)
    {
        return x.Value >= y.Value;
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
    public static bool operator <(IntFor<TEntity> x, IntFor<TEntity> y)
    {
        return x.Value < y.Value;
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
    public static bool operator <=(IntFor<TEntity> x, IntFor<TEntity> y)
    {
        return x.Value <= y.Value;
    }
}