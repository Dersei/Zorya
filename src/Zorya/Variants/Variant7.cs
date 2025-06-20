﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Zorya.Variants;

public sealed class Variant<T1, T2, T3, T4, T5, T6, T7> : Variant, IVariant,
    IEquatable<Variant<T1, T2, T3, T4, T5, T6, T7>>
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

    public Variant(T4 item4)
    {
        _value = new VariantValue<T4>(item4);
        _setItem = SetItems.Item4;
    }

    public Variant(T5 item5)
    {
        _value = new VariantValue<T5>(item5);
        _setItem = SetItems.Item5;
    }

    public Variant(T6 item6)
    {
        _value = new VariantValue<T6>(item6);
        _setItem = SetItems.Item6;
    }

    public Variant(T7 item7)
    {
        _value = new VariantValue<T7>(item7);
        _setItem = SetItems.Item7;
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
    public override Type? GetSetType() => _value.IsValid() ? _value.GetSetType() : null;


    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternalValue<T1, T>(ref _value, SetItems.Item1, value)
               || SetItemInternalValue<T2, T>(ref _value, SetItems.Item2, value)
               || SetItemInternalValue<T3, T>(ref _value, SetItems.Item3, value)
               || SetItemInternalValue<T4, T>(ref _value, SetItems.Item4, value)
               || SetItemInternalValue<T5, T>(ref _value, SetItems.Item5, value)
               || SetItemInternalValue<T6, T>(ref _value, SetItems.Item6, value)
               || SetItemInternalValue<T7, T>(ref _value, SetItems.Item7, value);
    }


    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7>(T1 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7>(T2 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7>(T3 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7>(T4 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7>(T5 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7>(T6 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7>(T7 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T1, T2, T3, T4, T5, T6, T7> variant)
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
    public static bool TryGet<T>(Variant<T1, T2, T3, T4, T5, T6, T7> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1>? action1, Action<T2>? action2, Action<T3>? action3, Action<T4>? action4,
        Action<T5>? action5, Action<T6>? action6, Action<T7>? action7)
    {
        if (_setItem == SetItems.Item1 && _value is VariantValue<T1> {Item : { } value1}) action1?.Invoke(value1);
        if (_setItem == SetItems.Item2 && _value is VariantValue<T2> {Item : { } value2}) action2?.Invoke(value2);
        if (_setItem == SetItems.Item3 && _value is VariantValue<T3> {Item : { } value3}) action3?.Invoke(value3);
        if (_setItem == SetItems.Item4 && _value is VariantValue<T4> {Item : { } value4}) action4?.Invoke(value4);
        if (_setItem == SetItems.Item5 && _value is VariantValue<T5> {Item : { } value5}) action5?.Invoke(value5);
        if (_setItem == SetItems.Item6 && _value is VariantValue<T6> {Item : { } value6}) action6?.Invoke(value6);
        if (_setItem == SetItems.Item7 && _value is VariantValue<T7> {Item : { } value7}) action7?.Invoke(value7);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult>? func1, Func<T2, TResult>? func2, Func<T3, TResult>? func3,
        Func<T4, TResult>? func4, Func<T5, TResult>? func5, Func<T6, TResult>? func6, Func<T7, TResult>? func7)
    {
        return _setItem switch
        {
            SetItems.Item1 when _value is VariantValue<T1> {Item : { } value1} && func1 is not null => func1(value1),
            SetItems.Item2 when _value is VariantValue<T2> {Item : { } value2} && func2 is not null => func2(value2),
            SetItems.Item3 when _value is VariantValue<T3> {Item : { } value3} && func3 is not null => func3(value3),
            SetItems.Item4 when _value is VariantValue<T4> {Item : { } value4} && func4 is not null => func4(value4),
            SetItems.Item5 when _value is VariantValue<T5> {Item : { } value5} && func5 is not null => func5(value5),
            SetItems.Item6 when _value is VariantValue<T6> {Item : { } value6} && func6 is not null => func6(value6),
            SetItems.Item7 when _value is VariantValue<T7> {Item : { } value7} && func7 is not null => func7(value7),
            _ => default
        };
    }

    public override string ToString()
    {
        return _value.ToString() ?? string.Empty;
    }

    public bool Equals(Variant<T1, T2, T3, T4, T5, T6, T7>? other)
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
        return Equals((Variant<T1, T2, T3, T4, T5, T6, T7>) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_value, (int) _setItem);
    }

    public static bool operator ==(Variant<T1, T2, T3, T4, T5, T6, T7>? left,
        Variant<T1, T2, T3, T4, T5, T6, T7>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Variant<T1, T2, T3, T4, T5, T6, T7>? left,
        Variant<T1, T2, T3, T4, T5, T6, T7>? right)
    {
        return !Equals(left, right);
    }
    
    internal override object? GetUnsafe()
    {
        return _value.Get();
    }
}