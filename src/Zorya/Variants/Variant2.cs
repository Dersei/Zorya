﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Zorya.Variants;

public sealed class Variant<T1, T2> : Variant, IVariant, IEquatable<Variant<T1, T2>>
{
    private T1? _item1;
    private T2? _item2;
    
    private SetItems _setItem;
    
    protected override SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }

    public Variant(T1 item1)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
    }

    public Variant(T2 item2)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
    }

    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item1, SetItems.Item1, value) ||
               SetItemInternal(ref _item2, SetItems.Item2, value);
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T), this),
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is T t1 => t1,
            SetItems.Item2 when typeof(T) == typeof(T2) && _item2 is T t2 => t2,
            _ => throw new BadVariantAccessException(typeof(T), this)
        };
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool TryGet<T>([MaybeNull] out T value)
    {
        if (TestItem(_item1, SetItems.Item1, out value)) return true;
        return TestItem(_item2, SetItems.Item2, out value);
    }

    ///<inheritdoc />
    public override Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => typeof(T1),
            SetItems.Item2 when _item2 is not null => typeof(T2),
            _ => null
        };
    }

    public static implicit operator Variant<T1, T2>(T1 value)
    {
        return new Variant<T1, T2>(value);
    }

    public static implicit operator Variant<T1, T2>(T2 value)
    {
        return new Variant<T1, T2>(value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T1, T2> variant)
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
    public static bool TryGet<T>(Variant<T1, T2> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2)
    {
        if (_setItem == SetItems.Item1 && _item1 is not null) action1(_item1);
        if (_setItem == SetItems.Item2 && _item2 is not null) action2(_item2);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2)
    {
        return _setItem switch
        {
            SetItems.Item1 when _item1 is not null => func1(_item1),
            SetItems.Item2 when _item2 is not null  => func2(_item2),
            _ => default
        };
    }

    public override string ToString()
    {
        return _setItem switch
        {
            SetItems.Item1 => _item1?.ToString(),
            SetItems.Item2 => _item2?.ToString(),
            _ => string.Empty
        } ?? string.Empty;
    }

    public bool Equals(Variant<T1, T2>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (_setItem != other._setItem) return false;
        return _setItem switch
        {
            SetItems.None => true,
            SetItems.Item1 => EqualityComparer<T1?>.Default.Equals(_item1, other._item1),
            SetItems.Item2 => EqualityComparer<T2?>.Default.Equals(_item2, other._item2),
            _ => false
        };
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Variant<T1, T2>) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_item1, _item2);
    }

    public static bool operator ==(Variant<T1, T2>? left, Variant<T1, T2>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Variant<T1, T2>? left, Variant<T1, T2>? right)
    {
        return !Equals(left, right);
    }
}