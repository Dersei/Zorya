﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Zorya.Variants;

public sealed class Variant<T1, T2, T3> : Variant, IVariant, IEquatable<Variant<T1, T2, T3>>
{
    private IVariantValue _value;

    private SetItems _setItem;

    protected override SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }

    public Variant(T1 item1)
    {
        _value = new VariantValue<T1>(item1);
        _setItem = SetItems.Item1;
    }

    public Variant(T2 item2)
    {
        _value = new VariantValue<T2>(item2);
        _setItem = SetItems.Item2;
    }

    public Variant(T3 item3)
    {
        _value = new VariantValue<T3>(item3);
        _setItem = SetItems.Item3;
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override T Get<T>()
    {
        if (_value is VariantValue<T> {Item: { } item})
            return item;
        throw new BadVariantAccessException(typeof(T), this);
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool TryGet<T>([MaybeNull] out T value)
    {
        if (_value is VariantValue<T> {Item: { } item})
        {
            value = item;
            return true;
        }

        value = default;
        return false;
    }

    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternalValue<T1, T>(ref _value, SetItems.Item1, value)
               || SetItemInternalValue<T2, T>(ref _value, SetItems.Item2, value)
               || SetItemInternalValue<T3, T>(ref _value, SetItems.Item3, value);
    }

    ///<inheritdoc />
    public override Type? GetSetType() => _value.IsValid() ? _value.GetSetType() : null;


    public static implicit operator Variant<T1, T2, T3>(T1 value)
    {
        return new Variant<T1, T2, T3>(value);
    }

    public static implicit operator Variant<T1, T2, T3>(T2 value)
    {
        return new Variant<T1, T2, T3>(value);
    }

    public static implicit operator Variant<T1, T2, T3>(T3 value)
    {
        return new Variant<T1, T2, T3>(value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T1, T2, T3> variant)
    {
        return variant.Get<T>();
    }

    /// <summary>
    ///     Gets a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static bool TryGet<T>(Variant<T1, T2, T3> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1>? action1, Action<T2>? action2, Action<T3>? action3)
    {
        if (_setItem == SetItems.Item1 && _value is VariantValue<T1> {Item : { } value1}) action1?.Invoke(value1);
        if (_setItem == SetItems.Item2 && _value is VariantValue<T2> {Item : { } value2}) action2?.Invoke(value2);
        if (_setItem == SetItems.Item3 && _value is VariantValue<T3> {Item : { } value3}) action3?.Invoke(value3);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult>? func1, Func<T2, TResult>? func2, Func<T3, TResult>? func3)
    {
        return _setItem switch
        {
            SetItems.Item1 when _value is VariantValue<T1> {Item : { } value1} && func1 is not null => func1(value1),
            SetItems.Item2 when _value is VariantValue<T2> {Item : { } value2} && func2 is not null => func2(value2),
            SetItems.Item3 when _value is VariantValue<T3> {Item : { } value3} && func3 is not null => func3(value3),
            _ => default
        };
    }

    public override string ToString()
    {
        return _value.ToString() ?? string.Empty;
    }

    public bool Equals(Variant<T1, T2, T3>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _setItem == other._setItem && _value.GetSetType() == other._value.GetSetType() &&
               _value.Equals(other._value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Variant<T1, T2, T3>) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_value, (int) _setItem);
    }

    public static bool operator ==(Variant<T1, T2, T3>? left, Variant<T1, T2, T3>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Variant<T1, T2, T3>? left, Variant<T1, T2, T3>? right)
    {
        return !Equals(left, right);
    }
    
    internal override object? GetUnsafe()
    {
        return _value.Get();
    }
}