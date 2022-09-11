﻿using System.Runtime.CompilerServices;

namespace Zorya.ValueVariants;

public readonly struct ValueVariant<T1, T2, T3, T4, T5, T6> : IValueVariant
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
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T2 value)
    {
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T3 value)
    {
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T4 value)
    {
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T5 value)
    {
        return new ValueVariant<T1, T2, T3, T4, T5, T6>(value);
    }

    public static implicit operator ValueVariant<T1, T2, T3, T4, T5, T6>(T6 value)
    {
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
            _ => throw new BadValueVariantAccessException(typeof(T), this)
        };
    }

    public bool TryGet<T>(out T? value)
    {
        if (ValueVariant.TestItem(_item1, SetItems.Item1 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item2, SetItems.Item2 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item3, SetItems.Item3 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item4, SetItems.Item4 == _setItem, out value)) return true;
        if (ValueVariant.TestItem(_item5, SetItems.Item5 == _setItem, out value)) return true;
        return ValueVariant.TestItem(_item6, SetItems.Item6 == _setItem, out value);
    }


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
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    /// <summary>
    /// Allows to use a delegate on set item.
    /// </summary>
    public void Visit(Action<T1> action1, Action<T2> action2, Action<T3> action3, Action<T4> action4, Action<T5> action5, Action<T6> action6)
    {
        if (_setItem == SetItems.Item1) action1(_item1!);
        if (_setItem == SetItems.Item2) action2(_item2!);
        if (_setItem == SetItems.Item3) action3(_item3!);
        if (_setItem == SetItems.Item4) action4(_item4!);
        if (_setItem == SetItems.Item5) action5(_item5!);
        if (_setItem == SetItems.Item6) action6(_item6!);
    }
    /// <summary>
    /// Allows to use a delegate returning value on a set item.
    /// </summary>
    /// <typeparam name="TResult">Type of the returned value.</typeparam>
    /// <returns>Value returned from the delegate, default if there was no correct set item.</returns>
    public TResult? Visit<TResult>(Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6)
    {
        return _setItem switch
        {
            SetItems.Item1 => func1(_item1!),
            SetItems.Item2 => func2(_item2!),
            SetItems.Item3 => func3(_item3!),
            SetItems.Item4 => func4(_item4!),
            SetItems.Item5 => func5(_item5!),
            SetItems.Item6 => func6(_item6!),
            _ => default
        };
    }
}