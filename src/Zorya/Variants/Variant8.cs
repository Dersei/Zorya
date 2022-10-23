using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Zorya.Variants;

public class Variant<T1, T2, T3, T4, T5, T6, T7, T8> : Variant, IVariant,
    IEquatable<Variant<T1, T2, T3, T4, T5, T6, T7, T8>>
{
    private T1? _item1;
    private T2? _item2;
    private T3? _item3;
    private T4? _item4;
    private T5? _item5;
    private T6? _item6;
    private T7? _item7;
    private T8? _item8;

    public Variant(T1 item1)
    {
        _item1 = item1;
        SetItem = SetItems.Item1;
    }

    public Variant(T2 item2)
    {
        _item2 = item2;
        SetItem = SetItems.Item2;
    }

    public Variant(T3 item3)
    {
        _item3 = item3;
        SetItem = SetItems.Item3;
    }

    public Variant(T4 item4)
    {
        _item4 = item4;
        SetItem = SetItems.Item4;
    }

    public Variant(T5 item5)
    {
        _item5 = item5;
        SetItem = SetItems.Item5;
    }

    public Variant(T6 item6)
    {
        _item6 = item6;
        SetItem = SetItems.Item6;
    }

    public Variant(T7 item7)
    {
        _item7 = item7;
        SetItem = SetItems.Item7;
    }

    public Variant(T8 item8)
    {
        _item8 = item8;
        SetItem = SetItems.Item8;
    }

    ///<inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override T Get<T>()
    {
        return SetItem switch
        {
            SetItems.None => throw new BadVariantAccessException(typeof(T), this),
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is T t1 => t1,
            SetItems.Item2 when typeof(T) == typeof(T2) && _item2 is T t2 => t2,
            SetItems.Item3 when typeof(T) == typeof(T3) && _item3 is T t3 => t3,
            SetItems.Item4 when typeof(T) == typeof(T4) && _item4 is T t4 => t4,
            SetItems.Item5 when typeof(T) == typeof(T5) && _item5 is T t5 => t5,
            SetItems.Item6 when typeof(T) == typeof(T6) && _item6 is T t6 => t6,
            SetItems.Item7 when typeof(T) == typeof(T7) && _item7 is T t7 => t7,
            SetItems.Item8 when typeof(T) == typeof(T8) && _item8 is T t8 => t8,
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
        if (TestItem(_item4, SetItems.Item4, out value)) return true;
        if (TestItem(_item5, SetItems.Item5, out value)) return true;
        if (TestItem(_item6, SetItems.Item6, out value)) return true;
        if (TestItem(_item7, SetItems.Item7, out value)) return true;
        return TestItem(_item8, SetItems.Item8, out value);
    }

    ///<inheritdoc />
    public override Type? GetSetType()
    {
        return SetItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => typeof(T1),
            SetItems.Item2 when _item2 is not null => typeof(T2),
            SetItems.Item3 when _item3 is not null => typeof(T3),
            SetItems.Item4 when _item4 is not null => typeof(T4),
            SetItems.Item5 when _item5 is not null => typeof(T5),
            SetItems.Item6 when _item6 is not null => typeof(T6),
            SetItems.Item7 when _item7 is not null => typeof(T7),
            SetItems.Item8 when _item8 is not null => typeof(T8),
            _ => null
        };
    }

    ///<inheritdoc />
    public override bool Set<T>(T value)
    {
        return SetItemInternal(ref _item1, SetItems.Item1, value)
               || SetItemInternal(ref _item2, SetItems.Item2, value)
               || SetItemInternal(ref _item3, SetItems.Item3, value)
               || SetItemInternal(ref _item4, SetItems.Item4, value)
               || SetItemInternal(ref _item5, SetItems.Item5, value)
               || SetItemInternal(ref _item6, SetItems.Item6, value)
               || SetItemInternal(ref _item7, SetItems.Item7, value)
               || SetItemInternal(ref _item8, SetItems.Item8, value);
    }


    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T2 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T3 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T4 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T5 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T6 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T7 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }

    public static implicit operator Variant<T1, T2, T3, T4, T5, T6, T7, T8>(T8 value)
    {
        return new Variant<T1, T2, T3, T4, T5, T6, T7, T8>(value);
    }


    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(Variant<T1, T2, T3, T4, T5, T6, T7, T8> variant)
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
    public static bool TryGet<T>(Variant<T1, T2, T3, T4, T5, T6, T7, T8> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4,
        Action<T5> action5, Action<T6> action6, Action<T7> action7, Action<T8> action8)
    {
        if (SetItem == SetItems.Item1 && _item1 is not null) action1(_item1);
        if (SetItem == SetItems.Item2 && _item2 is not null) action2(_item2);
        if (SetItem == SetItems.Item3 && _item3 is not null) action3(_item3);
        if (SetItem == SetItems.Item4 && _item4 is not null) action4(_item4);
        if (SetItem == SetItems.Item5 && _item5 is not null) action5(_item5);
        if (SetItem == SetItems.Item6 && _item6 is not null) action6(_item6);
        if (SetItem == SetItems.Item7 && _item7 is not null) action7(_item7);
        if (SetItem == SetItems.Item8 && _item8 is not null) action8(_item8);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3,
        Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7,
        Func<T8, TResult> func8)
    {
        return SetItem switch
        {
            SetItems.Item1 when _item1 is not null => func1(_item1),
            SetItems.Item2 when _item2 is not null  => func2(_item2),
            SetItems.Item3 when _item3 is not null  => func3(_item3),
            SetItems.Item4 when _item4 is not null  => func4(_item4),
            SetItems.Item5 when _item5 is not null  => func5(_item5),
            SetItems.Item6 when _item6 is not null  => func6(_item6),
            SetItems.Item7 when _item7 is not null  => func7(_item7),
            SetItems.Item8 when _item8 is not null  => func8(_item8),
            _ => default
        };
    }

    public override string ToString()
    {
        return SetItem switch
        {
            SetItems.Item1 => _item1?.ToString(),
            SetItems.Item2 => _item2?.ToString(),
            SetItems.Item3 => _item3?.ToString(),
            SetItems.Item4 => _item4?.ToString(),
            SetItems.Item5 => _item5?.ToString(),
            SetItems.Item6 => _item6?.ToString(),
            SetItems.Item7 => _item7?.ToString(),
            SetItems.Item8 => _item8?.ToString(),
            _ => string.Empty
        } ?? string.Empty;
    }

    public bool Equals(Variant<T1, T2, T3, T4, T5, T6, T7, T8>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (SetItem != other.SetItem) return false;
        return SetItem switch
        {
            SetItems.None => true,
            SetItems.Item1 => EqualityComparer<T1?>.Default.Equals(_item1, other._item1),
            SetItems.Item2 => EqualityComparer<T2?>.Default.Equals(_item2, other._item2),
            SetItems.Item3 => EqualityComparer<T3?>.Default.Equals(_item3, other._item3),
            SetItems.Item4 => EqualityComparer<T4?>.Default.Equals(_item4, other._item4),
            SetItems.Item5 => EqualityComparer<T5?>.Default.Equals(_item5, other._item5),
            SetItems.Item6 => EqualityComparer<T6?>.Default.Equals(_item6, other._item6),
            SetItems.Item7 => EqualityComparer<T7?>.Default.Equals(_item7, other._item7),
            SetItems.Item8 => EqualityComparer<T8?>.Default.Equals(_item8, other._item8),
            _ => false
        };
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Variant<T1, T2, T3, T4, T5, T6, T7, T8>) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_item1, _item2, _item3, _item4, _item5, _item6, _item7, _item8);
    }

    public static bool operator ==(Variant<T1, T2, T3, T4, T5, T6, T7, T8>? left,
        Variant<T1, T2, T3, T4, T5, T6, T7, T8>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Variant<T1, T2, T3, T4, T5, T6, T7, T8>? left,
        Variant<T1, T2, T3, T4, T5, T6, T7, T8>? right)
    {
        return !Equals(left, right);
    }
}