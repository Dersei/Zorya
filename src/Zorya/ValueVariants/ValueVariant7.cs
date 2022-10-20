using System.Runtime.CompilerServices;

namespace Zorya.ValueVariants;

public readonly struct ValueVariant<T1, T2, T3, T4, T5, T6, T7> : IValueVariant,
    IEquatable<ValueVariant<T1, T2, T3, T4, T5, T6, T7>>
{
    private ValueVariant(bool _)
    {
        Unsafe.SkipInit(out _item1);
        Unsafe.SkipInit(out _item2);
        Unsafe.SkipInit(out _item3);
        Unsafe.SkipInit(out _item4);
        Unsafe.SkipInit(out _item5);
        Unsafe.SkipInit(out _item6);
        Unsafe.SkipInit(out _item7);
    }

    public ValueVariant(T1 item1) : this(true)
    {
        _item1 = item1;
        _setItem = SetItems.Item1;
    }

    public ValueVariant(T2 item2) : this(true)
    {
        _item2 = item2;
        _setItem = SetItems.Item2;
    }

    public ValueVariant(T3 item3) : this(true)
    {
        _item3 = item3;
        _setItem = SetItems.Item3;
    }

    public ValueVariant(T4 item4) : this(true)
    {
        _item4 = item4;
        _setItem = SetItems.Item4;
    }

    public ValueVariant(T5 item5) : this(true)
    {
        _item5 = item5;
        _setItem = SetItems.Item5;
    }

    public ValueVariant(T6 item6) : this(true)
    {
        _item6 = item6;
        _setItem = SetItems.Item6;
    }

    public ValueVariant(T7 item7) : this(true)
    {
        _item7 = item7;
        _setItem = SetItems.Item7;
    }


    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6, T7>(T1 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6, T7>(T2 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6, T7>(T3 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6, T7>(T4 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6, T7>(T5 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6, T7>(T6 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6, T7>(T7 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6, T7>(value);
    }

    private readonly SetItems _setItem = SetItems.None;


    private readonly T1? _item1;

    private readonly T2? _item2;
    private readonly T3? _item3;
    private readonly T4? _item4;
    private readonly T5? _item5;
    private readonly T6? _item6;
    private readonly T7? _item7;

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(ValueVariant<T1, T2, T3, T4, T5, T6, T7> variant)
    {
        return variant.Get<T>();
    }

    /// <summary>
    ///     Get a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="variant">Tested variant.</param>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static bool TryGet<T>(ValueVariant<T1, T2, T3, T4, T5, T6, T7> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadValueVariantAccessException(typeof(T), this),
            SetItems.Item1 when _item1 is T t1 => t1,
            SetItems.Item2 when _item2 is T t2 => t2,
            SetItems.Item3 when _item3 is T t3 => t3,
            SetItems.Item4 when _item4 is T t4 => t4,
            SetItems.Item5 when _item5 is T t5 => t5,
            SetItems.Item6 when _item6 is T t6 => t6,
            SetItems.Item7 when _item7 is T t7 => t7,
            _ => throw new BadValueVariantAccessException(typeof(T), this)
        };
    }

    /// <summary>
    ///     Get a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public bool TryGet<T>(out T? value)
    {
        if (ValueVariant.TestItem(_item1, SetItems.Item1 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item2, SetItems.Item2 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item3, SetItems.Item3 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item4, SetItems.Item4 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item5, SetItems.Item5 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item6, SetItems.Item6 == _setItem, out value)) return true;
        return ValueVariant.TestItem(_item7, SetItems.Item7 == _setItem, out value);
    }

    /// <inheritdoc />
    public bool IsSet() => _setItem != SetItems.None;

    /// <summary>
    /// Returns set type.
    /// </summary>
    /// <returns></returns>
    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => _item1.GetType(),
            SetItems.Item2 when _item2 is not null => _item2.GetType(),
            SetItems.Item3 when _item3 is not null => _item3.GetType(),
            SetItems.Item4 when _item4 is not null => _item4.GetType(),
            SetItems.Item5 when _item5 is not null => _item5.GetType(),
            SetItems.Item6 when _item6 is not null => _item6.GetType(),
            SetItems.Item7 when _item7 is not null => _item7.GetType(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4,
        Action<T5> action5, Action<T6> action6, Action<T7> action7)
    {
        if (_setItem == SetItems.Item1) action1(_item1!);
        if (_setItem == SetItems.Item2) action2(_item2!);
        if (_setItem == SetItems.Item3) action3(_item3!);
        if (_setItem == SetItems.Item4) action4(_item4!);
        if (_setItem == SetItems.Item5) action5(_item5!);
        if (_setItem == SetItems.Item6) action6(_item6!);
        if (_setItem == SetItems.Item7) action7(_item7!);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3,
        Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7)
    {
        return _setItem switch
        {
            SetItems.Item1 => func1(_item1!),
            SetItems.Item2 => func2(_item2!),
            SetItems.Item3 => func3(_item3!),
            SetItems.Item4 => func4(_item4!),
            SetItems.Item5 => func5(_item5!),
            SetItems.Item6 => func6(_item6!),
            SetItems.Item7 => func7(_item7!),
            _ => default
        };
    }

    /// <summary>
    ///     Matches set element with a given action. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="BadValueVariantAccessException"></exception>
    public void Match<T>(Action<T> action)
    {
        if (TryGet(out T? value))
            action(value!);
        else
            throw new BadValueVariantAccessException(typeof(T), this);
    }

    /// <summary>
    ///     Matches set element with a given action. Executes fallback function if there's no matching type.
    /// </summary>
    /// <param name="action"></param>
    /// <param name="fallback">Fallback action, executed if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    public void MatchOrDefault<T>(Action<T> action, Action fallback)
    {
        if (TryGet(out T? value))
            action(value!);
        else
            fallback();
    }

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public bool TryMatch<T>(Action<T> action)
    {
        if (TryGet(out T? value))
        {
            action(value!);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Matches set element with a given function. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <exception cref="BadValueVariantAccessException"></exception>
    public TResult Match<T, TResult>(Func<T, TResult> func)
    {
        if (TryGet(out T? value)) return func(value!);

        throw new BadValueVariantAccessException(typeof(T), this);
    }

    /// <summary>
    ///     Matches set element with a given function. Returns default value if there's no matching type.
    /// </summary>
    /// <param name="func"></param>
    /// <param name="default">Default value to return if there's no matching type.</param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public TResult MatchOrDefault<T, TResult>(Func<T, TResult> func, TResult @default)
    {
        if (TryGet(out T? value)) return func(value!);

        return @default;
    }

    /// <summary>
    ///     Matches set element with a given action. Returns false if type isn't set.
    /// </summary>
    /// <param name="func"></param>
    /// <param name="result">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public bool TryMatch<T, TResult>(Func<T, TResult> func, out TResult? result)
    {
        if (TryGet(out T? value))
        {
            result = func(value!);
            return true;
        }

        result = default;
        return false;
    }

    public override string ToString()
    {
        return _setItem switch
        {
            SetItems.Item1 => _item1?.ToString(),
            SetItems.Item2 => _item2?.ToString(),
            SetItems.Item3 => _item3?.ToString(),
            SetItems.Item4 => _item4?.ToString(),
            SetItems.Item5 => _item5?.ToString(),
            SetItems.Item6 => _item6?.ToString(),
            SetItems.Item7 => _item7?.ToString(),
            _ => string.Empty
        } ?? string.Empty;
    }

    public bool Equals(ValueVariant<T1, T2, T3, T4, T5, T6, T7> other)
    {
        return _setItem == other._setItem 
               && _setItem switch
               {
                   SetItems.None => true,
                   SetItems.Item1 => EqualityComparer<T1?>.Default.Equals(_item1, other._item1),
                   SetItems.Item2 => EqualityComparer<T2?>.Default.Equals(_item2, other._item2),
                   SetItems.Item3 => EqualityComparer<T3?>.Default.Equals(_item3, other._item3),
                   SetItems.Item4 => EqualityComparer<T4?>.Default.Equals(_item4, other._item4),
                   SetItems.Item5 => EqualityComparer<T5?>.Default.Equals(_item5, other._item5),
                   SetItems.Item6 => EqualityComparer<T6?>.Default.Equals(_item6, other._item6),
                   SetItems.Item7 => EqualityComparer<T7?>.Default.Equals(_item7, other._item7),
                   _ => false
               };
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueVariant<T1, T2, T3, T4, T5, T6, T7> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int) _setItem, _item1, _item2, _item3, _item4, _item5, _item6, _item7);
    }

    public static bool operator ==(ValueVariant<T1, T2, T3, T4, T5, T6, T7> left,
        ValueVariant<T1, T2, T3, T4, T5, T6, T7> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ValueVariant<T1, T2, T3, T4, T5, T6, T7> left,
        ValueVariant<T1, T2, T3, T4, T5, T6, T7> right)
    {
        return !left.Equals(right);
    }
}