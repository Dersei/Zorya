using System.Runtime.CompilerServices;

namespace Zorya.ValueVariants;

public readonly struct ValueVariant<T1, T2, T3, T4, T5, T6> : IValueVariant,
    IEquatable<ValueVariant<T1, T2, T3, T4, T5, T6>>
{
    private ValueVariant(bool _)
    {
        Unsafe.SkipInit(out _item1);
        Unsafe.SkipInit(out _item2);
        Unsafe.SkipInit(out _item3);
        Unsafe.SkipInit(out _item4);
        Unsafe.SkipInit(out _item5);
        Unsafe.SkipInit(out _item6);
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


    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T1 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T2 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T3 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T4 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T5 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T6 value)
    {
        if (value is null) return default;
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    private readonly SetItems _setItem = SetItems.None;


    private readonly T1? _item1;

    private readonly T2? _item2;
    private readonly T3? _item3;
    private readonly T4? _item4;
    private readonly T5? _item5;
    private readonly T6? _item6;

    /// <summary>
    ///     Get a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <param name="variant">Used variant.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    public static T Get<T>(ValueVariant<T1, T2, T3, T4, T5, T6> variant)
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
    public static bool TryGet<T>(ValueVariant<T1, T2, T3, T4, T5, T6> variant, out T? value)
    {
        return variant.TryGet(out value);
    }

    /// <inheritdoc />
    public bool IsSet<T>() => _setItem != SetItems.None && TryGet(out T? _);

    /// <summary>
    ///     Gets a value of the given type. Throws <see cref="BadValueVariantAccessException" /> if type isn't set.
    /// </summary>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Get<T>()
    {
        return _setItem switch
        {
            SetItems.None => throw new BadValueVariantAccessException(typeof(T), this),
            SetItems.Item1 when typeof(T) == typeof(T1) && _item1 is T t1 => t1,
            SetItems.Item2 when typeof(T) == typeof(T2) && _item2 is T t2 => t2,
            SetItems.Item3 when typeof(T) == typeof(T3) && _item3 is T t3 => t3,
            SetItems.Item4 when typeof(T) == typeof(T4) && _item4 is T t4 => t4,
            SetItems.Item5 when typeof(T) == typeof(T5) && _item5 is T t5 => t5,
            SetItems.Item6 when typeof(T) == typeof(T6) && _item6 is T t6 => t6,
            _ => throw new BadValueVariantAccessException(typeof(T), this)
        };
    }

    /// <summary>
    ///     Get a value of the given type. Returns false if type isn't set.
    /// </summary>
    /// <param name="value">Extracted value, default if method returns false.</param>
    /// <typeparam name="T">Requested type.</typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGet<T>(out T? value)
    {
        if (ValueVariant.TestItem(_item1, SetItems.Item1 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item2, SetItems.Item2 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item3, SetItems.Item3 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item4, SetItems.Item4 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item5, SetItems.Item5 == _setItem, out value)) return true;
        return ValueVariant.TestItem(_item6, SetItems.Item6 == _setItem, out value);
    }

    /// <inheritdoc />
    public bool IsValid() => _setItem != SetItems.None && GetSetType() is not null;

    /// <summary>
    /// Returns set type.
    /// </summary>
    /// <returns></returns>
    public Type? GetSetType()
    {
        return _setItem switch
        {
            SetItems.None => null,
            SetItems.Item1 when _item1 is not null => typeof(T1),
            SetItems.Item2 when _item2 is not null => typeof(T2),
            SetItems.Item3 when _item3 is not null => typeof(T3),
            SetItems.Item4 when _item4 is not null => typeof(T4),
            SetItems.Item5 when _item5 is not null => typeof(T5),
            SetItems.Item6 when _item6 is not null => typeof(T6),
            _ => null
        };
    }

    /// <summary>
    ///     Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1>? action1, Action<T2>? action2, Action<T3>? action3, Action<T4>? action4,
        Action<T5>? action5, Action<T6>? action6)
    {
        if (_setItem == SetItems.Item1 && _item1 is not null) action1?.Invoke(_item1);
        if (_setItem == SetItems.Item2 && _item2 is not null) action2?.Invoke(_item2);
        if (_setItem == SetItems.Item3 && _item3 is not null) action3?.Invoke(_item3);
        if (_setItem == SetItems.Item4 && _item4 is not null) action4?.Invoke(_item4);
        if (_setItem == SetItems.Item5 && _item5 is not null) action5?.Invoke(_item5);
        if (_setItem == SetItems.Item6 && _item6 is not null) action6?.Invoke(_item6);
    }

    /// <summary>
    ///     Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult>? func1, Func<T2, TResult>? func2, Func<T3, TResult>? func3,
        Func<T4, TResult>? func4, Func<T5, TResult>? func5, Func<T6, TResult>? func6)
    {
        return _setItem switch
        {
            SetItems.Item1 when _item1 is not null && func1 is not null => func1(_item1),
            SetItems.Item2 when _item2 is not null && func2 is not null => func2(_item2),
            SetItems.Item3 when _item3 is not null && func3 is not null => func3(_item3),
            SetItems.Item4 when _item4 is not null && func4 is not null => func4(_item4),
            SetItems.Item5 when _item5 is not null && func5 is not null => func5(_item5),
            SetItems.Item6 when _item6 is not null && func6 is not null => func6(_item6),
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
        if (action is null) throw new ArgumentNullException(nameof(action));
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
        if (action is null) throw new ArgumentNullException(nameof(action));
       if (fallback is null) throw new ArgumentNullException(nameof(fallback));
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
        if (action is null) throw new ArgumentNullException(nameof(action));
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
        if (func is null) throw new ArgumentNullException(nameof(func));
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
        if (func is null) throw new ArgumentNullException(nameof(func));
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
        if (func is null) throw new ArgumentNullException(nameof(func));
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
            _ => string.Empty
        } ?? string.Empty;
    }

    public bool Equals(ValueVariant<T1, T2, T3, T4, T5, T6> other)
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
                   _ => false
               };
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueVariant<T1, T2, T3, T4, T5, T6> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)_setItem, _item1, _item2, _item3, _item4, _item5, _item6);
    }

    public static bool operator ==(ValueVariant<T1, T2, T3, T4, T5, T6> left,
        ValueVariant<T1, T2, T3, T4, T5, T6> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ValueVariant<T1, T2, T3, T4, T5, T6> left,
        ValueVariant<T1, T2, T3, T4, T5, T6> right)
    {
        return !left.Equals(right);
    }
}