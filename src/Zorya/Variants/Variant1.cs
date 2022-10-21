﻿using System.Diagnostics.CodeAnalysis;

namespace Zorya.Variants;

public class Variant<T1> : Variant, IVariant, IEquatable<Variant<T1>>
{
    private T1? _item;

    public Variant(T1 item)
    {
        _item = item;
        SetItem = SetItems.Item1;
    }

    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item, SetItems.Item1, value);
    }

    ///<inheritdoc />
    public override T Get<T>()
    {
        return SetItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T1), this),
            SetItems.Item1 when _item is T t => t,
            _ => throw new BadVariantAccessException(typeof(T1), this)
        };
    }

    ///<inheritdoc />
    public override bool TryGet<T>([MaybeNull] out T value)
    {
        return TestItem(_item, SetItems.Item1, out value);
    }

    ///<inheritdoc />
    public override Type? GetSetType()
    {
        return SetItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item is not null => _item.GetType(),
            _ => null
        };
    }

    public static implicit operator Variant<T1>(T1 value)
    {
        return new Variant<T1>(value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T> variant)
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
    public static bool TryGet<T>(Variant<T> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action)
    {
        if (SetItem == SetItems.Item1 && _item is not null) action(_item);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func)
    {
        if (SetItem == SetItems.Item1 && _item is not null)
            return func(_item);
        return default;
    }

    public override string ToString()
    {
        return _item?.ToString() ?? string.Empty;
    }

    public bool Equals(Variant<T1>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (SetItem != other.SetItem) return false;
        return SetItem switch
        {
            SetItems.None => true,
            SetItems.Item1 => EqualityComparer<T1?>.Default.Equals(_item, other._item),
            _ => false
        };
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Variant<T1>) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int) SetItem, _item);
    }

    public static bool operator ==(Variant<T1>? left, Variant<T1>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Variant<T1>? left, Variant<T1>? right)
    {
        return !Equals(left, right);
    }
}