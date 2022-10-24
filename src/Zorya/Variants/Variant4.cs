using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Zorya.Variants;

public sealed class Variant<T1, T2, T3, T4> : Variant, IVariant,
    IEquatable<Variant<T1, T2, T3, T4>>
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;
    
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

    public Variant(T3 item3)
    {
        _item3 = item3;
        _setItem = SetItems.Item3;
    }

    public Variant(T4 item4)
    {
        _item4 = item4;
        _setItem = SetItems.Item4;
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
            SetItems.Item3 when typeof(T) == typeof(T3) && _item3 is T t3 => t3,
            SetItems.Item4 when typeof(T) == typeof(T4) && _item4 is T t4 => t4,
            _ => throw new BadVariantAccessException(typeof(T), this)
        };
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool TryGet<T>([MaybeNull] out T value)
    {
        if (TestItem(_item1, SetItems.Item1, out value)) return true;
        if (TestItem(_item2, SetItems.Item2, out value)) return true;
        if (TestItem(_item3, SetItems.Item3, out value)) return true;
        return TestItem(_item4, SetItems.Item4, out value);
    }

    ///<inheritdoc />
    public override Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => typeof(T1),
            SetItems.Item2 when _item2 is not null => typeof(T2),
            SetItems.Item3 when _item3 is not null => typeof(T3),
            SetItems.Item4 when _item4 is not null => typeof(T4),
            _ => null
        };
    }

    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item1, SetItems.Item1, value)
               || SetItemInternal(ref _item2, SetItems.Item2, value)
               || SetItemInternal(ref _item3, SetItems.Item3, value)
               || SetItemInternal(ref _item4, SetItems.Item4, value);
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T1 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T2 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T3 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4>(T4 value)
    {
        return new Variant<T1, T2, T3, T4>(value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T1, T2, T3, T4> variant)
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
    public static bool TryGet<T>(Variant<T1, T2, T3, T4> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4)
    {
        if (_setItem == SetItems.Item1 && _item1 is not null) action1(_item1);
        if (_setItem == SetItems.Item2 && _item2 is not null) action2(_item2);
        if (_setItem == SetItems.Item3 && _item3 is not null) action3(_item3);
        if (_setItem == SetItems.Item4 && _item4 is not null) action4(_item4);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3,
        Func<T4, TResult> func4)
    {
        return _setItem switch
        {
            SetItems.Item1 when _item1 is not null => func1(_item1),
            SetItems.Item2 when _item2 is not null  => func2(_item2),
            SetItems.Item3 when _item3 is not null  => func3(_item3),
            SetItems.Item4 when _item4 is not null  => func4(_item4),
            _ => default
        };
    }

    public override string ToString()
    {
        return _setItem switch
        {
            SetItems.Item1 => _item1?.ToString(),
            SetItems.Item2 => _item2?.ToString(),
            SetItems.Item3 => _item3?.ToString(),
            SetItems.Item4 => _item4?.ToString(),
            _ => string.Empty
        } ?? string.Empty;
    }

    public bool Equals(Variant<T1, T2, T3, T4>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (_setItem != other._setItem) return false;
        return _setItem switch
        {
            SetItems.None => true,
            SetItems.Item1 => EqualityComparer<T1?>.Default.Equals(_item1, other._item1),
            SetItems.Item2 => EqualityComparer<T2?>.Default.Equals(_item2, other._item2),
            SetItems.Item3 => EqualityComparer<T3?>.Default.Equals(_item3, other._item3),
            SetItems.Item4 => EqualityComparer<T4?>.Default.Equals(_item4, other._item4),
            _ => false
        };
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Variant<T1, T2, T3, T4>) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_item1, _item2, _item3, _item4);
    }

    public static bool operator ==(Variant<T1, T2, T3, T4>? left, Variant<T1, T2, T3, T4>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Variant<T1, T2, T3, T4>? left, Variant<T1, T2, T3, T4>? right)
    {
        return !Equals(left, right);
    }
}