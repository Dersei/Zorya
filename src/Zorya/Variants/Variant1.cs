using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Zorya.Variants;

public sealed class Variant<T1> : Variant, IVariant, IEquatable<Variant<T1>>
{
    private T1? _item;


    public Variant(T1 item)
    {
        _item = item;
        _setItem = SetItems.Item1;
    }

    private SetItems _setItem;

    protected override SetItems SetItem
    {
        get => _setItem;
        set => _setItem = value;
    }

    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item, SetItems.Item1, value);
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T1), this),
            SetItems.Item1 when typeof(T) == typeof(T1) && _item is T t1 => t1,
            _ => throw new BadVariantAccessException(typeof(T1), this)
        };
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool TryGet<T>([MaybeNull] out T value)
    {
        return TestItem(_item, SetItems.Item1, out value);
    }

    ///<inheritdoc />
    public override Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item is not null => typeof(T1),
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
        if (_setItem == SetItems.Item1 && _item is not null) action?.Invoke(_item);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func)
    {
        if (_setItem == SetItems.Item1 && _item is not null && func is not null)
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
        if (_setItem != other._setItem) return false;
        return _setItem switch
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
        return HashCode.Combine((int) _setItem, _item);
    }

    public static bool operator ==(Variant<T1>? left, Variant<T1>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Variant<T1>? left, Variant<T1>? right)
    {
        return !Equals(left, right);
    }

    internal override object? GetUnsafe()
    {
        return _item;
    }
}